using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriSecDBClientPanel.Helper;
using PriSecDBClientPanel.Model;
using ASodium;
using System.Web;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Net.Http;
using System.IO;
using System.Security.Cryptography;

namespace PriSecDBClientPanel
{
    public partial class CreateSealedDBCredentials : Form
    {
        private SecureIDGenerator MySecureIDGenerator = new SecureIDGenerator();

        public CreateSealedDBCredentials()
        {
            InitializeComponent();
        }

        public void CreateSealedSession()
        {
            RevampedKeyPair SessionECDHKeyPair = SodiumPublicKeyBox.GenerateRevampedKeyPair();
            RevampedKeyPair SessionECDSAKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
            String MySession_ID = MySecureIDGenerator.GenerateUniqueString();
            ECDH_ECDSA_Models MyECDH_ECDSA_Models = new ECDH_ECDSA_Models();
            Boolean CheckServerOnline = true;
            Byte[] DBNameByte = new Byte[] { };
            Byte[] SealedDBNameByte = new Byte[] { };
            Byte[] DBUserNameByte = new Byte[] { };
            Byte[] SealedDBUserNameByte = new Byte[] { };
            Byte[] DBUserPasswordByte = new Byte[] { };
            Byte[] SealedDBUserPasswordByte = new Byte[] { };
            Byte[] ServerECDSAPKByte = new Byte[] { };
            Byte[] ServerECDHSPKByte = new Byte[] { };
            Byte[] ServerECDHPKByte = new Byte[] { };
            Byte[] SignedClientSessionECDHPKByte = new Byte[] { };
            Byte[] ClientSessionECDSAPKByte = new Byte[] { };
            Boolean VerifyBoolean = true;
            String SessionStatus = "";
            String ExceptionString = "";
            using (var InitializeHandShakeHttpclient = new HttpClient())
            {
                InitializeHandShakeHttpclient.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                InitializeHandShakeHttpclient.DefaultRequestHeaders.Accept.Clear();
                InitializeHandShakeHttpclient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = InitializeHandShakeHttpclient.GetAsync("EstablishSealedBoxDBCredentials/byID?ClientPathID=" + MySession_ID);
                try
                {
                    response.Wait();
                }
                catch
                {
                    CheckServerOnline = false;
                }
                if (CheckServerOnline == true)
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var ECDH_ECDSA_Models_Result = readTask.Result;
                        MyECDH_ECDSA_Models = JsonConvert.DeserializeObject<ECDH_ECDSA_Models>(ECDH_ECDSA_Models_Result);
                        if (MyECDH_ECDSA_Models.ID_Checker_Message.CompareTo("You still can use the exact same client ID...") == 0 || MyECDH_ECDSA_Models.ID_Checker_Message.CompareTo("You have an exact client ID great~") == 0)
                        {
                            ServerECDSAPKByte = Convert.FromBase64String(MyECDH_ECDSA_Models.ECDSA_PK_Base64String);
                            ServerECDHSPKByte = Convert.FromBase64String(MyECDH_ECDSA_Models.ECDH_SPK_Base64String);
                            GCHandle ServerECDSAPKByteGCHandle = GCHandle.Alloc(ServerECDSAPKByte, GCHandleType.Pinned);
                            GCHandle ServerECDHSPKByteGCHandle = GCHandle.Alloc(ServerECDHSPKByte, GCHandleType.Pinned);
                            try
                            {
                                ServerECDHPKByte = SodiumPublicKeyAuth.Verify(ServerECDHSPKByte, ServerECDSAPKByte);
                            }
                            catch (Exception exception)
                            {
                                VerifyBoolean = false;
                                ExceptionString = exception.ToString();
                                SessionStatus += ExceptionString + Environment.NewLine;
                            }
                            if (VerifyBoolean == true)
                            {
                                if (Directory.Exists(Application.StartupPath + "\\Application_Data\\SealedCredentials") == false) 
                                {
                                    Directory.CreateDirectory(Application.StartupPath + "\\Application_Data\\SealedCredentials");
                                }
                                if (Directory.Exists(Application.StartupPath + "\\Application_Data\\SealedCredentials\\"+MySession_ID)==false) 
                                {
                                    Directory.CreateDirectory(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + MySession_ID);
                                }
                                DBNameByte = File.ReadAllBytes(Application.StartupPath+"\\Application_Data\\DBCredentials\\DBNameBytes.txt");
                                DBUserNameByte = File.ReadAllBytes(Application.StartupPath + "\\Application_Data\\DBCredentials\\DBUserNameBytes.txt");
                                DBUserPasswordByte = File.ReadAllBytes(Application.StartupPath + "\\Application_Data\\DBCredentials\\DBUserPasswordBytes.txt");
                                SealedDBNameByte = SodiumSealedPublicKeyBox.Create(DBNameByte, ServerECDHPKByte);
                                SealedDBUserNameByte = SodiumSealedPublicKeyBox.Create(DBUserNameByte, ServerECDHPKByte);
                                SealedDBUserPasswordByte = SodiumSealedPublicKeyBox.Create(DBUserPasswordByte, ServerECDHPKByte);
                                File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + MySession_ID + "\\SealedDBName.txt",SealedDBNameByte);
                                File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + MySession_ID + "\\SealedDBUserName.txt", SealedDBUserNameByte);
                                File.WriteAllBytes(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + MySession_ID + "\\SealedDBUserPassword.txt", SealedDBUserPasswordByte);
                                File.WriteAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + MySession_ID + "\\SealedDBNameB64.txt", Convert.ToBase64String(SealedDBNameByte));
                                File.WriteAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + MySession_ID + "\\SealedDBUserNameB64.txt", Convert.ToBase64String(SealedDBUserNameByte));
                                File.WriteAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + MySession_ID + "\\SealedDBUserPasswordB64.txt", Convert.ToBase64String(SealedDBUserPasswordByte));
                                SessionIDTB.Text = MySession_ID;
                                SealedDBNameTB.Text = Convert.ToBase64String(SealedDBNameByte);
                                SealedDBUserNameTB.Text = Convert.ToBase64String(SealedDBUserNameByte);
                                SealedDBUserPasswordTB.Text = Convert.ToBase64String(SealedDBUserPasswordByte);
                            }
                            else
                            {
                                File.WriteAllText(Application.StartupPath + "\\Error_Data\\CreateSealedCredentials\\FetchHandShakeSessionParameterStatus.txt", "Server's ECDH public key can't be verified with given ECDSA public key");
                                MessageBox.Show("Failed to verify ECDH parameters received from server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            SodiumSecureMemory.MemZero(ServerECDHSPKByteGCHandle.AddrOfPinnedObject(), ServerECDHSPKByte.Length);
                            SodiumSecureMemory.MemZero(ServerECDSAPKByteGCHandle.AddrOfPinnedObject(), ServerECDSAPKByte.Length);
                            ServerECDHSPKByteGCHandle.Free();
                            ServerECDSAPKByteGCHandle.Free();
                        }
                        else
                        {
                            MessageBox.Show(MyECDH_ECDSA_Models.ID_Checker_Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        File.WriteAllText(Application.StartupPath + "\\Error_Data\\Greetings\\FetchHandShakeSessionParameterStatus.txt", "Failed to get handshake parameters from server");
                    }
                }
                else
                {
                    MessageBox.Show("The server is offline now please wait for awhile ..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            SessionECDHKeyPair.Clear();
            SessionECDSAKeyPair.Clear();
        }

        private void CreateCredentialsBTN_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\Application_Data\\DBCredentials")==true) 
            {
                if (Directory.Exists(Application.StartupPath + "\\Application_Data\\SealedCredentials") == true) 
                {
                    int DirectoryCount = Directory.GetDirectories(Application.StartupPath + "\\Application_Data\\SealedCredentials").Length;
                    if (DirectoryCount == 0)
                    {
                        CreateSealedSession();
                        MessageBox.Show("For your reference, these information will be available to you locally." +
                            Environment.NewLine +
                            "The sealed credentials(db name, db user name, db user password) are all in bytes array" +
                            " format or in base64 encoded string",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("You need to delete the existing sealed session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else 
                {
                    CreateSealedSession();
                    MessageBox.Show("For your reference, these information will be available to you locally." +
                        Environment.NewLine +
                        "The sealed credentials(db name, db user name, db user password) are all in bytes array" +
                        " format or in base64 encoded string",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else 
            {
                MessageBox.Show("You need to buy database from merchant", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnClosing(object sender, EventArgs e)
        {
            MainFormHolder.myForm.Show();
            MainFormHolder.OpenMainForm = true;
        }
    }
}
