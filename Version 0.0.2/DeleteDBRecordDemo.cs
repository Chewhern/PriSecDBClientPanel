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
    public partial class DeleteDBRecordDemo : Form
    {
        public DeleteDBRecordDemo()
        {
            InitializeComponent();
        }

        void DeleteDBRecord(String QueryString, String ParameterName, String ParameterValue, ref String SampleJSONString, ref NormalDBModel ReferenceModel, Boolean IsDebug = true)
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
            NormalDBModel MyDeleteModel = new NormalDBModel();
            String[] SubDirectories = new String[] { };
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
            MyDeleteModel.MyDBCredentialModel = new SealedDBCredentialModel();
            MyDeleteModel.MyDBCredentialModel.SealedDBName = SealedDBName;
            MyDeleteModel.MyDBCredentialModel.SealedDBUserName = SealedDBUserName;
            MyDeleteModel.MyDBCredentialModel.SealedDBUserPassword = SealedDBUserPassword;
            MyDeleteModel.MyDBCredentialModel.SealedSessionID = SealedSessionID;
            MyDeleteModel.UniquePaymentID = UniquePaymentID;
            MyDeleteModel.Base64QueryString = Base64QueryString;
            MyDeleteModel.Base64ParameterName = Base64ParameterName;
            MyDeleteModel.Base64ParameterValue = Base64ParameterValue;
            ReferenceModel = MyDeleteModel;
            JSONBodyString = JsonConvert.SerializeObject(MyDeleteModel);
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
                var response = client.PostAsync("DeleteDBRecord/", PostRequestData);
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
                            MessageBox.Show("You have deleted db table record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void SpecialDeleteDBRecord(String QueryString, String[] ParameterName, String[] ParameterValue, ref String SampleJSONString, ref SpecialSelectDBModel ReferenceModel, Boolean IsDebug = true)
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
            SpecialSelectDBModel MyDeleteModel = new SpecialSelectDBModel();
            int LoopCount = 0;
            String[] SubDirectories = new String[] { };
            SubDirectories = Directory.GetDirectories(Application.StartupPath + "\\Application_Data\\SealedCredentials\\");
            SealedSessionID = SubDirectories[0].Remove(0, (Application.StartupPath + "\\Application_Data\\SealedCredentials\\").Length);
            SealedDBName = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBNameB64.txt");
            SealedDBUserName = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBUserNameB64.txt");
            SealedDBUserPassword = File.ReadAllText(Application.StartupPath + "\\Application_Data\\SealedCredentials\\" + SealedSessionID + "\\SealedDBUserPasswordB64.txt");
            UniquePaymentID = File.ReadAllText(Application.StartupPath + "\\Application_Data\\DBCredentials\\PaymentID.txt");
            QueryStringByte = Encoding.UTF8.GetBytes(QueryString);
            Base64QueryString = Convert.ToBase64String(QueryStringByte);
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
            MyDeleteModel.MyDBCredentialModel = new SealedDBCredentialModel();
            MyDeleteModel.MyDBCredentialModel.SealedDBName = SealedDBName;
            MyDeleteModel.MyDBCredentialModel.SealedDBUserName = SealedDBUserName;
            MyDeleteModel.MyDBCredentialModel.SealedDBUserPassword = SealedDBUserPassword;
            MyDeleteModel.MyDBCredentialModel.SealedSessionID = SealedSessionID;
            MyDeleteModel.UniquePaymentID = UniquePaymentID;
            MyDeleteModel.Base64QueryString = Base64QueryString;
            MyDeleteModel.Base64ParameterName = Base64ParameterNameArray;
            MyDeleteModel.Base64ParameterValue = Base64ParameterValueArray;
            ReferenceModel = MyDeleteModel;
            JSONBodyString = JsonConvert.SerializeObject(MyDeleteModel);
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
                var response = client.PostAsync("SpecialDeleteDBRecord/", PostRequestData);
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
                            MessageBox.Show("You have deleted db table record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DeleteRecordBTN_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(Application.StartupPath + "\\Application_Data\\SealedCredentials\\") ==true && Directory.Exists(Application.StartupPath + "\\Application_Data\\DBCredentials\\") == true) 
            {
                String QueryString = "";
                String ParameterName = "";
                String[] ParameterNameArray = new String[] { };
                String ParameterValue = "";
                String[] ParameterValueArray = new String[] { };
                String SampleJSONString = "";
                NormalDBModel MyReferenceModel = new NormalDBModel();
                SpecialSelectDBModel MySpecialSelectDBModel = new SpecialSelectDBModel();
                if(SQLQueryStringTB.Text!=null && SQLQueryStringTB.Text.CompareTo("")!=0 && SQLParameterNameTB.Text!=null && SQLParameterNameTB.Text.CompareTo("")!=0 && SQLParameterValueTB.Text!=null && SQLParameterValueTB.Text.CompareTo("") != 0) 
                {
                    QueryString = SQLQueryStringTB.Text;
                    ParameterName = SQLParameterNameTB.Text;
                    ParameterValue = SQLParameterValueTB.Text;
                    if(ParameterValue.Contains(",")==true && ParameterName.Contains(",") == true) 
                    {
                        WebAPIURLTB.Text = "https://mrchewitsoftware.com.my:5002/api/SpecialDeleteDBRecord/";
                        ParameterNameArray = ParameterName.Split(',');
                        ParameterValueArray = ParameterValue.Split(',');
                        SpecialDeleteDBRecord(QueryString, ParameterNameArray, ParameterValueArray, ref SampleJSONString, ref MySpecialSelectDBModel);
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
                        WebAPIURLTB.Text = "https://mrchewitsoftware.com.my:5002/api/DeleteDBRecord/";
                        DeleteDBRecord(QueryString, ParameterName, ParameterValue, ref SampleJSONString, ref MyReferenceModel);
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
