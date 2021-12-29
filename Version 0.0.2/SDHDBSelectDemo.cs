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
    public partial class SDHDBSelectDemo : Form
    {
        public SDHDBSelectDemo()
        {
            InitializeComponent();
        }

        void SelectDBRecord(String QueryString, String ParameterName, String ParameterValue, ref String SampleJSONString, ref NormalDBModel ReferenceModel, Boolean IsDebug = true)
        {
            String SealedSessionID = "";
            String SealedDBName = "";
            String SealedDBUserName = "";
            String SealedDBUserPassword = "";
            String UniquePaymentID = "";
            Byte[] QueryStringByte = new Byte[] { };
            String Base64QueryString = "";
            Byte[] ParameterNameByte = new Byte[] { };
            String Base64ParameterName = "";
            Byte[] ParameterValueByte = new Byte[] { };
            String Base64ParameterValue = "";
            String JSONBodyString = "";
            Boolean ServerOnlineChecker = true;
            NormalDBModel MySelectModel = new NormalDBModel();
            DBRecordsModel MyRecordsModel = new DBRecordsModel();
            Byte[] RecipientECDHSKByte = new Byte[] { };
            Byte[] RecipientECDHPKByte = new Byte[] { };
            Byte[] ConcatedPublicKeyByte = new Byte[] { };
            Byte[] NonceByte = new Byte[] { };
            Byte[] SharedSecret = new Byte[] { };
            Byte[] SealedValueByte = new Byte[] { };
            Byte[] SanitizedSealedValueByte = new Byte[] { };
            Byte[] ServerPublicKeyByte = new Byte[] { };
            Byte[] DecryptedValueByte = new Byte[] { };
            String DecryptedValue = "";
            String SealedValueResult = "";
            String DecryptedValueResult = "";
            Boolean IsSealedBox = true;
            String[] SubDirectories = new String[] { };
            int LoopCount = 0;
            SubDirectories = Directory.GetDirectories(Application.StartupPath + "\\Application_Data\\SealedCredentials\\");
            SealedSessionID = SubDirectories[0].Remove(0, (Application.StartupPath + "\\Application_Data\\SealedCredentials\\").Length);
            SealedDBName = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBNameB64.txt");
            SealedDBUserName = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBUserNameB64.txt");
            SealedDBUserPassword = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBUserPasswordB64.txt");
            UniquePaymentID = File.ReadAllText(Application.StartupPath + "\\Application_Data\\DBCredentials\\PaymentID.txt");
            QueryStringByte = Encoding.UTF8.GetBytes(QueryString);
            ParameterNameByte = Encoding.UTF8.GetBytes(ParameterName);
            ParameterValueByte = Encoding.UTF8.GetBytes(ParameterValue);
            Base64QueryString = Convert.ToBase64String(QueryStringByte);
            Base64ParameterName = Convert.ToBase64String(ParameterNameByte);
            Base64ParameterValue = Convert.ToBase64String(ParameterValueByte);
            MySelectModel.MyDBCredentialModel = new SealedDBCredentialModel();
            MySelectModel.MyDBCredentialModel.SealedDBName = SealedDBName;
            MySelectModel.MyDBCredentialModel.SealedDBUserName = SealedDBUserName;
            MySelectModel.MyDBCredentialModel.SealedDBUserPassword = SealedDBUserPassword;
            MySelectModel.MyDBCredentialModel.SealedSessionID = SealedSessionID;
            MySelectModel.UniquePaymentID = UniquePaymentID;
            MySelectModel.Base64QueryString = Base64QueryString;
            MySelectModel.Base64ParameterName = Base64ParameterName;
            MySelectModel.Base64ParameterValue = Base64ParameterValue;
            ReferenceModel = MySelectModel;
            JSONBodyString = JsonConvert.SerializeObject(MySelectModel);
            if (IsDebug == true)
            {
                SampleJSONString = JSONBodyString;
            }
            StringContent PostRequestData = new StringContent(JSONBodyString, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync("SelectDBRecord/", PostRequestData);
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
                        MyRecordsModel = JsonConvert.DeserializeObject<DBRecordsModel>(Result);
                        if (MyRecordsModel.Status.Contains("Error"))
                        {
                            MessageBox.Show("Something went wrong when requesting feedback from server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(MyRecordsModel.Status, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            RecipientECDHPKByte = File.ReadAllBytes(Application.StartupPath + "\\Application_Data\\DHStorage\\SealedDHX25519PK.txt");
                            while (LoopCount < MyRecordsModel.ParameterValues.Length) 
                            {
                                SealedValueByte = Convert.FromBase64String(MyRecordsModel.ParameterValues[LoopCount]);
                                RecipientECDHSKByte = File.ReadAllBytes(Application.StartupPath + "\\Application_Data\\DHStorage\\SealedDHX25519SK.txt");
                                try
                                {
                                    DecryptedValueByte = SodiumSealedPublicKeyBox.Open(SealedValueByte,RecipientECDHPKByte,RecipientECDHSKByte,true);
                                }
                                catch 
                                {
                                    IsSealedBox = false;
                                }
                                if (IsSealedBox == false) 
                                {
                                    ServerPublicKeyByte = new Byte[32];
                                    Array.Copy(SealedValueByte, 0, ServerPublicKeyByte, 0, 32);
                                    SanitizedSealedValueByte = new Byte[SealedValueByte.Length-32];
                                    Array.Copy(SealedValueByte, 32, SanitizedSealedValueByte, 0, SanitizedSealedValueByte.Length);
                                    RecipientECDHSKByte = File.ReadAllBytes(Application.StartupPath + "\\Application_Data\\DHStorage\\SealedDHX25519SK.txt");
                                    SharedSecret = SodiumScalarMult.Mult(RecipientECDHSKByte, ServerPublicKeyByte,true);
                                    ConcatedPublicKeyByte = ServerPublicKeyByte.Concat(RecipientECDHPKByte).ToArray();
                                    NonceByte = SodiumKDF.KDFFunction((uint)SodiumSecretBoxXChaCha20Poly1305.GenerateNonce().Length, 1, "GetNonce", ConcatedPublicKeyByte);
                                    DecryptedValueByte = SodiumSecretBoxXChaCha20Poly1305.Open(SanitizedSealedValueByte, NonceByte, SharedSecret,true);
                                    DecryptedValue = Encoding.UTF8.GetString(DecryptedValueByte);
                                }
                                else 
                                {
                                    DecryptedValue = Encoding.UTF8.GetString(DecryptedValueByte);
                                }
                                if((LoopCount+1) == MyRecordsModel.ParameterValues.Length) 
                                {
                                    DecryptedValueResult += DecryptedValue;
                                    SealedValueResult += MyRecordsModel.ParameterValues[LoopCount];
                                }
                                else 
                                {
                                    DecryptedValueResult += DecryptedValue + Environment.NewLine;
                                    SealedValueResult += MyRecordsModel.ParameterValues[LoopCount] + Environment.NewLine;
                                }
                                LoopCount += 1;
                            }
                            if (Directory.Exists(Application.StartupPath + "\\Application_Data\\FetchOrDecrypted") == false) 
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Application_Data\\FetchOrDecrypted");
                            }
                            File.WriteAllText(Application.StartupPath + "\\Application_Data\\FetchOrDecrypted\\Fetch.txt", SealedValueResult);
                            File.WriteAllText(Application.StartupPath + "\\Application_Data\\FetchOrDecrypted\\Decrypted.txt", DecryptedValueResult);
                            File.WriteAllText(Application.StartupPath + "\\Application_Data\\FetchOrDecrypted\\JSONData.txt", Result);
                            MessageBox.Show("You have selected some db table record, please go to the software's 'Application_Data\\FetchOrDecrypted' folder to see the results", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void SpecialSelectDBRecord(String QueryString, String[] ParameterName, String[] ParameterValue, ref String SampleJSONString, ref SpecialSelectDBModel ReferenceModel, Boolean IsDebug = true)
        {
            String SealedSessionID = "";
            String SealedDBName = "";
            String SealedDBUserName = "";
            String SealedDBUserPassword = "";
            String UniquePaymentID = "";
            Byte[] QueryStringByte = new Byte[] { };
            String Base64QueryString = "";
            Byte[] ParameterNameByte = new Byte[] { };
            String Base64ParameterName = "";
            String[] Base64ParameterNameArray = new String[ParameterName.Length];
            Byte[] ParameterValueByte = new Byte[] { };
            String Base64ParameterValue = "";
            String[] Base64ParameterValueArray = new String[ParameterValue.Length];
            String JSONBodyString = "";
            Boolean ServerOnlineChecker = true;
            SpecialSelectDBModel MySelectModel = new SpecialSelectDBModel();
            DBRecordsModel MyRecordsModel = new DBRecordsModel();
            Byte[] RecipientECDHSKByte = new Byte[] { };
            Byte[] RecipientECDHPKByte = new Byte[] { };
            Byte[] ConcatedPublicKeyByte = new Byte[] { };
            Byte[] NonceByte = new Byte[] { };
            Byte[] SharedSecret = new Byte[] { };
            Byte[] SealedValueByte = new Byte[] { };
            Byte[] SanitizedSealedValueByte = new Byte[] { };
            Byte[] ServerPublicKeyByte = new Byte[] { };
            Byte[] DecryptedValueByte = new Byte[] { };
            String DecryptedValue = "";
            String SealedValueResult = "";
            String DecryptedValueResult = "";
            Boolean IsSealedBox = true;
            String[] SubDirectories = new String[] { };
            int LoopCount = 0;
            SubDirectories = Directory.GetDirectories(Application.StartupPath + "\\Application_Data\\SealedCredentials\\");
            SealedSessionID = SubDirectories[0].Remove(0, (Application.StartupPath + "\\Application_Data\\SealedCredentials\\").Length);
            SealedDBName = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBNameB64.txt");
            SealedDBUserName = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBUserNameB64.txt");
            SealedDBUserPassword = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBUserPasswordB64.txt");
            UniquePaymentID = File.ReadAllText(Application.StartupPath + "\\Application_Data\\DBCredentials\\PaymentID.txt");
            QueryStringByte = Encoding.UTF8.GetBytes(QueryString);
            while (LoopCount < ParameterName.Length)
            {
                ParameterNameByte = Encoding.UTF8.GetBytes(ParameterName[LoopCount]);
                ParameterValueByte = Encoding.UTF8.GetBytes(ParameterValue[LoopCount]);
                Base64ParameterName = Convert.ToBase64String(ParameterNameByte);
                Base64ParameterValue = Convert.ToBase64String(ParameterValueByte);
                Base64ParameterNameArray[LoopCount] = Base64ParameterName;
                Base64ParameterValueArray[LoopCount] = Base64ParameterValue;
                LoopCount += 1;
            }
            LoopCount = 0;
            Base64QueryString = Convert.ToBase64String(QueryStringByte);
            MySelectModel.MyDBCredentialModel = new SealedDBCredentialModel();
            MySelectModel.MyDBCredentialModel.SealedDBName = SealedDBName;
            MySelectModel.MyDBCredentialModel.SealedDBUserName = SealedDBUserName;
            MySelectModel.MyDBCredentialModel.SealedDBUserPassword = SealedDBUserPassword;
            MySelectModel.MyDBCredentialModel.SealedSessionID = SealedSessionID;
            MySelectModel.UniquePaymentID = UniquePaymentID;
            MySelectModel.Base64QueryString = Base64QueryString;
            MySelectModel.Base64ParameterName = Base64ParameterNameArray;
            MySelectModel.Base64ParameterValue = Base64ParameterValueArray;
            ReferenceModel = MySelectModel;
            JSONBodyString = JsonConvert.SerializeObject(MySelectModel);
            if (IsDebug == true)
            {
                SampleJSONString = JSONBodyString;
            }
            StringContent PostRequestData = new StringContent(JSONBodyString, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync("SpecialSelectDBRecord/", PostRequestData);
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
                        MyRecordsModel = JsonConvert.DeserializeObject<DBRecordsModel>(Result);
                        if (MyRecordsModel.Status.Contains("Error"))
                        {
                            MessageBox.Show("Something went wrong when requesting feedback from server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(MyRecordsModel.Status, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            RecipientECDHPKByte = File.ReadAllBytes(Application.StartupPath + "\\Application_Data\\DHStorage\\SealedDHX25519PK.txt");
                            while (LoopCount < MyRecordsModel.ParameterValues.Length)
                            {
                                SealedValueByte = Convert.FromBase64String(MyRecordsModel.ParameterValues[LoopCount]);
                                RecipientECDHSKByte = File.ReadAllBytes(Application.StartupPath + "\\Application_Data\\DHStorage\\SealedDHX25519SK.txt");
                                try
                                {
                                    DecryptedValueByte = SodiumSealedPublicKeyBox.Open(SealedValueByte, RecipientECDHPKByte, RecipientECDHSKByte,true);
                                }
                                catch
                                {
                                    IsSealedBox = false;
                                }
                                if (IsSealedBox == false)
                                {
                                    ServerPublicKeyByte = new Byte[32];
                                    Array.Copy(SealedValueByte, 0, ServerPublicKeyByte, 0, 32);
                                    SanitizedSealedValueByte = new Byte[SealedValueByte.Length - 32];
                                    Array.Copy(SealedValueByte, 32, SanitizedSealedValueByte, 0, SanitizedSealedValueByte.Length);
                                    RecipientECDHSKByte = File.ReadAllBytes(Application.StartupPath + "\\Application_Data\\DHStorage\\SealedDHX25519SK.txt");
                                    SharedSecret = SodiumScalarMult.Mult(RecipientECDHSKByte, ServerPublicKeyByte,true);
                                    ConcatedPublicKeyByte = ServerPublicKeyByte.Concat(RecipientECDHPKByte).ToArray();
                                    NonceByte = SodiumKDF.KDFFunction((uint)SodiumSecretBoxXChaCha20Poly1305.GenerateNonce().Length, 1, "GetNonce", ConcatedPublicKeyByte);
                                    DecryptedValueByte = SodiumSecretBoxXChaCha20Poly1305.Open(SanitizedSealedValueByte, NonceByte, SharedSecret,true);
                                    DecryptedValue = Encoding.UTF8.GetString(DecryptedValueByte);
                                }
                                else
                                {
                                    DecryptedValue = Encoding.UTF8.GetString(DecryptedValueByte);
                                }
                                if ((LoopCount + 1) == MyRecordsModel.ParameterValues.Length)
                                {
                                    DecryptedValueResult += DecryptedValue;
                                    SealedValueResult += MyRecordsModel.ParameterValues[LoopCount];
                                }
                                else
                                {
                                    DecryptedValueResult += DecryptedValue + Environment.NewLine;
                                    SealedValueResult += MyRecordsModel.ParameterValues[LoopCount] + Environment.NewLine;
                                }
                                LoopCount += 1;
                            }
                            if (Directory.Exists(Application.StartupPath + "\\Application_Data\\FetchOrDecrypted") == false)
                            {
                                Directory.CreateDirectory(Application.StartupPath + "\\Application_Data\\FetchOrDecrypted");
                            }
                            File.WriteAllText(Application.StartupPath + "\\Application_Data\\FetchOrDecrypted\\Fetch.txt", SealedValueResult);
                            File.WriteAllText(Application.StartupPath + "\\Application_Data\\FetchOrDecrypted\\Decrypted.txt", DecryptedValueResult);
                            File.WriteAllText(Application.StartupPath + "\\Application_Data\\FetchOrDecrypted\\JSONData.txt", Result);
                            MessageBox.Show("You have selected some db table record, please go to the software's 'Application_Data\\FetchOrDecrypted' folder to see the results", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void SelectRecordBTN_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\Application_Data\\SealedCredentials\\") == true && Directory.Exists(Application.StartupPath + "\\Application_Data\\DBCredentials\\") == true)
            {
                String QueryString = "";
                String ParameterName = "";
                String[] ParameterNameArray = new String[] { };
                String ParameterValue = "";
                String[] ParameterValueArray = new String[] { };
                String SampleJSONString = "";
                NormalDBModel MyReferenceModel = new NormalDBModel();
                SpecialSelectDBModel MySpecialSelectDBModel = new SpecialSelectDBModel();
                if (SQLQueryStringTB.Text != null && SQLQueryStringTB.Text.CompareTo("") != 0 && SQLParameterNameTB.Text != null && SQLParameterNameTB.Text.CompareTo("") != 0 && SQLParameterValueTB.Text != null && SQLParameterValueTB.Text.CompareTo("") != 0)
                {
                    if (SQLParameterNameTB.Text.Contains(",") == true && SQLParameterValueTB.Text.Contains(",") == true)
                    {
                        SQLParameterNameB64TB.Text = "";
                        SQLParameterValueB64TB.Text = "";
                        WebAPIURLTB.Text = "https://mrchewitsoftware.com.my:5002/api/SpecialSelectDBRecord/";
                        QueryString = SQLQueryStringTB.Text;
                        ParameterName = SQLParameterNameTB.Text;
                        ParameterValue = SQLParameterValueTB.Text;
                        ParameterNameArray = ParameterName.Split(',');
                        ParameterValueArray = ParameterValue.Split(',');
                        SpecialSelectDBRecord(QueryString, ParameterNameArray, ParameterValueArray, ref SampleJSONString, ref MySpecialSelectDBModel);
                        SQLQueryStringB64TB.Text = MySpecialSelectDBModel.Base64QueryString;
                        UniquePaymentIDTB.Text = MySpecialSelectDBModel.UniquePaymentID;
                        SealedSessionIDTB.Text = MySpecialSelectDBModel.MyDBCredentialModel.SealedSessionID;
                        SealedDBNameTB.Text = MySpecialSelectDBModel.MyDBCredentialModel.SealedDBName;
                        SealedDBUserNameTB.Text = MySpecialSelectDBModel.MyDBCredentialModel.SealedDBUserName;
                        SealedDBUserPasswordTB.Text = MySpecialSelectDBModel.MyDBCredentialModel.SealedDBUserPassword;
                        SampleJSONStringTB.Text = SampleJSONString;
                    }
                    else
                    {
                        WebAPIURLTB.Text = "https://mrchewitsoftware.com.my:5002/api/SelectDBRecord/";
                        QueryString = SQLQueryStringTB.Text;
                        ParameterName = SQLParameterNameTB.Text;
                        ParameterValue = SQLParameterValueTB.Text;
                        SelectDBRecord(QueryString, ParameterName, ParameterValue, ref SampleJSONString, ref MyReferenceModel);
                        SQLQueryStringB64TB.Text = MyReferenceModel.Base64QueryString;
                        SQLParameterNameB64TB.Text = MyReferenceModel.Base64ParameterName;
                        SQLParameterValueB64TB.Text = MyReferenceModel.Base64ParameterValue;
                        UniquePaymentIDTB.Text = MyReferenceModel.UniquePaymentID;
                        SealedSessionIDTB.Text = MyReferenceModel.MyDBCredentialModel.SealedSessionID;
                        SealedDBNameTB.Text = MyReferenceModel.MyDBCredentialModel.SealedDBName;
                        SealedDBUserNameTB.Text = MyReferenceModel.MyDBCredentialModel.SealedDBUserName;
                        SealedDBUserPasswordTB.Text = MyReferenceModel.MyDBCredentialModel.SealedDBUserPassword;
                        SampleJSONStringTB.Text = SampleJSONString;
                    }
                }
                else
                {
                    MessageBox.Show("SQL Query String,Parameter Name,Parameter Value must not be null or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have not yet establish a sealed session or make payment yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnClosing(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = true;
            MainFormHolder.myForm.Show();
        }
    }
}
