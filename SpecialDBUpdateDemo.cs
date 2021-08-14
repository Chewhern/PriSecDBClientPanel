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
using System.IO;
using PriSecDBClientPanel.Helper;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PriSecDBClientPanel
{
    public partial class SpecialDBUpdateDemo : Form
    {
        public SpecialDBUpdateDemo()
        {
            InitializeComponent();
        }

        void UpdateDBRecord(String QueryString, String[] ParameterNameArray, String[] ParameterValueArray, String[] IDValue, String[] NewIDValue ,Boolean IsSealedDiffieHellman, Boolean IsXSalsa20Poly1305, ref String SampleJSONString, ref SpecialDBModel ReferenceModel, Boolean IsDebug = true)
        {
            int ParameterNameArrayCount = 0;
            int ParameterValueArrayCount = 0;
            int LoopCount = 0;
            String SealedSessionID = "";
            String SealedDBName = "";
            String SealedDBUserName = "";
            String SealedDBUserPassword = "";
            String UniquePaymentID = "";
            Byte[] QueryStringByte = new Byte[] { };
            String Base64QueryString = "";
            Byte[] ParameterNameByte = new Byte[] { };
            String Base64ParameterName = "";
            String[] Base64ParameterNameArray = new String[] { };
            Byte[] ParameterValueByte = new Byte[] { };
            String Base64ParameterValue = "";
            String[] Base64ParameterValueArray = new String[] { };
            String JSONBodyString = "";
            Boolean ServerOnlineChecker = true;
            SpecialDBModel MySpecialDBModel = new SpecialDBModel();
            StringContent PostRequestData = new StringContent("");
            String[] SubDirectories = new String[] { };
            SubDirectories = Directory.GetDirectories(Application.StartupPath + "\\Application_Data\\SealedCredentials\\");
            SealedSessionID = SubDirectories[0].Remove(0, (Application.StartupPath + "\\Application_Data\\SealedCredentials\\").Length);
            SealedDBName = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBNameB64.txt");
            SealedDBUserName = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBUserNameB64.txt");
            SealedDBUserPassword = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBUserPasswordB64.txt");
            UniquePaymentID = File.ReadAllText(Application.StartupPath + "\\Application_Data\\DBCredentials\\PaymentID.txt");
            QueryStringByte = Encoding.UTF8.GetBytes(QueryString);
            Base64QueryString = Convert.ToBase64String(QueryStringByte);
            ParameterNameArrayCount = ParameterNameArray.Length;
            ParameterValueArrayCount = ParameterValueArray.Length;
            if ((ParameterNameArrayCount == ParameterValueArrayCount) == true)
            {
                Base64ParameterNameArray = new String[ParameterNameArrayCount];
                Base64ParameterValueArray = new String[ParameterValueArrayCount];
                while (LoopCount < ParameterNameArrayCount)
                {
                    ParameterNameByte = Encoding.UTF8.GetBytes(ParameterNameArray[LoopCount]);
                    Base64ParameterName = Convert.ToBase64String(ParameterNameByte);
                    ParameterValueByte = Encoding.UTF8.GetBytes(ParameterValueArray[LoopCount]);
                    Base64ParameterValue = Convert.ToBase64String(ParameterValueByte);
                    Base64ParameterNameArray[LoopCount] = Base64ParameterName;
                    Base64ParameterValueArray[LoopCount] = Base64ParameterValue;
                    LoopCount += 1;
                }
                MySpecialDBModel.MyDBCredentialModel = new SealedDBCredentialModel();
                MySpecialDBModel.MyDBCredentialModel.SealedDBName = SealedDBName;
                MySpecialDBModel.MyDBCredentialModel.SealedDBUserName = SealedDBUserName;
                MySpecialDBModel.MyDBCredentialModel.SealedDBUserPassword = SealedDBUserPassword;
                MySpecialDBModel.MyDBCredentialModel.SealedSessionID = SealedSessionID;
                MySpecialDBModel.UniquePaymentID = UniquePaymentID;
                MySpecialDBModel.Base64QueryString = Base64QueryString;
                MySpecialDBModel.Base64ParameterName = Base64ParameterNameArray;
                MySpecialDBModel.Base64ParameterValue = Base64ParameterValueArray;
                MySpecialDBModel.IDValue = IDValue;
                MySpecialDBModel.NewIDValue = NewIDValue;
                MySpecialDBModel.IsXSalsa20Poly1305 = IsXSalsa20Poly1305;
                JSONBodyString = JsonConvert.SerializeObject(MySpecialDBModel);
                if (IsDebug == true)
                {
                    SampleJSONString = JSONBodyString;
                }
                PostRequestData = new StringContent(JSONBodyString, Encoding.UTF8, "application/json");
                ReferenceModel = MySpecialDBModel;
                if (IsSealedDiffieHellman == true)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("SpecialSealedDHDBUpdate/", PostRequestData);
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
                                    SuccessResponseTB.Text = Result;
                                    MessageBox.Show("You have updated db table records by using special ways to do it", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("SpecialSealedX3DHDBUpdate/", PostRequestData);
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
                                    SuccessResponseTB.Text = Result;
                                    MessageBox.Show("You have updated db table records by using special ways to do it", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Parameter name array length and parameter value array length must be exactly the same and can't be 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EncryptionTypeDeterminer(Object sender, EventArgs e)
        {
            if (SealedDiffieHellmanRB.Checked == true)
            {
                WebAPIURLTB.Text = "https://mrchewitsoftware.com.my:5002/SpecialSealedDHDBUpdate/";
            }
            else
            {
                WebAPIURLTB.Text = "https://mrchewitsoftware.com.my:5002/SpecialSealedX3DHDBUpdate/";
            }
        }

        private void UpdateDBRecordBTN_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\Application_Data\\SealedCredentials\\") == true && Directory.Exists(Application.StartupPath + "\\Application_Data\\DBCredentials\\") == true)
            {
                String SQLKeyValue = "";
                String NewSQLKeyValue = "";
                String[] IDValue = new String[] { };
                String[] NewIDValue = new String[] { };
                String QueryString = "";
                String ParameterName = "";
                String[] ParameterNameArray = new String[] { };
                String ParameterValue = "";
                String[] ParameterValueArray = new String[] { };
                String SampleJSONString = "";
                SpecialDBModel MySpecialDBModel = new SpecialDBModel();
                Boolean IsSealedDiffieHellman = true;
                Boolean IsXSalsa20Poly1305 = true;
                if (SQLQueryStringTB.Text != null && SQLQueryStringTB.Text.CompareTo("") != 0)
                {
                    if (SQLParameterNameArrayTB.Text != null && SQLParameterNameArrayTB.Text.CompareTo("") != 0 && SQLParameterValueArrayTB.Text != null && SQLParameterValueArrayTB.Text.CompareTo("") != 0) 
                    {
                        if (SQLKeyValueTB.Text != null && SQLKeyValueTB.Text.CompareTo("") != 0)
                        {
                            SQLKeyValue = SQLKeyValueTB.Text;
                            QueryString = SQLQueryStringTB.Text;
                            ParameterName = SQLParameterNameArrayTB.Text;
                            ParameterValue = SQLParameterValueArrayTB.Text;
                            ParameterNameArray = ParameterName.Split(',');
                            ParameterValueArray = ParameterValue.Split(',');
                            IDValue = SQLKeyValue.Split(',');
                            IsSealedDiffieHellman = SealedDiffieHellmanRB.Checked;
                            IsXSalsa20Poly1305 = XSalsa20Poly1305RB.Checked;
                            UpdateDBRecord(QueryString, ParameterNameArray, ParameterValueArray, IDValue, NewIDValue, IsSealedDiffieHellman, IsXSalsa20Poly1305, ref SampleJSONString, ref MySpecialDBModel);
                            UniquePaymentIDTB.Text = MySpecialDBModel.UniquePaymentID;
                            SealedSessionIDTB.Text = MySpecialDBModel.MyDBCredentialModel.SealedSessionID;
                            SealedDBNameTB.Text = MySpecialDBModel.MyDBCredentialModel.SealedDBName;
                            SealedDBUserNameTB.Text = MySpecialDBModel.MyDBCredentialModel.SealedDBUserName;
                            SealedDBUserPasswordTB.Text = MySpecialDBModel.MyDBCredentialModel.SealedDBUserPassword;
                            SampleJSONStringTB.Text = SampleJSONString;
                        }
                        else
                        {
                            MessageBox.Show("SQL Key Value must not be null or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else 
                    {
                        if (SQLKeyValueTB.Text != null && SQLKeyValueTB.Text.CompareTo("") != 0 && NewSQLKeyValueTB.Text != null && NewSQLKeyValueTB.Text.CompareTo("") != 0)
                        {
                            SQLKeyValue = SQLKeyValueTB.Text;
                            NewSQLKeyValue = NewSQLKeyValueTB.Text;
                            QueryString = SQLQueryStringTB.Text;
                            IDValue = SQLKeyValue.Split(',');
                            NewIDValue = NewSQLKeyValue.Split(',');
                            IsSealedDiffieHellman = SealedDiffieHellmanRB.Checked;
                            IsXSalsa20Poly1305 = XSalsa20Poly1305RB.Checked;
                            UpdateDBRecord(QueryString, ParameterNameArray,ParameterValueArray, IDValue, NewIDValue, IsSealedDiffieHellman, IsXSalsa20Poly1305, ref SampleJSONString, ref MySpecialDBModel);
                            UniquePaymentIDTB.Text = MySpecialDBModel.UniquePaymentID;
                            SealedSessionIDTB.Text = MySpecialDBModel.MyDBCredentialModel.SealedSessionID;
                            SealedDBNameTB.Text = MySpecialDBModel.MyDBCredentialModel.SealedDBName;
                            SealedDBUserNameTB.Text = MySpecialDBModel.MyDBCredentialModel.SealedDBUserName;
                            SealedDBUserPasswordTB.Text = MySpecialDBModel.MyDBCredentialModel.SealedDBUserPassword;
                            SampleJSONStringTB.Text = SampleJSONString;
                        }
                        else
                        {
                            MessageBox.Show("SQL Key Value and New SQL Key Value must not be null or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
