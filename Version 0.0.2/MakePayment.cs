using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriSecDBClientPanel.Model;
using Newtonsoft.Json;
using ASodium;
using System.IO;
using PriSecDBClientPanel.Helper;

namespace PriSecDBClientPanel
{
    public partial class MakePayment : Form
    {
        public MakePayment()
        {
            InitializeComponent();
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

        public Boolean VerifyPayment(String OrderID)
        {
            Byte[] ClientED25519SK = new Byte[] { };
            Byte[] ClientX25519SK = new Byte[] { };
            Byte[] ClientX25519PK = new Byte[] { };
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
            Byte[] EncryptedDatabaseNameByte = new Byte[] { };
            Byte[] DatabaseNameByte = new Byte[] { };
            String DatabaseName = "";
            Byte[] EncryptedDatabaseUserNameByte = new Byte[] { };
            Byte[] DatabaseUserNameByte = new Byte[] { };
            String DatabaseUserName = "";
            Byte[] EncryptedDatabaseUserPasswordByte = new Byte[] { };
            Byte[] DatabaseUserPasswordByte = new Byte[] { };
            String DatabaseUserPassword = "";
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
            PaymentModel MyModel = new PaymentModel();
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
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\LoginED25519SK.txt", MyLoginKeyPair.PrivateKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\LoginED25519PK.txt", MyLoginKeyPair.PublicKey);
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
                    ClientED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDSASK.txt");
                    SharedSecret = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "SharedSecret.txt");
                    OrderIDByte = Encoding.UTF8.GetBytes(OrderID);
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredOrderIDByte = SodiumSecretBox.Create(OrderIDByte, NonceByte, SharedSecret);
                    CombinedCipheredOrderIDByte = NonceByte.Concat(CipheredOrderIDByte).ToArray();
                    ETLSSignedCombinedCipheredOrderIDByte = SodiumPublicKeyAuth.Sign(CombinedCipheredOrderIDByte, ClientED25519SK);
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredLoginED25519PK = SodiumSecretBox.Create(MyLoginKeyPair.PublicKey, NonceByte, SharedSecret);
                    CombinedCipheredLoginED25519PK = NonceByte.Concat(CipheredLoginED25519PK).ToArray();
                    ETLSSignedCombinedCipheredLoginED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredLoginED25519PK, ClientED25519SK);
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    SignedLoginED25519PKByte = SodiumPublicKeyAuth.Sign(MyLoginKeyPair.PublicKey, MyLoginKeyPair.PrivateKey,true);
                    CipheredSignedLoginED25519PK = SodiumSecretBox.Create(SignedLoginED25519PKByte, NonceByte, SharedSecret);
                    CombinedCipheredSignedLoginED25519PK = NonceByte.Concat(CipheredSignedLoginED25519PK).ToArray();
                    ETLSSignedCombinedCipheredSignedLoginED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredSignedLoginED25519PK, ClientED25519SK);
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    SignedSealedDHPKByte = SodiumPublicKeyAuth.Sign(SealedDHKeyPair.PublicKey, SignatureSealedDHKeyPair.PrivateKey,true);
                    CipheredSignedSealedDHPKByte = SodiumSecretBox.Create(SignedSealedDHPKByte, NonceByte, SharedSecret);
                    CombinedCipheredSignedSealedDHPKByte = NonceByte.Concat(CipheredSignedSealedDHPKByte).ToArray();
                    ETLSSignedCombinedCipheredSignedSealedDHPKByte = SodiumPublicKeyAuth.Sign(CombinedCipheredSignedSealedDHPKByte, ClientED25519SK);
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredSealedDHED25519PK = SodiumSecretBox.Create(SignatureSealedDHKeyPair.PublicKey, NonceByte, SharedSecret);
                    CombinedCipheredSealedDHED25519PK = NonceByte.Concat(CipheredSealedDHED25519PK).ToArray();
                    ETLSSignedCombinedCipheredSealedDHED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredSealedDHED25519PK, ClientED25519SK);
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    SignedIKDHPKByte = SodiumPublicKeyAuth.Sign(IKDHKeyPair.PublicKey, IKSignatureKeyPair.PrivateKey,true);
                    CipheredSignedIKDHPKByte = SodiumSecretBox.Create(SignedIKDHPKByte, NonceByte, SharedSecret);
                    CombinedCipheredSignedIKDHPKByte = NonceByte.Concat(CipheredSignedIKDHPKByte).ToArray();
                    ETLSSignedCombinedCipheredSignedIKDHPKByte = SodiumPublicKeyAuth.Sign(CombinedCipheredSignedIKDHPKByte, ClientED25519SK);
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredIKDHED25519PK = SodiumSecretBox.Create(IKSignatureKeyPair.PublicKey, NonceByte, SharedSecret);
                    CombinedCipheredIKDHED25519PK = NonceByte.Concat(CipheredIKDHED25519PK).ToArray();
                    ETLSSignedCombinedCipheredIKDHED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredIKDHED25519PK, ClientED25519SK);
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    SignedSPKDHPKByte = SodiumPublicKeyAuth.Sign(SPKDHKeyPair.PublicKey, SPKSignatureKeyPair.PrivateKey,true);
                    CipheredSignedSPKDHPKByte = SodiumSecretBox.Create(SignedSPKDHPKByte, NonceByte, SharedSecret);
                    CombinedCipheredSignedSPKDHPKByte = NonceByte.Concat(CipheredSignedSPKDHPKByte).ToArray();
                    ETLSSignedCombinedCipheredSignedSPKDHPKByte = SodiumPublicKeyAuth.Sign(CombinedCipheredSignedSPKDHPKByte, ClientED25519SK);
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredSPKDHED25519PK = SodiumSecretBox.Create(SPKSignatureKeyPair.PublicKey, NonceByte, SharedSecret);
                    CombinedCipheredSPKDHED25519PK = NonceByte.Concat(CipheredSPKDHED25519PK).ToArray();
                    ETLSSignedCombinedCipheredSPKDHED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredSPKDHED25519PK, ClientED25519SK);
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    SignedOPKDHPKByte = SodiumPublicKeyAuth.Sign(OPKDHKeyPair.PublicKey, OPKSignatureKeyPair.PrivateKey,true);
                    CipheredSignedOPKDHPKByte = SodiumSecretBox.Create(SignedOPKDHPKByte, NonceByte, SharedSecret);
                    CombinedCipheredSignedOPKDHPKByte = NonceByte.Concat(CipheredSignedOPKDHPKByte).ToArray();
                    ETLSSignedCombinedCipheredSignedOPKDHPKByte = SodiumPublicKeyAuth.Sign(CombinedCipheredSignedOPKDHPKByte, ClientED25519SK);
                    NonceByte = new Byte[] { };
                    NonceByte = SodiumSecretBox.GenerateNonce();
                    CipheredOPKDHED25519PK = SodiumSecretBox.Create(OPKSignatureKeyPair.PublicKey, NonceByte, SharedSecret,true);
                    CombinedCipheredOPKDHED25519PK = NonceByte.Concat(CipheredOPKDHED25519PK).ToArray();
                    ETLSSignedCombinedCipheredOPKDHED25519PK = SodiumPublicKeyAuth.Sign(CombinedCipheredOPKDHED25519PK, ClientED25519SK, true);
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.GetAsync("CreateReceivePayment/CheckPayment?ClientPathID=" + ETLSSessionID +
                            "&CipheredSignedOrderID="
                            + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredOrderIDByte))
                            + "&CipheredSignedLoginED25519PK="
                            + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredLoginED25519PK))
                            + "&EncryptedSignedSignedLoginED25519PK="
                            + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSignedLoginED25519PK))
                            + "&CipheredSignedSignedSealedDHX25519PK="
                            + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSignedSealedDHPKByte))
                            + "&CipheredSignedSealedDHED25519PK="
                            + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSealedDHED25519PK))
                            + "&CipheredSignedSignedSealedX3DHSPKX25519PK="
                            + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSignedSPKDHPKByte))
                            + "&CipheredSignedSealedX3DHSPKED25519PK="
                            + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSPKDHED25519PK))
                            + "&CipheredSignedSignedSealedX3DHIKX25519PK="
                            + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSignedIKDHPKByte))
                            + "&CipheredSignedSealedX3DHIKED25519PK="
                            + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredIKDHED25519PK))
                            + "&CipheredSignedSignedSealedX3DHOPKX25519PK="
                            + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredSignedOPKDHPKByte))
                            + "&CipheredSignedSealedX3DHOPKED25519PK="
                            + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(ETLSSignedCombinedCipheredOPKDHED25519PK)));
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
                                    MyModel = JsonConvert.DeserializeObject<PaymentModel>(Result);
                                    if (MyModel.Status != null && MyModel.Status.CompareTo("") != 0)
                                    {
                                        if (Directory.Exists(Application.StartupPath + "\\Application_Data\\" + "DBCredentials") == false)
                                        {
                                            Directory.CreateDirectory(Application.StartupPath + "\\Application_Data\\" + "DBCredentials");
                                        }
                                        ClientX25519SK = File.ReadAllBytes(Application.StartupPath + "\\Temp_Session\\" + ETLSSessionID + "\\" + "ECDHSK.txt");
                                        ClientX25519PK = SodiumScalarMult.Base(ClientX25519SK);
                                        EncryptedDatabaseNameByte = Convert.FromBase64String(MyModel.CipheredDBName);
                                        EncryptedDatabaseUserNameByte = Convert.FromBase64String(MyModel.CipheredDBAccountUserName);
                                        EncryptedDatabaseUserPasswordByte = Convert.FromBase64String(MyModel.CipheredDBAccountPassword);
                                        DatabaseNameByte = SodiumSealedPublicKeyBox.Open(EncryptedDatabaseNameByte, ClientX25519PK, ClientX25519SK);
                                        DatabaseUserNameByte = SodiumSealedPublicKeyBox.Open(EncryptedDatabaseUserNameByte, ClientX25519PK, ClientX25519SK);
                                        DatabaseUserPasswordByte = SodiumSealedPublicKeyBox.Open(EncryptedDatabaseUserPasswordByte, ClientX25519PK, ClientX25519SK,true);
                                        DatabaseName = Encoding.UTF8.GetString(DatabaseNameByte);
                                        DatabaseUserName = Encoding.UTF8.GetString(DatabaseUserNameByte);
                                        DatabaseUserPassword = Encoding.UTF8.GetString(DatabaseUserPasswordByte);
                                        PaymentIDTB.Text = MyModel.SystemPaymentID;
                                        DBNameTB.Text = DatabaseName;
                                        DBUserNameTB.Text = DatabaseUserName;
                                        DBUserPasswordTB.Text = DatabaseUserPassword;
                                        File.WriteAllText(Application.StartupPath + "\\Application_Data\\" + "DBCredentials\\PaymentID.txt", MyModel.SystemPaymentID);
                                        File.WriteAllText(Application.StartupPath + "\\Application_Data\\" + "DBCredentials\\DBName.txt", DatabaseName);
                                        File.WriteAllText(Application.StartupPath + "\\Application_Data\\" + "DBCredentials\\DBUserName.txt", DatabaseUserName);
                                        File.WriteAllText(Application.StartupPath + "\\Application_Data\\" + "DBCredentials\\DBUserPassword.txt", DatabaseUserPassword);
                                        File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "DBCredentials\\DBNameBytes.txt", DatabaseNameByte);
                                        File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "DBCredentials\\DBUserNameBytes.txt", DatabaseUserNameByte);
                                        File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\" + "DBCredentials\\DBUserPasswordBytes.txt", DatabaseUserPasswordByte);
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
                                    else
                                    {
                                        SodiumSecureMemory.SecureClearBytes(ClientED25519SK);
                                        SodiumSecureMemory.SecureClearBytes(ClientX25519SK);
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
                                SodiumSecureMemory.SecureClearBytes(ClientED25519SK);
                                SodiumSecureMemory.SecureClearBytes(ClientX25519SK);
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
                            SodiumSecureMemory.SecureClearBytes(ClientED25519SK);
                            SodiumSecureMemory.SecureClearBytes(ClientX25519SK);
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
                    SodiumSecureMemory.SecureClearBytes(ClientED25519SK);
                    SodiumSecureMemory.SecureClearBytes(ClientX25519SK);
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
                SodiumSecureMemory.SecureClearBytes(ClientED25519SK);
                SodiumSecureMemory.SecureClearBytes(ClientX25519SK);
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

        private void VerifyPaymentBTN_Click(object sender, EventArgs e)
        {
            String OrderID = "";
            Boolean HasMadePayment = true;
            if(OrderIDTB.Text!=null && OrderIDTB.Text.CompareTo("") != 0) 
            {
                OrderID = OrderIDTB.Text;
                HasMadePayment = VerifyPayment(OrderID);
                if (HasMadePayment == true) 
                {
                    MessageBox.Show("Congratulations, you have made payment, please take a look at system generated database name, account and passwords."
                        + Environment.NewLine + "At the same time, go to the" +
                        " application's folder(Application Data), to store all those important data(All 3 folders data) in" +
                        " somewhere safe and private(Exclude Google Drive or any storage that uses centralized key management system)",
                        "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("In devlopment/actual environment, you have to encrypt your db credentials in a way that only server can read it."
                        + Environment.NewLine + "There will be manuals/guide that comes along with this minor database panel", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("This application by default has been coded in a way that each location can only tolerate in buying 1 database."
                        + Environment.NewLine + "If you wished to buy more databases ,you have to copy and paste the application to different locations"
                        + Environment.NewLine + "You have to bear your own responsibility if you don't follow the advice.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    MessageBox.Show("Sorry something went wrong.., please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnClosing(object sender, EventArgs e) 
        {
            MainFormHolder.myForm.Show();
            MainFormHolder.OpenMainForm = true;
        }
    }
}
