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
using System.IO;
using PriSecDBClientPanel.Helper;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PriSecDBClientPanel
{
    public partial class CreateSealedCredentialsChooser : Form
    {
        public CreateSealedCredentialsChooser()
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

        public void DeleteCredentials(String Base64RandomChallenge)
        {
            Byte[] ClientLoginED25519SK = new Byte[] { };
            Byte[] RandomChallenge = Convert.FromBase64String(Base64RandomChallenge);
            Byte[] SignedRandomChallenge = new Byte[] { };
            String UniquePaymentID = "";
            Boolean ServerOnlineChecker = true;
            String[] SubDirectories = new String[] { };
            SubDirectories = Directory.GetDirectories(Application.StartupPath + "\\Application_Data\\SealedCredentials\\");
            String SealedSessionID = "";
            SealedSessionID = SubDirectories[0].Remove(0, (Application.StartupPath + "\\Application_Data\\SealedCredentials\\").Length);
            if (SealedSessionID != null && SealedSessionID.CompareTo("") != 0)
            {
                ClientLoginED25519SK = File.ReadAllBytes(Application.StartupPath + "\\Application_Data\\" + "SignatureStorage\\LoginED25519SK.txt");
                SignedRandomChallenge = SodiumPublicKeyAuth.Sign(RandomChallenge, ClientLoginED25519SK,true);
                UniquePaymentID = File.ReadAllText(Application.StartupPath + "\\Application_Data\\" + "DBCredentials\\PaymentID.txt");
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("EstablishSealedBoxDBCredentials/DeleteSealedSession?ClientPathID="
                        + SealedSessionID
                        + "&UniquePaymentID="
                        + UniquePaymentID
                        + "&SignedRandomChallenge="
                        + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(SignedRandomChallenge)));
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
                                Directory.Delete(Application.StartupPath + "\\Application_Data\\SealedCredentials", true);
                                MessageBox.Show("You have successfully deleted the sealed session", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CreateCredentialsBTN_Click(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = false;
            CreateSealedDBCredentials NewForm = new CreateSealedDBCredentials();
            NewForm.Show();
            this.Close();
        }

        private void DeleteCredentialsBTN_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\Application_Data\\SealedCredentials") == true && Directory.Exists(Application.StartupPath + "\\Application_Data\\" + "DBCredentials") == true)
            {
                String Base64RandomChallenge = "";
                RequestChallenge(ref Base64RandomChallenge);
                DeleteCredentials(Base64RandomChallenge);
            }
        }

        private void OnClosing(object sender, EventArgs e)
        {
            if (MainFormHolder.OpenMainForm == true)
            {
                MainFormHolder.myForm.Show();
                MainFormHolder.OpenMainForm = false;
            }
        }
    }
}
