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
    public partial class DBInsertDemo : Form
    {
        public DBInsertDemo()
        {
            InitializeComponent();
        }

        void InsertDBRecord(String QueryString, String[] ParameterNameArray, String[] ParameterValueArray, Boolean IsSealedDiffieHellman , Boolean IsXSalsa20Poly1305,ref String SampleJSONString, ref NormalDBInsertModel ReferenceModel, Boolean IsDebug = true)
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
            NormalDBInsertModel MyInsertModel = new NormalDBInsertModel();
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
            if((ParameterNameArrayCount == ParameterValueArrayCount)==true && ParameterNameArrayCount!=0 && ParameterValueArrayCount != 0) 
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
                MyInsertModel.MyDBCredentialModel = new SealedDBCredentialModel();
                MyInsertModel.MyDBCredentialModel.SealedDBName = SealedDBName;
                MyInsertModel.MyDBCredentialModel.SealedDBUserName = SealedDBUserName;
                MyInsertModel.MyDBCredentialModel.SealedDBUserPassword = SealedDBUserPassword;
                MyInsertModel.MyDBCredentialModel.SealedSessionID = SealedSessionID;
                MyInsertModel.UniquePaymentID = UniquePaymentID;
                MyInsertModel.Base64QueryString = Base64QueryString;
                MyInsertModel.Base64ParameterName = Base64ParameterNameArray;
                MyInsertModel.Base64ParameterValue = Base64ParameterValueArray;
                MyInsertModel.ForeignKeyID = null;
                MyInsertModel.IsPrimaryKeyTable = true;
                MyInsertModel.IsXSalsa20Poly1305 = IsXSalsa20Poly1305;
                JSONBodyString = JsonConvert.SerializeObject(MyInsertModel);
                if (IsDebug == true) 
                {
                    SampleJSONString = JSONBodyString;
                }
                PostRequestData = new StringContent(JSONBodyString, Encoding.UTF8, "application/json");
                ReferenceModel = MyInsertModel;
                if (IsSealedDiffieHellman == true) 
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("NormalSealedDHDBInsert/", PostRequestData);
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
                                    MessageBox.Show("You have inserted db table record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        var response = client.PostAsync("NormalSealedX3DHDBInsert/", PostRequestData);
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
                                    MessageBox.Show("You have inserted a db table record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Parameter name array length and parameter value array length must be exactly the same and can't be 0","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        void InsertForeignKeyDBRecord(String QueryString, String[] ParameterNameArray, String[] ParameterValueArray, String ForeignKeyValue ,Boolean IsSealedDiffieHellman, Boolean IsXSalsa20Poly1305, ref String SampleJSONString, ref NormalDBInsertModel ReferenceModel, Boolean IsDebug = true)
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
            NormalDBInsertModel MyInsertModel = new NormalDBInsertModel();
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
            if ((ParameterNameArrayCount == ParameterValueArrayCount) == true && ParameterNameArrayCount != 0 && ParameterValueArrayCount != 0)
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
                MyInsertModel.MyDBCredentialModel = new SealedDBCredentialModel();
                MyInsertModel.MyDBCredentialModel.SealedDBName = SealedDBName;
                MyInsertModel.MyDBCredentialModel.SealedDBUserName = SealedDBUserName;
                MyInsertModel.MyDBCredentialModel.SealedDBUserPassword = SealedDBUserPassword;
                MyInsertModel.MyDBCredentialModel.SealedSessionID = SealedSessionID;
                MyInsertModel.UniquePaymentID = UniquePaymentID;
                MyInsertModel.Base64QueryString = Base64QueryString;
                MyInsertModel.Base64ParameterName = Base64ParameterNameArray;
                MyInsertModel.Base64ParameterValue = Base64ParameterValueArray;
                MyInsertModel.ForeignKeyID = ForeignKeyValue;
                MyInsertModel.IsPrimaryKeyTable = false;
                MyInsertModel.IsXSalsa20Poly1305 = IsXSalsa20Poly1305;
                JSONBodyString = JsonConvert.SerializeObject(MyInsertModel);
                if (IsDebug == true)
                {
                    SampleJSONString = JSONBodyString;
                }
                PostRequestData = new StringContent(JSONBodyString, Encoding.UTF8, "application/json");
                ReferenceModel = MyInsertModel;
                if (IsSealedDiffieHellman == true)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://mrchewitsoftware.com.my:5002/api/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.PostAsync("NormalSealedDHDBInsert/", PostRequestData);
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
                                    MessageBox.Show("You have inserted a db table record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        var response = client.PostAsync("NormalSealedX3DHDBInsert/", PostRequestData);
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
                                    MessageBox.Show("You have inserted a db table record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                WebAPIURLTB.Text = "https://mrchewitsoftware.com.my:5002/NormalSealedDHDBInsert/";
            }
            else 
            {
                WebAPIURLTB.Text = "https://mrchewitsoftware.com.my:5002/NormalSealedX3DHDBInsert/";
            }
        }

        private void InsertRecordBTN_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(Application.StartupPath + "\\Application_Data\\SealedCredentials\\") ==true && Directory.Exists(Application.StartupPath + "\\Application_Data\\DBCredentials\\") == true) 
            {
                String ForeignKeyValue = "";
                String QueryString = "";
                String ParameterName = "";
                String[] ParameterNameArray = new String[] { };
                String ParameterValue = "";
                String[] ParameterValueArray = new String[] { };
                String SampleJSONString = "";
                NormalDBInsertModel MyInsertModel = new NormalDBInsertModel();
                Boolean IsSealedDiffieHellman = true;
                Boolean IsXSalsa20Poly1305 = true;
                if (SQLQueryStringTB.Text != null && SQLQueryStringTB.Text.CompareTo("") != 0 && SQLParameterNameArrayTB.Text != null && SQLParameterNameArrayTB.Text.CompareTo("") != 0 && SQLParameterValueArrayTB.Text != null && SQLParameterValueArrayTB.Text.CompareTo("") != 0)
                {
                    if (IsPrimaryKeyTableCB.Checked == true) 
                    {
                        QueryString = SQLQueryStringTB.Text;
                        ParameterName = SQLParameterNameArrayTB.Text;
                        ParameterValue = SQLParameterValueArrayTB.Text;
                        ParameterNameArray = ParameterName.Split(',');
                        ParameterValueArray = ParameterValue.Split(',');
                        IsSealedDiffieHellman = SealedDiffieHellmanRB.Checked;
                        IsXSalsa20Poly1305 = XSalsa20Poly1305RB.Checked;
                        InsertDBRecord(QueryString, ParameterNameArray, ParameterValueArray, IsSealedDiffieHellman, IsXSalsa20Poly1305, ref SampleJSONString, ref MyInsertModel);
                        UniquePaymentIDTB.Text = MyInsertModel.UniquePaymentID;
                        SealedSessionIDTB.Text = MyInsertModel.MyDBCredentialModel.SealedSessionID;
                        SealedDBNameTB.Text = MyInsertModel.MyDBCredentialModel.SealedDBName;
                        SealedDBUserNameTB.Text = MyInsertModel.MyDBCredentialModel.SealedDBUserName;
                        SealedDBUserPasswordTB.Text = MyInsertModel.MyDBCredentialModel.SealedDBUserPassword;
                        SampleJSONStringTB.Text = SampleJSONString;
                    }
                    else 
                    {
                        if (IsPrimaryKeyTableCB.Checked == false)
                        {
                            if (ForeignKeyValueTB.ReadOnly == false) 
                            {
                                if(ForeignKeyValueTB.Text!=null && ForeignKeyValueTB.Text.CompareTo("") != 0) 
                                {
                                    ForeignKeyValue = ForeignKeyValueTB.Text;
                                    QueryString = SQLQueryStringTB.Text;
                                    ParameterName = SQLParameterNameArrayTB.Text;
                                    ParameterValue = SQLParameterValueArrayTB.Text;
                                    ParameterNameArray = ParameterName.Split(',');
                                    ParameterValueArray = ParameterValue.Split(',');
                                    IsSealedDiffieHellman = SealedDiffieHellmanRB.Checked;
                                    IsXSalsa20Poly1305 = XSalsa20Poly1305RB.Checked;
                                    InsertForeignKeyDBRecord(QueryString, ParameterNameArray, ParameterValueArray, ForeignKeyValue ,IsSealedDiffieHellman, IsXSalsa20Poly1305, ref SampleJSONString, ref MyInsertModel);
                                    UniquePaymentIDTB.Text = MyInsertModel.UniquePaymentID;
                                    SealedSessionIDTB.Text = MyInsertModel.MyDBCredentialModel.SealedSessionID;
                                    SealedDBNameTB.Text = MyInsertModel.MyDBCredentialModel.SealedDBName;
                                    SealedDBUserNameTB.Text = MyInsertModel.MyDBCredentialModel.SealedDBUserName;
                                    SealedDBUserPasswordTB.Text = MyInsertModel.MyDBCredentialModel.SealedDBUserPassword;
                                    SampleJSONStringTB.Text = SampleJSONString;
                                }
                                else 
                                {
                                    MessageBox.Show("Please specify a foreign key value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else 
                            {
                                MessageBox.Show("Entering of foreign key value was disabled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Please specify whether it's a primary key table or not", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void IsPrimaryKeyTableCB_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPrimaryKeyTableCB.Checked == true) 
            {
                ForeignKeyValueTB.ReadOnly = true;
            }
            else 
            {
                ForeignKeyValueTB.ReadOnly = false;
            }
        }

        private void OnClosing(object sender, EventArgs e)
        {
            MainFormHolder.OpenMainForm = true;
            MainFormHolder.myForm.Show();
        }
    }
}
