using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriSecDBClientPanel.Model;
using Newtonsoft.Json;
using ASodium;
using System.Runtime.InteropServices;
using System.IO;
using System.Web;
using PriSecDBClientPanel.Helper;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PriSecDBClientPanel
{
    public partial class RenewPayment : Form
    {
        public RenewPayment()
        {
            InitializeComponent();
        }

        public void RequestChallenge(ref String Base64ServerChallenge)
        {
            Byte[] ServerRandomChallenge = new Byte[] { };
            Byte[] ServerSignedRandomChallenge = new Byte[] { };
            Byte[] ServerED25519PK = new Byte[] { };
            Boolean ServerOnlineChecker = true;
            Boolean CheckServerED25519PK = true;
            LoginModels MyLoginModels = new LoginModels();
            GCHandle MyGeneralGCHandle;
            if (ETLSSessionIDStorage.ETLSID.CompareTo("") != 0 && ETLSSessionIDStorage.ETLSID != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("Login/");
                    try
                    {
                        response.Wait();
                    }
                    catch
                    {
                        ServerOnlineChecker = false;
                    }
                    if (ServerOnlineChecker == true)
                    {
                        var result = response.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();

                            var LoginModelsResult = readTask.Result;
                            MyLoginModels = JsonConvert.DeserializeObject<LoginModels>(LoginModelsResult);
                            if (MyLoginModels.RequestStatus.Contains("Error"))
                            {
                                MessageBox.Show("Something went wrong when requesting random challenge...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageBox.Show("Request Error Message: " + MyLoginModels.RequestStatus, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                ServerSignedRandomChallenge = Convert.FromBase64String(MyLoginModels.SignedRandomChallengeBase64String);
                                ServerED25519PK = Convert.FromBase64String(MyLoginModels.ServerECDSAPKBase64String);
                                try
                                {
                                    ServerRandomChallenge = SodiumPublicKeyAuth.Verify(ServerSignedRandomChallenge, ServerED25519PK);
                                }
                                catch
                                {
                                    CheckServerED25519PK = false;
                                }
                                if (CheckServerED25519PK == true)
                                {
                                    Base64ServerChallenge = Convert.ToBase64String(ServerRandomChallenge);
                                    MyGeneralGCHandle = GCHandle.Alloc(ServerSignedRandomChallenge, GCHandleType.Pinned);
                                    SodiumSecureMemory.MemZero(MyGeneralGCHandle.AddrOfPinnedObject(), ServerSignedRandomChallenge.Length);
                                    MyGeneralGCHandle.Free();
                                    MyGeneralGCHandle = GCHandle.Alloc(ServerRandomChallenge, GCHandleType.Pinned);
                                    SodiumSecureMemory.MemZero(MyGeneralGCHandle.AddrOfPinnedObject(), ServerRandomChallenge.Length);
                                    MyGeneralGCHandle.Free();
                                    MyGeneralGCHandle = GCHandle.Alloc(ServerED25519PK, GCHandleType.Pinned);
                                    SodiumSecureMemory.MemZero(MyGeneralGCHandle.AddrOfPinnedObject(), ServerED25519PK.Length);
                                    MyGeneralGCHandle.Free();
                                }
                                else
                                {
                                    Base64ServerChallenge = "";
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong with fetching values from server ...", "Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Server is now offline...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("You have not yet establish an ephemeral TLS session with the server..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Boolean GetPaymentCheckOutPage(ref String OrderID, ref String CheckOutPageUrl)
        {
            CheckOutPageHolderModel PageHolder = new CheckOutPageHolderModel();
            Boolean CheckServerBoolean = true;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("CreateReceivePayment/");
                try
                {
                    response.Wait();
                }
                catch
                {
                    CheckServerBoolean = false;
                }
                if (CheckServerBoolean == true)
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var Result = readTask.Result;
                        if (Result != null && Result.CompareTo("") != 0 && Result.Contains("Error") == false)
                        {
                            PageHolder = JsonConvert.DeserializeObject<CheckOutPageHolderModel>(Result);
                            OrderID = PageHolder.PayPalOrderID;
                            CheckOutPageUrl = PageHolder.CheckOutPageUrl;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong with fetching values from server ...", "Request CheckOut Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Server is having some problems or offline...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public Boolean VerifyPayment(String OrderID,Byte[] RandomChallenge)
        {
            String UniquePaymentID = "";
            Byte[] UniquePaymentIDByte = new Byte[] { };
            Byte[] CipheredUniquePaymentIDByte = new Byte[] { };
            Byte[] CombinedCipheredUniquePaymentIDByte = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredUniquePaymentIDByte = new Byte[] { };
            Byte[] ClientED25519SK = new Byte[] { };
            Byte[] ClientLoginED25519SK = new Byte[] { };
            Byte[] SharedSecret = new Byte[] { };
            Byte[] OrderIDByte = new Byte[] { };
            Byte[] NonceByte = new Byte[] { };
            Byte[] CipheredOrderIDByte = new Byte[] { };
            Byte[] CombinedCipheredOrderIDByte = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredOrderIDByte = new Byte[] { };
            Byte[] CipheredLoginED25519PK = new Byte[] { };
            Byte[] CombinedCipheredLoginED25519PK = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredLoginED25519PK = new Byte[] { };
            Byte[] SignedLoginED25519PKByte = new Byte[] { };
            Byte[] CipheredSignedLoginED25519PK = new Byte[] { };
            Byte[] CombinedCipheredSignedLoginED25519PK = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredSignedLoginED25519PK = new Byte[] { };
            Byte[] SignedSealedDHPKByte = new Byte[] { };
            Byte[] CipheredSignedSealedDHPKByte = new Byte[] { };
            Byte[] CombinedCipheredSignedSealedDHPKByte = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredSignedSealedDHPKByte = new Byte[] { };
            Byte[] CipheredSealedDHED25519PK = new Byte[] { };
            Byte[] CombinedCipheredSealedDHED25519PK = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredSealedDHED25519PK = new Byte[] { };
            Byte[] SignedIKDHPKByte = new Byte[] { };
            Byte[] CipheredSignedIKDHPKByte = new Byte[] { };
            Byte[] CombinedCipheredSignedIKDHPKByte = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredSignedIKDHPKByte = new Byte[] { };
            Byte[] CipheredIKDHED25519PK = new Byte[] { };
            Byte[] CombinedCipheredIKDHED25519PK = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredIKDHED25519PK = new Byte[] { };
            Byte[] SignedSPKDHPKByte = new Byte[] { };
            Byte[] CipheredSignedSPKDHPKByte = new Byte[] { };
            Byte[] CombinedCipheredSignedSPKDHPKByte = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredSignedSPKDHPKByte = new Byte[] { };
            Byte[] CipheredSPKDHED25519PK = new Byte[] { };
            Byte[] CombinedCipheredSPKDHED25519PK = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredSPKDHED25519PK = new Byte[] { };
            Byte[] SignedOPKDHPKByte = new Byte[] { };
            Byte[] CipheredSignedOPKDHPKByte = new Byte[] { };
            Byte[] CombinedCipheredSignedOPKDHPKByte = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredSignedOPKDHPKByte = new Byte[] { };
            Byte[] CipheredOPKDHED25519PK = new Byte[] { };
            Byte[] CombinedCipheredOPKDHED25519PK = new Byte[] { };
            Byte[] ETLSSignedCombinedCipheredOPKDHED25519PK = new Byte[] { };
            Byte[] SignedRandomChallenge = new Byte[] { };
            Byte[] ETLSSignedSignedRandomChallenge = new Byte[] { };
            Boolean CheckServerBoolean = true;
            RevampedKeyPair MyLoginKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
            RevampedKeyPair SignatureSealedDHKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
            RevampedKeyPair SealedDHKeyPair = SodiumPublicKeyBox.GenerateRevampedKeyPair();
            RevampedKeyPair IKSignatureKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
            RevampedKeyPair IKDHKeyPair = SodiumPublicKeyBox.GenerateRevampedKeyPair();
            RevampedKeyPair SPKSignatureKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
            RevampedKeyPair SPKDHKeyPair = SodiumPublicKeyBox.GenerateRevampedKeyPair();
            RevampedKeyPair OPKSignatureKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
            RevampedKeyPair OPKDHKeyPair = SodiumPublicKeyBox.GenerateRevampedKeyPair();
            GCHandle MyGeneralGCHandle = new GCHandle();
            String ETLSSessionID = "";
            ETLSSessionID = File.ReadAllText(Application.StartupPath + "\\Temp_Session\\" + "SessionID.txt");
            if (OrderID != null && OrderID.CompareTo("") != 0)
            {
                if (ETLSSessionID != null && ETLSSessionID.CompareTo("") != 0)
                {
                    if (Directory.Exists(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage") == false)
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage");
                    }
                    if (Directory.Exists(Application.StartupPath + "\\Application_Data\\" + "DHStorage") == false)
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\Application_Data\\" + "DHStorage");
                    }
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\SignatureSealedDHED25519SK.txt", SignatureSealedDHKeyPair.PrivateKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\SignatureSealedDHED25519PK.txt", SignatureSealedDHKeyPair.PublicKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\IKSignatureED25519SK.txt", IKSignatureKeyPair.PrivateKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\IKSignatureED25519PK.txt", IKSignatureKeyPair.PublicKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\SPKSignatureED25519SK.txt", SPKSignatureKeyPair.PrivateKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\SPKSignatureED25519PK.txt", SPKSignatureKeyPair.PublicKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\OPKSignatureED25519SK.txt", OPKSignatureKeyPair.PrivateKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\OPKSignatureED25519PK.txt", OPKSignatureKeyPair.PublicKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "DHStorage\\SealedDHX25519SK.txt", SealedDHKeyPair.PrivateKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "DHStorage\\SealedDHX25519PK.txt", SealedDHKeyPair.PublicKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "DHStorage\\IKX25519SK.txt", IKDHKeyPair.PrivateKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "DHStorage\\IKX25519PK.txt", IKDHKeyPair.PublicKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "DHStorage\\SPKX25519SK.txt", SPKDHKeyPair.PrivateKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "DHStorage\\SPKX25519PK.txt", SPKDHKeyPair.PublicKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "DHStorage\\OPKX25519SK.txt", OPKDHKeyPair.PrivateKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "DHStorage\\OPKX25519PK.txt", OPKDHKeyPair.PublicKey);
                    SharedSecret = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "SharedSecret.txt");
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    UniquePaymentID = File.ReadAllText(Application.StartupPath + "\\Application_Data\\" + "DBCredentials\\PaymentID.txt");
                    UniquePaymentIDByte = Encoding.UTF8.GetBytes(UniquePaymentID);
                    CipheredUniquePaymentIDByte = SodiumSecretBox.Create(UniquePaymentIDByte, NonceByte, SharedSecret);
                    CombinedCipheredUniquePaymentIDByte = NonceByte.Concat(CipheredUniquePaymentIDByte).ToArray();
                    ETLSSignedCombinedCipheredUniquePaymentIDByte = SodiumPublicKeyAuth.Sign(CombinedCipheredUniquePaymentIDByte,ClientED25519SK);
                    ClientLoginED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\LoginED25519SK.txt");
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    SignedRandomChallenge = SodiumPublicKeyAuth.Sign(RandomChallenge, ClientLoginED25519SK);
                    ETLSSignedSignedRandomChallenge = SodiumPublicKeyAuth.Sign(SignedRandomChallenge, ClientED25519SK);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\LoginED25519SK.txt", MyLoginKeyPair.PrivateKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\LoginED25519PK.txt", MyLoginKeyPair.PublicKey);
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    OrderIDByte = Encoding.UTF8.GetBytes(OrderID);
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredOrderIDByte = SodiumSecretBox.Create(OrderIDByte, NonceByte, SharedSecret);
                    CombinedCipheredOrderIDByte = NonceByte.Concat(CipheredOrderIDByte).ToArray();
                    ETLSSignedCombinedCipheredOrderIDByte = SodiumPublicKeyAuth.Sign(CombinedCipheredOrderIDByte, ClientED25519SK);
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredLoginED25519PK = SodiumSecretBox.Create(MyLoginKeyPair.PublicKey, NonceByte, SharedSecret);
                    CombinedCipheredLoginED25519PK = NonceByte.Concat(CipheredLoginED25519PK).ToArray();
                    ETLSSignedCombinedCipheredLoginED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredLoginED25519PK, ClientED25519SK);
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    SignedLoginED25519PKByte = SodiumPublicKeyAuth.Sign(MyLoginKeyPair.PublicKey, MyLoginKeyPair.PrivateKey);
                    CipheredSignedLoginED25519PK = SodiumSecretBox.Create(SignedLoginED25519PKByte, NonceByte, SharedSecret);
                    CombinedCipheredSignedLoginED25519PK = NonceByte.Concat(CipheredSignedLoginED25519PK).ToArray();
                    ETLSSignedCombinedCipheredSignedLoginED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredSignedLoginED25519PK, ClientED25519SK);
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    SignedSealedDHPKByte = SodiumPublicKeyAuth.Sign(SealedDHKeyPair.PublicKey, SignatureSealedDHKeyPair.PrivateKey);
                    CipheredSignedSealedDHPKByte = SodiumSecretBox.Create(SignedSealedDHPKByte, NonceByte, SharedSecret);
                    CombinedCipheredSignedSealedDHPKByte = NonceByte.Concat(CipheredSignedSealedDHPKByte).ToArray();
                    ETLSSignedCombinedCipheredSignedSealedDHPKByte = SodiumPublicKeyAuth.Sign(CombinedCipheredSignedSealedDHPKByte, ClientED25519SK);
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredSealedDHED25519PK = SodiumSecretBox.Create(SignatureSealedDHKeyPair.PublicKey, NonceByte, SharedSecret);
                    CombinedCipheredSealedDHED25519PK = NonceByte.Concat(CipheredSealedDHED25519PK).ToArray();
                    ETLSSignedCombinedCipheredSealedDHED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredSealedDHED25519PK, ClientED25519SK);
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    SignedIKDHPKByte = SodiumPublicKeyAuth.Sign(IKDHKeyPair.PublicKey, IKSignatureKeyPair.PrivateKey);
                    CipheredSignedIKDHPKByte = SodiumSecretBox.Create(SignedIKDHPKByte, NonceByte, SharedSecret);
                    CombinedCipheredSignedIKDHPKByte = NonceByte.Concat(CipheredSignedIKDHPKByte).ToArray();
                    ETLSSignedCombinedCipheredSignedIKDHPKByte = SodiumPublicKeyAuth.Sign(CombinedCipheredSignedIKDHPKByte, ClientED25519SK);
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredIKDHED25519PK = SodiumSecretBox.Create(IKSignatureKeyPair.PublicKey, NonceByte, SharedSecret);
                    CombinedCipheredIKDHED25519PK = NonceByte.Concat(CipheredIKDHED25519PK).ToArray();
                    ETLSSignedCombinedCipheredIKDHED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredIKDHED25519PK, ClientED25519SK);
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    SignedSPKDHPKByte = SodiumPublicKeyAuth.Sign(SPKDHKeyPair.PublicKey, SPKSignatureKeyPair.PrivateKey);
                    CipheredSignedSPKDHPKByte = SodiumSecretBox.Create(SignedSPKDHPKByte, NonceByte, SharedSecret);
                    CombinedCipheredSignedSPKDHPKByte = NonceByte.Concat(CipheredSignedSPKDHPKByte).ToArray();
                    ETLSSignedCombinedCipheredSignedSPKDHPKByte = SodiumPublicKeyAuth.Sign(CombinedCipheredSignedSPKDHPKByte, ClientED25519SK);
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredSPKDHED25519PK = SodiumSecretBox.Create(SPKSignatureKeyPair.PublicKey, NonceByte, SharedSecret);
                    CombinedCipheredSPKDHED25519PK = NonceByte.Concat(CipheredSPKDHED25519PK).ToArray();
                    ETLSSignedCombinedCipheredSPKDHED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredSPKDHED25519PK, ClientED25519SK);
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    SignedOPKDHPKByte = SodiumPublicKeyAuth.Sign(OPKDHKeyPair.PublicKey, OPKSignatureKeyPair.PrivateKey);
                    CipheredSignedOPKDHPKByte = SodiumSecretBox.Create(SignedOPKDHPKByte, NonceByte, SharedSecret);
                    CombinedCipheredSignedOPKDHPKByte = NonceByte.Concat(CipheredSignedOPKDHPKByte).ToArray();
                    ETLSSignedCombinedCipheredSignedOPKDHPKByte = SodiumPublicKeyAuth.Sign(CombinedCipheredSignedOPKDHPKByte, ClientED25519SK);
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredOPKDHED25519PK = SodiumSecretBox.Create(OPKSignatureKeyPair.PublicKey, NonceByte, SharedSecret);
                    CombinedCipheredOPKDHED25519PK = NonceByte.Concat(CipheredOPKDHED25519PK).ToArray();
                    ETLSSignedCombinedCipheredOPKDHED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredOPKDHED25519PK, ClientED25519SK);
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.GetAsync("CreateReceivePayment/RenewPayment?ClientPathID=" + ETLSSessionID +
                            "&CipheredSignedOrderID="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredOrderIDByte))
                            + "&CipheredSignedUniquePaymentID="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredUniquePaymentIDByte))
                            + "&SignedSignedRandomChallenge="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedSignedRandomChallenge))
                            + "&CipheredSignedLoginED25519PK="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredLoginED25519PK))
                            + "&EncryptedSignedSignedLoginED25519PK="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSignedLoginED25519PK))
                            + "&CipheredSignedSignedSealedDHX25519PK="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSignedSealedDHPKByte))
                            + "&CipheredSignedSealedDHED25519PK="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSealedDHED25519PK))
                            + "&CipheredSignedSignedSealedX3DHSPKX25519PK="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSignedSPKDHPKByte))
                            + "&CipheredSignedSealedX3DHSPKED25519PK="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSPKDHED25519PK))
                            + "&CipheredSignedSignedSealedX3DHIKX25519PK="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSignedIKDHPKByte))
                            + "&CipheredSignedSealedX3DHIKED25519PK="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredIKDHED25519PK))
                            + "&CipheredSignedSignedSealedX3DHOPKX25519PK="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSignedOPKDHPKByte))
                            + "&CipheredSignedSealedX3DHOPKED25519PK="
                            + HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredOPKDHED25519PK)));
                        try
                        {
                            response.Wait();
                        }
                        catch
                        {
                            CheckServerBoolean = false;
                        }
                        if (CheckServerBoolean == true)
                        {
                            var result = response.Result;
                            if (result.IsSuccessStatusCode)
                            {
                                var readTask = result.Content.ReadAsStringAsync();
                                readTask.Wait();

                                var Result = readTask.Result;
                                if ((Result == null || Result.CompareTo("") == 0) || (Result.Contains("Error") == true))
                                {
                                    MessageBox.Show(Result.Substring(1, Result.Length - 2), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                                else
                                {
                                    Result = Result.Substring(1, Result.Length - 2);
                                    MyGeneralGCHandle = GCHandle.Alloc(SharedSecret, GCHandleType.Pinned);
                                    SodiumSecureMemory.MemZero(MyGeneralGCHandle.AddrOfPinnedObject(), SharedSecret.Length);
                                    MyGeneralGCHandle.Free(); MyLoginKeyPair.Clear();
                                    MyLoginKeyPair.Clear();
                                    SignatureSealedDHKeyPair.Clear();
                                    SealedDHKeyPair.Clear();
                                    IKSignatureKeyPair.Clear();
                                    IKDHKeyPair.Clear();
                                    SPKSignatureKeyPair.Clear();
                                    SPKDHKeyPair.Clear();
                                    OPKSignatureKeyPair.Clear();
                                    OPKDHKeyPair.Clear();
                                    return true;
                                }
                            }
                            else
                            {
                                MyGeneralGCHandle = GCHandle.Alloc(SharedSecret, GCHandleType.Pinned);
                                SodiumSecureMemory.MemZero(MyGeneralGCHandle.AddrOfPinnedObject(), SharedSecret.Length);
                                MyGeneralGCHandle.Free();
                                MyLoginKeyPair.Clear();
                                SignatureSealedDHKeyPair.Clear();
                                SealedDHKeyPair.Clear();
                                IKSignatureKeyPair.Clear();
                                IKDHKeyPair.Clear();
                                SPKSignatureKeyPair.Clear();
                                SPKDHKeyPair.Clear();
                                OPKSignatureKeyPair.Clear();
                                OPKDHKeyPair.Clear();
                                return false;
                            }
                        }
                        else
                        {
                            MyGeneralGCHandle = GCHandle.Alloc(SharedSecret, GCHandleType.Pinned);
                            SodiumSecureMemory.MemZero(MyGeneralGCHandle.AddrOfPinnedObject(), SharedSecret.Length);
                            MyGeneralGCHandle.Free();
                            MyLoginKeyPair.Clear();
                            SignatureSealedDHKeyPair.Clear();
                            SealedDHKeyPair.Clear();
                            IKSignatureKeyPair.Clear();
                            IKDHKeyPair.Clear();
                            SPKSignatureKeyPair.Clear();
                            SPKDHKeyPair.Clear();
                            OPKSignatureKeyPair.Clear();
                            OPKDHKeyPair.Clear();
                            return false;
                        }
                    }
                }
                else
                {
                    MyGeneralGCHandle = GCHandle.Alloc(SharedSecret, GCHandleType.Pinned);
                    SodiumSecureMemory.MemZero(MyGeneralGCHandle.AddrOfPinnedObject(), SharedSecret.Length);
                    MyGeneralGCHandle.Free();
                    MyLoginKeyPair.Clear();
                    SignatureSealedDHKeyPair.Clear();
                    SealedDHKeyPair.Clear();
                    IKSignatureKeyPair.Clear();
                    IKDHKeyPair.Clear();
                    SPKSignatureKeyPair.Clear();
                    SPKDHKeyPair.Clear();
                    OPKSignatureKeyPair.Clear();
                    OPKDHKeyPair.Clear();
                    return false;
                }
            }
            else
            {
                MyGeneralGCHandle = GCHandle.Alloc(SharedSecret, GCHandleType.Pinned);
                SodiumSecureMemory.MemZero(MyGeneralGCHandle.AddrOfPinnedObject(), SharedSecret.Length);
                MyGeneralGCHandle.Free();
                MyLoginKeyPair.Clear();
                SignatureSealedDHKeyPair.Clear();
                SealedDHKeyPair.Clear();
                IKSignatureKeyPair.Clear();
                IKDHKeyPair.Clear();
                SPKSignatureKeyPair.Clear();
                SPKDHKeyPair.Clear();
                OPKSignatureKeyPair.Clear();
                OPKDHKeyPair.Clear();
                return false;
            }
        }

        private void CreatePaymentBTN_Click(object sender, EventArgs e)
        {
            Boolean HasDHStorage = Directory.Exists(Application.StartupPath + "\\Application_Data\\" + "DHStorage") == true;
            Boolean HasSignatureStorage = Directory.Exists(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage") == true;
            Boolean HasDBCredentials = Directory.Exists(Application.StartupPath + "\\Application_Data\\" + "DBCredentials") == true;
            if(HasDHStorage==true && HasSignatureStorage==true && HasDBCredentials == true) 
            {
                String OrderID = "";
                String CheckOutPageUrl = "";
                if (GetPaymentCheckOutPage(ref OrderID, ref CheckOutPageUrl) == true)
                {
                    OrderIDTB.Text = OrderID;
                    CheckOutPageURLTB.Text = CheckOutPageUrl;
                }
                else
                {
                    MessageBox.Show("Failed to get check out page from server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("You can't renew service/payment as you haven't make payment to the service yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void VerifyPaymentBTN_Click(object sender, EventArgs e)
        {
            String OrderID = "";
            Boolean HasMadePayment = true;
            String Base64RandomChallenge = "";
            if(OrderIDTB.Text!=null && OrderIDTB.Text.CompareTo("") != 0) 
            {
                OrderID = OrderIDTB.Text;
                RequestChallenge(ref Base64RandomChallenge);
                Byte[] RandomChallengeByte = new Byte[] { };
                while (Base64RandomChallenge.CompareTo("") == 0)
                {
                    Base64RandomChallenge = "";
                    RequestChallenge(ref Base64RandomChallenge);
                }
                RandomChallengeByte = Convert.FromBase64String(Base64RandomChallenge);
                HasMadePayment = VerifyPayment(OrderID, RandomChallengeByte);
                if (HasMadePayment == true) 
                {
                    MessageBox.Show("Congratulations, you have renew payment, all cryptographic keys have been reset and updated"
                        + Environment.NewLine + "If there's a need to store the reset and updated keys, go to the (Application Data) folder inside the application" +
                        " to access them. Same advice, if you are security conscious user, don't store the keys at Google Drive or any storage that" +
                        " uses centralized key management system",
                        "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    MessageBox.Show("Sorry something went wrong.., please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("Order ID and link does not exists, system can't verify payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnClosing(object sender, EventArgs e)
        {
            MainFormHolder.myForm.Show();
            MainFormHolder.OpenMainForm = true;
        }

        private void RenewPayment_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Before you actually want to renew the payment/service,make sure that you store the previous cryptographic keys that generated locally in 'Application_Data' folder to other location in the device you own","Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            MessageBox.Show("The DHStorage that located in 'Application_Data' folder represents folder" +
                " that stores Diffie Hellman Key Exchange public and private key which will be useful for " +
                "decrypting data in the machine you own later", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show("You will need to bear your own responsibility if you don't follow the advice", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
