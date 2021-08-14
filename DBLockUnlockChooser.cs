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
using PriSecDBClientPanel.Helper;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PriSecDBClientPanel
{
    public partial class DBLockUnlockChooser : Form
    {
        public DBLockUnlockChooser()
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

        public void LockDBAccount(String Base64RandomChallenge,Boolean LockAccount=true) 
        {
            Byte[] ClientLoginED25519SK = new Byte[] { };
            Byte[] RandomChallenge = Convert.FromBase64String(Base64RandomChallenge);
            Byte[] SignedRandomChallenge = new Byte[] { };
            String SealedDBUserName = "";
            String UniquePaymentID = "";
            Boolean ServerOnlineChecker = true;
            String[] SubDirectories = new String[] { };
            SubDirectories = Directory.GetDirectories(Application.StartupPath + "\\Application_Data\\SealedCredentials\\");
            String SealedSessionID = SubDirectories[0].Remove(0, (Application.StartupPath + "\\Application_Data\\SealedCredentials\\").Length);
            LockDBAccountModel MyLockModel = new LockDBAccountModel();
            String JSONBodyString = "";
            if (SealedSessionID != null && SealedSessionID.CompareTo("") != 0)
            {
                ClientLoginED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\LoginED25519SK.txt");
                SignedRandomChallenge = SodiumPublicKeyAuth.Sign(RandomChallenge, ClientLoginED25519SK);
                UniquePaymentID = File.ReadAllText(Application.StartupPath + "\\Application_Data\\" + "DBCredentials\\PaymentID.txt");
                SealedDBUserName = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBUserNameB64.txt");
                MyLockModel.SealedDBUserName = SealedDBUserName;
                MyLockModel.SealedSessionID = SealedSessionID;
                MyLockModel.SignedRandomChallenge = Convert.ToBase64String(SignedRandomChallenge);
                MyLockModel.UniquePaymentID = UniquePaymentID;
                JSONBodyString=JsonConvert.SerializeObject(MyLockModel);
                StringContent PostRequestData = new StringContent(JSONBodyString, Encoding.UTF8, "application/json");
                using (var client = new HttpClient())
                {
                    if (LockAccount == true) 
                    {
                        client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("LockDBAccount/", PostRequestData);
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

                                var Result = readTask.Result;
                                Result = Result.Substring(1, Result.Length - 2);
                                if (Result.Contains("Error"))
                                {
                                    MessageBox.Show("Something went wrong when requesting feedback from server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    MessageBox.Show(Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("You have locked the db account", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    else 
                    {
                        client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("UnlockDBAccount/", PostRequestData);
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

                                var Result = readTask.Result;
                                Result = Result.Substring(1, Result.Length - 2);
                                if (Result.Contains("Error"))
                                {
                                    MessageBox.Show("Something went wrong when requesting feedback from server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    MessageBox.Show("Request Error Message: " + Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("You have unlocked the db account", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            else
            {
                MessageBox.Show("You have not yet establish an ephemeral TLS session with the server..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LockDBAccountBTN_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\Application_Data\\SealedCredentials\\")==true && Directory.Exists(Application.StartupPath + "\\Application_Data\\" + "DBCredentials") == true) 
            {
                String Base64RandomChallenge = "";
                RequestChallenge(ref Base64RandomChallenge);
                LockDBAccount(Base64RandomChallenge);
            }
        }

        private void UnlockDBAccountBTN_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\Application_Data\\SealedCredentials\\") == true && Directory.Exists(Application.StartupPath + "\\Application_Data\\" + "DBCredentials") == true)
            {
                String Base64RandomChallenge = "";
                RequestChallenge(ref Base64RandomChallenge);
                LockDBAccount(Base64RandomChallenge,false);
            }
        }

        private void OnClosing(object sender, EventArgs e)
        {
            MainFormHolder.myForm.Show();
            MainFormHolder.OpenMainForm = true;
        }
    }
}
