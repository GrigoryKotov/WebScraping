using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SQLite;
using System.Net.Mail;
using System.Net;
using EO.WebBrowser;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PairDownloader
{    
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetClassName",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetClassName(IntPtr hWnd,
            StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumDesktopWindows(IntPtr hDesktop,
            EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        // Define the callback delegate's type.
        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // Save window titles and handles in these lists.
        private static List<IntPtr> WindowHandles;
        private static List<string> WindowClasses;

        const int SW_HIDE = 0;

        const string url_home = "https://www.barchart.com/futures/quotes/GCV20/options";
        
        public string skey;
        public Dictionary<string, string> pair_map_commidity;
        public List<string> selected_pair_array;

        public Dictionary<string, string> pair_map_savedcompany;
        public List<string> saved_pair_array;

        public Dictionary<int, string> item_map;
        public List<float> premium_call_array;
        public List<float> premium_put_array;

        public int item_monthid = -1;

        public SoundPlayer player;        
        public bool isRestartReq = false;
        public bool isTradeOrHistory = false;
        public int ncycletime1 = 1000 * 60 * 5;
        public int ncycletime2 = 1000 * 60 * 6 * 25;
        public bool isPatched = false;
        public bool isTurboMode = false;
        public bool isCommodity = true;
        public bool isStaked = true;
        public int nMode = 0;
        public int nDownloadHour = 0;
        public bool isDownloadAll = false;
        public bool isDelete = false;
        public bool isNotifyEmail = false;

        public string strNotifyEmailAddr;
        public string strNotifyEmailBody;
        public string strSubjectEmail;
        public string strEmailCommdoity;
        public float fVariation = 0;
        public float fVariationPut = 0;
        public float fPremiumUnit = 0;
        public float fratiocall = 0;
        public float fratioput = 0;
        public int NombreNotification=0;
        public int eurusdcount =0 ;
        public int Eowp = 0;

        public const int mode_notworking = 0;
        public const int mode_download_pair_sel = 1;
        public const int mode_download_pair_all = 2;
        public int IntervalDownload;
        /**
         * @desc database related properties for sqlite and mysql
        */
        public string sqlitepath;
        private string myConnectionString;


        public List<string> companyNameList = new List<string>();
        public List<string> companySymbolList = new List<string>();

        public List<string> arrExpiration = new List<string>();

        public Form1()
        {
           
            try
            {                
                string fullPath = Directory.GetCurrentDirectory() + "\\eowp.exe";
                EO.Base.Runtime.EnableEOWP = true;
                EO.Base.Runtime.InitWorkerProcessExecutable(fullPath);
                
                
            }
            catch (Exception )
            {
             
               try
                {
                    string fullPath = Directory.GetCurrentDirectory() + "\\eowp1.exe";
                    EO.Base.Runtime.EnableEOWP = true;
                    EO.Base.Runtime.InitWorkerProcessExecutable(fullPath);
                }
                catch(Exception )
                {
                    try
                    {
                        string fullPath = Directory.GetCurrentDirectory() + "\\eowp2.exe";
                        EO.Base.Runtime.EnableEOWP = true;
                        EO.Base.Runtime.InitWorkerProcessExecutable(fullPath);
                    }
                    catch (Exception )
                    {
                        try
                        {
                            string fullPath = Directory.GetCurrentDirectory() + "\\eowp3.exe";
                            EO.Base.Runtime.EnableEOWP = true;
                            EO.Base.Runtime.InitWorkerProcessExecutable(fullPath);
                        }
                        catch (Exception )
                        {
                            try
                            {
                                string fullPath = Directory.GetCurrentDirectory() + "\\eowp4.exe";
                                EO.Base.Runtime.EnableEOWP = true;
                                EO.Base.Runtime.InitWorkerProcessExecutable(fullPath);
                            }
                            catch (Exception )
                            {
                                try
                                {
                                    string fullPath = Directory.GetCurrentDirectory() + "\\eowp5.exe";
                                    EO.Base.Runtime.EnableEOWP = true;
                                    EO.Base.Runtime.InitWorkerProcessExecutable(fullPath);
                                }
                                catch (Exception )
                                {
                                    try
                                    {
                                        string fullPath = Directory.GetCurrentDirectory() + "\\eowp6.exe";
                                        EO.Base.Runtime.EnableEOWP = true;
                                        EO.Base.Runtime.InitWorkerProcessExecutable(fullPath);
                                    }
                                    catch (Exception eo)
                                    {
                                        MessageBox.Show(eo.Message);
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
            

            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            

            
            
            this.WindowState = FormWindowState.Maximized;           

            pair_map_commidity = new Dictionary<string, string>();
            pair_map_savedcompany = new Dictionary<string, string>();

            item_map = new Dictionary<int, string>();
            premium_call_array = new List<float>();
            premium_put_array = new List<float>();

            selected_pair_array = new List<string>();
            saved_pair_array = new List<string>();


            sqlitepath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\db.sqlite";
            myConnectionString = "Data Source=" + sqlitepath + "; Version = 3; New = True; Compress = True;";

            string mUrl = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Alert.wav";
            player = new SoundPlayer(mUrl);

            cmbDownloadTime.SelectedIndex = 0;
            chkDownloadTime.Checked = true;
            isDownloadAll = true;
            chkDeletePairDetails.Checked = true;
            isDelete = true;

            lblCurrentStatus.Text = "Loading";

            WindowHandles = new List<IntPtr>();
            WindowClasses = new List<string>();
            timer1.Start();
            load();

            cmbCommodity.SelectedIndex = 0;
            groupCompany.Enabled = false;
            groupCommodity.Enabled = true;

            cmbStaked.SelectedIndex = 0;
            isStaked = true;
        }
    
        private void load()
        {
            webView1.Url = url_home;
            btnStart.Enabled = false;
            btnAllStart.Enabled = false;
            btnStop.Enabled = false;
            dataViewToolStripMenuItem.Enabled = false;
        }

        // Return a list of the desktop windows' handles and titles.
        public void GetDesktopWindowHandlesAndTitles(
            out List<IntPtr> handles, out List<string> classes)
        {
            if (!EnumDesktopWindows(IntPtr.Zero, FilterCallback,
                IntPtr.Zero))
            {
                handles = null;
                classes = null;
            }
            else
            {
                handles = WindowHandles;
                classes = WindowClasses;
            }
        }

        // We use this function to filter windows.
        // This version selects visible windows that have titles.
        private static bool FilterCallback(IntPtr hWnd, int lParam)
        {
            // Get the window's title.
            StringBuilder sb_class = new StringBuilder(1024);
            int length = GetClassName(hWnd, sb_class, sb_class.Capacity);
            string szclasse = sb_class.ToString();

            // If the window is visible and has a title, save it.
            if (IsWindowVisible(hWnd) &&
                string.IsNullOrEmpty(szclasse) == false)
            {
                WindowHandles.Add(hWnd);
                WindowClasses.Add(szclasse);
            }

            // Return true to indicate that we
            // should continue enumerating windows.
            return true;
        }

        private int MAKELPARAM(int p, int p_2)
        {
            return ((p_2 << 16) | (p & 0xFFFF));
        }

        private bool checkEOTrial()
        {
            List<IntPtr> handles;
            List<string> classes;
            GetDesktopWindowHandlesAndTitles(
                out handles, out classes);

            for (int i = 0; i < handles.Count; i++)
            {
                if (classes[i].IndexOf("eo.nativewnd") >= 0)
                {
                    ShowWindow(handles[i], SW_HIDE);
                    return true;
                }
            }

            return false;
        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                MessageBox.Show(text, caption);
            }

            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }

            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow(null, _caption);
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        public void downloadselect1()
        {
            
            if (backgroundWorker1.IsBusy)
            {
                AutoClosingMessageBox.Show("Program is working in selected download mode now.","Program is working",20000);
            }
            else if (selected_pair_array.Count == 0)
            {
                if (isCommodity)
                    MessageBox.Show("Please select a commodity in Treeview.");
                else
                    MessageBox.Show("Please select a company in Search Company Result.");
            }
            else
            {
                lblCurrentStatus.Text = "Downloading Selected Pair details ...";
                isNotifyEmail = chkNotifyEmail.Checked;
                fVariation = float.Parse(txtVariationCond.Text);
                fVariationPut = float.Parse(textboxVariationPut.Text);
                fratiocall = float.Parse(textBoxRatioCall.Text);
                fratioput = float.Parse(textBoxRatioPut.Text);
                fPremiumUnit = float.Parse(txtPremiumUnit.Text);
                strNotifyEmailAddr = txtNotifyEmail.Text;
                strNotifyEmailBody = txtEmailBody.Text;
                toolStripProgressBar1.Maximum = selected_pair_array.Count * 50;
                toolStripProgressBar1.Step = 1;
                if (isCommodity)
                    groupCommodity.Enabled = false;
                else
                    groupCompany.Enabled = false;
                chkDeletePairDetails.Enabled = false;
                chkDownloadTime.Enabled = false;
                chkNotifyEmail.Enabled = false;
                cmbDownloadTime.Enabled = false;
                btnStart.Enabled = false;
                btnAllStart.Enabled = false;
                btnStop.Enabled = true;
                nMode = mode_download_pair_sel;
                backgroundWorker1.RunWorkerAsync();                
            }            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IntervalDownload = Convert.ToInt32(textBoxIntervalDownload.Text);
                        
            if (IntervalDownload == 0)
            {
                MessageBox.Show("Please write interval value great than 60000 Miliseconds");
                return;
            }
            else

                timer2.Interval = IntervalDownload;
            timer2.Enabled = true;
            timer2.Start();

            if (backgroundWorker1.IsBusy)
            {
                AutoClosingMessageBox.Show("Program is working in selected download mode now.","Program is working", 20000);
            }
            else if (selected_pair_array.Count == 0)
            {
                MessageBox.Show("Please select commodity in Treeview.");
            }
            else
            {
                lblCurrentStatus.Text = "Downloading Selected Pair details ...";
                isNotifyEmail = chkNotifyEmail.Checked;
                fVariation = float.Parse(txtVariationCond.Text);
                fVariationPut = float.Parse(textboxVariationPut.Text);
                fratiocall = float.Parse(textBoxRatioCall.Text);
                fratioput = float.Parse(textBoxRatioPut.Text);
                fPremiumUnit = float.Parse(txtPremiumUnit.Text);
                strNotifyEmailAddr = txtNotifyEmail.Text;
                strNotifyEmailBody = txtEmailBody.Text;
                toolStripProgressBar1.Maximum = selected_pair_array.Count * 55;
                toolStripProgressBar1.Step = 1;
                if (isCommodity)
                    groupCommodity.Enabled = false;
                else
                    groupCompany.Enabled = false;
                chkDeletePairDetails.Enabled = false;
                chkDownloadTime.Enabled = false;
                chkNotifyEmail.Enabled = false;
                cmbDownloadTime.Enabled = false;
                btnStart.Enabled = false;
                btnAllStart.Enabled = false;
                btnStop.Enabled = true;
                nMode = mode_download_pair_sel;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnAllStart_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                AutoClosingMessageBox.Show("Program is working in all download mode now.","Program is working", 20000);
            }
            else if (selected_pair_array.Count == 0)
            {
                MessageBox.Show("Please select commodity for monitoring in Treeview.");
            }
            else
            {
                
                lblCurrentStatus.Text = "Waiting Delete or Download timing ...";

                isNotifyEmail = chkNotifyEmail.Checked;
                strNotifyEmailAddr = txtNotifyEmail.Text;
                strNotifyEmailBody = txtEmailBody.Text;

                toolStripProgressBar1.Maximum = selected_pair_array.Count * 50;
                toolStripProgressBar1.Step = 1;
                if (isCommodity)
                    groupCommodity.Enabled = false;
                else
                    groupCompany.Enabled = false;
                btnStart.Enabled = false;
                btnAllStart.Enabled = false;
                btnStop.Enabled = true;
                nMode = mode_download_pair_all; // wa  mode_download_pair_all
                nDownloadHour = cmbDownloadTime.SelectedIndex;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {            
            backgroundWorker1.CancelAsync();
            timer2.Stop();
        }

        public void sendSuccessEmail()
        {
        }

        public int getIntFromString(string strInt)
        {
            int ret = 0;

            strInt = strInt.Replace("N/A", "0");
            strInt = strInt.Replace(",", "");
            try
            {
                ret = Int32.Parse(strInt);
            }
            catch (Exception)
            {
            }

            return ret;
        }

        public bool isExistinTable(string commodity, int nMonthIdx)
        {
            bool isExist = false;
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            DateTime BeginDate = DateTime.Now.AddMonths(nMonthIdx);
            string strMonthId = BeginDate.ToString("yyyy-MM-00");

            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(myConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT COUNT(*) FROM pair_details WHERE pair=\"" + commodity + "\" AND month=\"" + strMonthId + "\";";
            SQLiteDataReader rdr = sqlite_cmd.ExecuteReader();
            while (rdr.Read())
            {
                int count = rdr.GetInt32(0);
                isExist = (count > 0);
            }
            rdr.Close();
            sqlite_conn.Close();

            return isExist;
        }

        public int deleteDetailsTable()
        {
            DateTime endDate = DateTime.Now.AddMonths(-1);
            string strMonthId = endDate.ToString("yyyy-MM-00");

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(myConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "DELETE FROM pair_details WHERE month<\"" + strMonthId + "\";";
            int ndeleted  = sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();

            return ndeleted;
        }

        public void processTable(int nMonthIdx, string tableContent, string selectedPairNode, bool isCallPut = true)
        {
            if (!isStaked)
            {
                processTableSidebySide(nMonthIdx, tableContent, selectedPairNode, isCallPut);
                return;
            }

            string[] values = tableContent.Split('_');
            if (values.Count() > 0)
            {
                if (isCommodity)
                {
                    try
                    {
                        int columnCount = Int32.Parse(values[0]);
                        int rowCount = (values.Count() - 1) / columnCount;

                        if (columnCount != 11)
                        {
                            MessageBox.Show("Website data format is changed, so different with database.");
                            return;
                        }

                        DateTime BeginDate = DateTime.Now.AddMonths(nMonthIdx);
                        string strMonthId = BeginDate.ToString("yyyy-MM-00");

                        SQLiteConnection sqlite_conn;
                        SQLiteCommand sqlite_cmd;

                        // Create a new database connection:
                        sqlite_conn = new SQLiteConnection(myConnectionString);
                        sqlite_conn.Open();
                        sqlite_cmd = sqlite_conn.CreateCommand();

                        try
                        {
                            sqlite_cmd.CommandText = "DELETE FROM pair_details WHERE pair=\"" + selectedPairNode + "\" AND month=\"" + strMonthId + "\";";
                            sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                        }

                        {
                            for (int i = 0; i < rowCount - 1; i++)
                            {
                                try
                                {
                                    sqlite_cmd.CommandText = "INSERT INTO pair_details(pair, month, strike, high, low, last, change, bid, ask, volume, openint, premium, lasttrade) VALUES (" +
                                    "\"" + selectedPairNode + "\"" +
                                    ", \"" + strMonthId + "\"" +
                                    ", \"" + values[i * columnCount + 1] + "\"" +       // strike
                                    ", \"" + values[i * columnCount + 2] + "\"" +       // high   
                                    ", \"" + values[i * columnCount + 3] + "\"" +       // low
                                    ", \"" + values[i * columnCount + 4] + "\"" +       // last
                                    ", \"" + values[i * columnCount + 5] + "\"" +       // change
                                    ", \"" + values[i * columnCount + 6] + "\"" +       // bid
                                    ", \"" + values[i * columnCount + 7] + "\"" +       // ask
                                    ", " + getIntFromString(values[i * columnCount + 8]) + // volume
                                    ", " + getIntFromString(values[i * columnCount + 9]) + // openint
                                    ", \"" + values[i * columnCount + 10].Replace(",", "") + "\"" + // premium
                                    ", \"" + values[i * columnCount + 11] + "\");";     // lasttrade

                                    sqlite_cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }

                        sqlite_conn.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    try
                    {
                        int columnCount = Int32.Parse(values[0]);
                        int rowCount = (values.Count() - 1) / columnCount;

                        if (columnCount != 13)
                        {
                            MessageBox.Show("Website data format is changed, so different with database.");
                            return;
                        }

                        DateTime BeginDate = DateTime.Now.AddMonths(nMonthIdx);
                        string strMonthId = BeginDate.ToString("yyyy-MM-dd");
                        string strExpMonth = expirationDate(nMonthIdx);
                        if (strExpMonth.Length > 10)
                            strMonthId = strExpMonth.Substring(0, 10);
                        
                        SQLiteConnection sqlite_conn;
                        SQLiteCommand sqlite_cmd;

                        // Create a new database connection:
                        sqlite_conn = new SQLiteConnection(myConnectionString);
                        sqlite_conn.Open();
                        sqlite_cmd = sqlite_conn.CreateCommand();

                        try
                        {
                            if (isCallPut)
                            {
                                sqlite_cmd.CommandText = "DELETE FROM pair_details_company WHERE pair=\"" + selectedPairNode + "\" AND month=\"" + strMonthId + "\";";
                                sqlite_cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception)
                        {
                        }

                        {
                            for (int i = 0; i < rowCount - 1; i++)
                            {
                                try
                                {
                                    sqlite_cmd.CommandText = "INSERT INTO pair_details_company(pair, month, strike, moneyness, bid, midpoint, ask, last, change, chg, volume, openint, voi, iv, lasttrade) VALUES (" +
                                    "\"" + selectedPairNode + "\"" +
                                    ", \"" + strMonthId + "\"" +
                                    ", \"" + values[i * columnCount + 1] + (isCallPut ? "c\"" : "p\"") +       // strike
                                    ", \"" + values[i * columnCount + 2] + "\"" +       // moneyness   
                                    ", \"" + values[i * columnCount + 3] + "\"" +       // bid
                                    ", \"" + values[i * columnCount + 4] + "\"" +       // midpoint
                                    ", \"" + values[i * columnCount + 5] + "\"" +       // ask
                                    ", \"" + values[i * columnCount + 6] + "\"" +       // last
                                    ", \"" + values[i * columnCount + 7] + "\"" +       // change
                                    ", \"" + values[i * columnCount + 8] + "\"" +       // chg
                                    ", \"" + getIntFromString(values[i * columnCount + 9]) + "\"" +       // volume
                                    ", \"" + getIntFromString(values[i * columnCount + 10]) + "\"" +       // openint
                                    ", \"" + values[i * columnCount + 11] + "\"" +       // voi
                                    ", \"" + values[i * columnCount + 12] + "\"" +       // iv
                                    ", \"" + values[i * columnCount + 13] + "\");";     // lasttrade

                                    sqlite_cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }

                        sqlite_conn.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }            
        }

        public void processTableSidebySide(int nMonthIdx, string tableContent, string selectedPairNode, bool isCallPut = true)
        {
            string[] values = tableContent.Split('_');
            if (values.Count() > 0)
            {
                if (isCommodity)
                {
                    try
                    {
                        int columnCount = Int32.Parse(values[0]);
                        int rowCount = (values.Count() - 1) / columnCount;

                        if (columnCount != 9)
                        {
                            MessageBox.Show("Website data format is changed, so different with database.");
                            return;
                        }

                        DateTime BeginDate = DateTime.Now.AddMonths(nMonthIdx);
                        string strMonthId = BeginDate.ToString("yyyy-MM-00");

                        SQLiteConnection sqlite_conn;
                        SQLiteCommand sqlite_cmd;

                        // Create a new database connection:
                        sqlite_conn = new SQLiteConnection(myConnectionString);
                        sqlite_conn.Open();
                        sqlite_cmd = sqlite_conn.CreateCommand();

                        try
                        {
                            sqlite_cmd.CommandText = "DELETE FROM pair_details WHERE pair=\"" + selectedPairNode + "\" AND month=\"" + strMonthId + "\";";
                            sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                        }

                        {
                            for (int i = 0; i < rowCount - 1; i++)
                            {
                                try
                                {
                                    sqlite_cmd.CommandText = "INSERT INTO pair_details(pair, month, strike, high, low, last, change, bid, ask, volume, openint, premium, lasttrade) VALUES (" +
                                    "\"" + selectedPairNode + "\"" +
                                    ", \"" + strMonthId + "\"" +
                                    ", \"" + values[i * columnCount + 5] + "C\"" +       // strike
                                    ", \"\"" +       // high   
                                    ", \"\"" +       // low
                                    ", \"" + values[i * columnCount + 1] + "\"" +       // last
                                    ", \"\"" +       // change
                                    ", \"\"" +       // bid
                                    ", \"\"" +       // ask
                                    ", " + getIntFromString(values[i * columnCount + 2]) + // volume
                                    ", " + getIntFromString(values[i * columnCount + 3]) + // openint
                                    ", \"" + values[i * columnCount + 4].Replace(",", "") + "\"" + // premium
                                    ", \"\");";     // lasttrade
                                    sqlite_cmd.ExecuteNonQuery();

                                    sqlite_cmd.CommandText = "INSERT INTO pair_details(pair, month, strike, high, low, last, change, bid, ask, volume, openint, premium, lasttrade) VALUES (" +
                                    "\"" + selectedPairNode + "\"" +
                                    ", \"" + strMonthId + "\"" +
                                    ", \"" + values[i * columnCount + 6] + "P\"" +       // strike
                                    ", \"\"" +       // high   
                                    ", \"\"" +       // low
                                    ", \"" + values[i * columnCount + 6] + "\"" +       // last
                                    ", \"\"" +       // change
                                    ", \"\"" +       // bid
                                    ", \"\"" +       // ask
                                    ", " + getIntFromString(values[i * columnCount + 7]) + // volume
                                    ", " + getIntFromString(values[i * columnCount + 8]) + // openint
                                    ", \"" + values[i * columnCount + 9].Replace(",", "") + "\"" + // premium
                                    ", \"\");";     // lasttrade
                                    sqlite_cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }

                        sqlite_conn.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    try
                    {
                        int columnCount = Int32.Parse(values[0]);
                        int rowCount = (values.Count() - 1) / columnCount;

                        if (columnCount != 17)
                        {
                            MessageBox.Show("Website data format is changed, so different with database.");
                            return;
                        }

                        DateTime BeginDate = DateTime.Now.AddMonths(nMonthIdx);
                        string strMonthId = BeginDate.ToString("yyyy-MM-dd");
                        string strExpMonth = expirationDate(nMonthIdx);
                        if (strExpMonth.Length > 10)
                            strMonthId = strExpMonth.Substring(0, 10);

                        SQLiteConnection sqlite_conn;
                        SQLiteCommand sqlite_cmd;

                        // Create a new database connection:
                        sqlite_conn = new SQLiteConnection(myConnectionString);
                        sqlite_conn.Open();
                        sqlite_cmd = sqlite_conn.CreateCommand();

                        try
                        {
                            if (isCallPut)
                            {
                                sqlite_cmd.CommandText = "DELETE FROM pair_details_company WHERE pair=\"" + selectedPairNode + "\" AND month=\"" + strMonthId + "\";";
                                sqlite_cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception)
                        {
                        }

                        {
                            for (int i = 0; i < rowCount - 1; i++)
                            {
                                try
                                {
                                    sqlite_cmd.CommandText = "INSERT INTO pair_details_company(pair, month, strike, moneyness, bid, midpoint, ask, last, change, chg, volume, openint, voi, iv, lasttrade) VALUES (" +
                                    "\"" + selectedPairNode + "\"" +
                                    ", \"" + strMonthId + "\"" +
                                    ", \"" + values[i * columnCount + 9] + "c\"" +       // strike
                                    ", \"\"" +       // moneyness   
                                    ", \"" + values[i * columnCount + 2] + "\"" +       // bid
                                    ", \"\"" +       // midpoint
                                    ", \"" + values[i * columnCount + 3] + "\"" +       // ask
                                    ", \"" + values[i * columnCount + 1] + "\"" +       // last
                                    ", \"" + values[i * columnCount + 4] + "\"" +       // change
                                    ", \"\"" +       // chg
                                    ", \"" + getIntFromString(values[i * columnCount + 5]) + "\"" +       // volume
                                    ", \"" + getIntFromString(values[i * columnCount + 6]) + "\"" +       // openint
                                    ", \"\"" +       // voi
                                    ", \"" + values[i * columnCount + 7] + "\"" +       // iv
                                    ", \"" + values[i * columnCount + 8] + "\");";     // lasttrade
                                    sqlite_cmd.ExecuteNonQuery();

                                    sqlite_cmd.CommandText = "INSERT INTO pair_details_company(pair, month, strike, moneyness, bid, midpoint, ask, last, change, chg, volume, openint, voi, iv, lasttrade) VALUES (" +
                                    "\"" + selectedPairNode + "\"" +
                                    ", \"" + strMonthId + "\"" +
                                    ", \"" + values[i * columnCount + 9] + "p\"" +       // strike
                                    ", \"\"" +       // moneyness   
                                    ", \"" + values[i * columnCount + 11] + "\"" +       // bid
                                    ", \"\"" +       // midpoint
                                    ", \"" + values[i * columnCount + 12] + "\"" +       // ask
                                    ", \"" + values[i * columnCount + 10] + "\"" +       // last
                                    ", \"" + values[i * columnCount + 13] + "\"" +       // change
                                    ", \"\"" +       // chg
                                    ", \"" + getIntFromString(values[i * columnCount + 14]) + "\"" +       // volume
                                    ", \"" + getIntFromString(values[i * columnCount + 15]) + "\"" +       // openint
                                    ", \"\"" +       // voi
                                    ", \"" + values[i * columnCount + 16] + "\"" +       // iv
                                    ", \"" + values[i * columnCount + 17] + "\");";     // lasttrade
                                    sqlite_cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }

                        sqlite_conn.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        public bool processRatios(string selectedPairNode, int nMonthIdx, string strPutPremiumTotal, string strCallPremiumTotal, string strPremiumRatio, string strPutInterestTotal, string strCallInterestTotal, string strInterestRatio)
        {            
            bool isExist = false;
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            DateTime nowDate = DateTime.Now;
            DateTime BeginDate = DateTime.Now.AddMonths(nMonthIdx);
            string strMonthId = BeginDate.ToString("yyyy-MM-00");

            if (isCommodity)
            {
                // Create a new database connection:
                try
                {
                    sqlite_conn = new SQLiteConnection(myConnectionString);
                    sqlite_conn.Open();
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    sqlite_cmd.CommandText = "SELECT COUNT(*) FROM pair_statistics WHERE pair=\"" + selectedPairNode + "\" AND month=\"" + strMonthId + "\";";
                    SQLiteDataReader rdr = sqlite_cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        int count = rdr.GetInt32(0);
                        isExist = (count > 0);
                    }
                    rdr.Close();

                    if (isExist == false)
                    {
                        sqlite_cmd.CommandText = "INSERT INTO pair_statistics(pair, month, putpremiumtotal, callpremiumtotal, premiumratio, putinteresttotal, callinteresttotal, interestratio, datetime) VALUES (" +
                        "\"" + selectedPairNode + "\"" +
                        ", \"" + strMonthId + "\"" +
                        ", \"" + strPutPremiumTotal + "\"" +
                        ", \"" + strCallPremiumTotal + "\"" +
                        ", \"" + strPremiumRatio + "\"" +
                        ", \"" + strPutInterestTotal + "\"" +
                        ", \"" + strCallInterestTotal + "\"" +
                        ", \"" + strInterestRatio + "\"" +
                        ", \"" + nowDate.ToShortDateString() + " " + nowDate.ToString("HH:mm") + "\");";

                        sqlite_cmd.ExecuteNonQuery();
                    }
                    sqlite_conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please check db.sqlite file");
                    return false;
                }
            }
            else
            {
                string strExpMonth = expirationDate(nMonthIdx);
                if (strExpMonth.Length > 10)
                    strMonthId = strExpMonth.Substring(0, 10);

                // Create a new database connection:
                try
                {
                    sqlite_conn = new SQLiteConnection(myConnectionString);
                    sqlite_conn.Open();
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    sqlite_cmd.CommandText = "SELECT COUNT(*) FROM pair_statistics WHERE pair=\"" + selectedPairNode + "\" AND month=\"" + strMonthId + "\";";
                    SQLiteDataReader rdr = sqlite_cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        int count = rdr.GetInt32(0);
                        isExist = (count > 0);
                    }
                    rdr.Close();

                    if (isExist == false)
                    {
                        sqlite_cmd.CommandText = "INSERT INTO pair_statistics_company(pair, month, putpremiumtotal, callpremiumtotal, premiumratio, putinteresttotal, callinteresttotal, interestratio, datetime) VALUES (" +
                        "\"" + selectedPairNode + "\"" +
                        ", \"" + strMonthId + "\"" +
                        ", \"" + strPutPremiumTotal + "\"" +
                        ", \"" + strCallPremiumTotal + "\"" +
                        ", \"" + strPremiumRatio + "\"" +
                        ", \"" + strPutInterestTotal + "\"" +
                        ", \"" + strCallInterestTotal + "\"" +
                        ", \"" + strInterestRatio + "\"" +
                        ", \"" + nowDate.ToShortDateString() + " " + nowDate.ToString("HH:mm") + "\");";

                        sqlite_cmd.ExecuteNonQuery();
                    }
                    sqlite_conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please check db.sqlite file");
                    return false;
                }
            }

            return true;
        }

        public void processPremiumPutandCall(string commodity, int nMonthIndex)
        {
            string url = getHomeUrl(commodity, nMonthIndex);
            if (url.Length > 0)
            {
                if (isCommodity)
                {
                    float currentPrice = getCurrentPrice(url);

                    DateTime nowDate = DateTime.Now;
                    DateTime beginDate = DateTime.Now.AddMonths(nMonthIndex);
                    string strMonthId = beginDate.ToString("yyyy-MM-00");

                    List<PairDetail> listPairs = new List<PairDetail>();
                    SQLiteConnection sqlite_conn;
                    SQLiteCommand sqlite_cmd;

                    // Create a new database connection:
                    sqlite_conn = new SQLiteConnection(myConnectionString);
                    sqlite_conn.Open();
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    sqlite_cmd.CommandText = "SELECT strike, last FROM pair_details WHERE pair=\"" + commodity + "\" AND month=\"" + strMonthId + "\";";
                    SQLiteDataReader rdr = sqlite_cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        PairDetail pair = new PairDetail();
                        string value = rdr.GetString(0);
                        pair.type = value.Substring(value.Length - 1);
                        pair.strike = value.Substring(0, value.Length - 1);
                        pair.strike = pair.strike.Replace("s", "").Replace("-", ".");
                        value = rdr.GetString(1);
                        pair.last = value.Replace("s", "").Replace("-", ".");
                        listPairs.Add(pair);
                    }
                    rdr.Close();
                    sqlite_conn.Close();

                    float fpremium_call = 0, fpremium_put = 0;
                    // process for call
                    PairDetail selectedCallHighPair = null, selectedCallLowPair = null;
                    foreach (PairDetail pair in listPairs)
                    {
                        if (pair.type.ToLower() == "c")
                        {
                            float fstrike = float.Parse(pair.strike);
                            if (fstrike >= currentPrice)
                            {
                                selectedCallHighPair = pair;
                                break;
                            }
                            selectedCallLowPair = pair;
                        }
                    }

                    if (selectedCallHighPair !=null && selectedCallLowPair != null )
                    {
                        float fstrikeHigh1 = float.Parse(selectedCallHighPair.strike);
                        float fstrikeLow1 = float.Parse(selectedCallLowPair.strike);
                        float flastHigh1 = float.Parse(selectedCallHighPair.last);
                        float flastLow1 = float.Parse(selectedCallLowPair.last);

                        float fdeltaStrike1 = fstrikeHigh1 - fstrikeLow1;
                        float fdeltaStrike2 = fstrikeHigh1 - currentPrice;
                        float fdeltaLast1 = flastLow1-flastHigh1;

                        float Rule1 = fdeltaStrike2 * fdeltaLast1;
                        float Rule2 = Rule1 / fdeltaStrike1;
                        float fdeltaPremium1 = flastHigh1 + Rule2;

                        fpremium_call = (fdeltaPremium1) * fPremiumUnit ;

                        premium_call_array.Add(fpremium_call);
                    } else
                    {
                        float fstrikeHighC = float.Parse(selectedCallHighPair.strike);
                        float fstrikeLowC = float.Parse(selectedCallLowPair.strike);

                        float flastHighC = float.Parse(selectedCallHighPair.last);
                        float flastLowC = float.Parse(selectedCallLowPair.last);

                        float fdeltaLastC = flastHighC - flastLowC;
                        float fdeltaStrikeC = fstrikeHighC - currentPrice;
                        float frateC = fdeltaStrikeC / (fstrikeHighC - fstrikeLowC);
                        float fdeltaPremiumC = frateC * fdeltaLastC;
                        fpremium_call = (flastLowC - fdeltaPremiumC) * fPremiumUnit;

                        premium_call_array.Add(fpremium_call);
                    }
                    
                    // process for put
                    PairDetail selectedPutHighPair = null, selectedPutLowPair = null;
                    foreach (PairDetail pair in listPairs)
                    {
                        if (pair.type.ToLower() == "p")
                        {
                            float fstrike = float.Parse(pair.strike);
                            if (fstrike >= currentPrice)
                            {
                                selectedPutHighPair = pair;
                                break;
                            }
                            selectedPutLowPair = pair;
                        }
                    }

                    if (selectedPutHighPair != null && selectedPutLowPair != null)
                    {
                        float fstrikeHigh1 = float.Parse(selectedPutHighPair.strike);
                        float fstrikeLow1 = float.Parse(selectedPutLowPair.strike);
                        float flastHigh1 = float.Parse(selectedPutHighPair.last);
                        float flastLow1 = float.Parse(selectedPutLowPair.last);

                        float fdeltaStrike1 = fstrikeHigh1 - fstrikeLow1;
                        float fdeltaStrike2 = currentPrice - fstrikeLow1;
                        float fdeltaLast1 =  flastLow1- flastHigh1;

                        float Rule1 = fdeltaStrike2 * fdeltaLast1;
                        float Rule2 = Rule1 / fdeltaStrike1;
                        float fdeltaPremium1 = flastLow1 - Rule2;

                        fpremium_put = (fdeltaPremium1) * fPremiumUnit;

                                              
                        premium_put_array.Add(fpremium_put);
                    }
                  

                    if (fpremium_call != 0 && fpremium_put != 0)
                    {
                        int frequency = nMonthIndex;

                        sqlite_conn.Open();
                        sqlite_cmd = sqlite_conn.CreateCommand();
                        try
                        {
                            sqlite_cmd.CommandText = "INSERT INTO premium_callput(datetime, pair, current_price, strike_call_high_low, last_call_high_low, strike_put_high_low, last_put_high_low, frequency, premium_call, premium_put) VALUES (" +
                            //"\"" + nowDate.ToShortDateString() + " " + nowDate.ToString("HH:mm") + "\"" +
                            "\"" + nowDate.ToString("yyyy-MM-dd") + " " + nowDate.ToString("HH:mm") + "\"" +
                            ", \"" + commodity + "\"" +
                            ", \"" + currentPrice.ToString() + "\"" +
                            ", \"" + selectedCallHighPair.strike + "-" + selectedCallLowPair.strike + "\"" +
                            ", \"" + selectedCallHighPair.last + "-" + selectedCallLowPair.last + "\"" +
                            ", \"" + selectedPutHighPair.strike + "-" + selectedPutLowPair.strike + "\"" +
                            ", \"" + selectedPutHighPair.last + "-" + selectedPutLowPair.last + "\"" +
                            ", \"" + frequency + "\"" +
                            ", \"" + fpremium_call.ToString() + "\"" +
                            ", \"" + fpremium_put.ToString() + "\");";

                            sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                        }
                        sqlite_conn.Close();
                        
                        if (Math.Abs(fpremium_call - fpremium_put) > fVariation && frequency==6  || ((fpremium_put / fpremium_call) < fratiocall && frequency==6))
                        {
                            if(checkBoxRule3.Checked)
                            {
                                strSubjectEmail =" Rule of 3 call"+ commodity ;
                                strEmailCommdoity = commodity;
                                strNotifyEmailBody = commodity + "   people are buying this commodity,  the Variation after analyze is " + (fpremium_call - fpremium_put) + " Ratio " + fpremium_put / fpremium_call + " on " + DateTime.Now.ToLongTimeString() + " . La frquence calculer " + frequency;
                                SendEmailGmail();
                            }
                            strSubjectEmail = commodity + " call old one";
                            strEmailCommdoity = commodity;
                            strNotifyEmailBody = commodity + "   people are buying this commodity,  the Variation after analyze is "  +(fpremium_call - fpremium_put) + "  Ratio " + fpremium_put / fpremium_call  + " on " + DateTime.Now.ToLongTimeString() + " . La frquence calculer " + frequency;
                            SendEmailGmail();

                        }
                        else if (Math.Abs(fpremium_call - fpremium_put) < fVariationPut && frequency == 6 || ((fpremium_put / fpremium_call) > fratioput && frequency == 6))
                        {
                            if(checkBoxRule3.Checked)
                            {
                                strSubjectEmail =" Rule of 3 put "+ commodity ;
                                strEmailCommdoity = commodity;
                                strNotifyEmailBody = commodity + "   people are selling this commodity, the Variation after analyze is" + (fpremium_call - fpremium_put) + "  Ratio " + fpremium_put / fpremium_call + " on " + DateTime.Now.ToLongTimeString() + " . La frequence calculer " + frequency;
                                SendEmailGmail();
                            }
                            strSubjectEmail = commodity + "Put old one ";
                            strEmailCommdoity = commodity;
                            strNotifyEmailBody = commodity + "   people are selling this commodity, the Variation after analyze is"  + (fpremium_call - fpremium_put)+" Ratio "+ fpremium_put / fpremium_call + " on " + DateTime.Now.ToLongTimeString() + " . La frequence calculer " + frequency;
                            SendEmailGmail();
                        }
                    }
                }
                else
                {
                    float currentPrice = getCurrentPrice(url);

                    DateTime nowDate = DateTime.Now;
                    DateTime beginDate = DateTime.Now.AddMonths(nMonthIndex);
                    string strMonthId = beginDate.ToString("yyyy-MM-");

                    List<PairDetail> listPairs = new List<PairDetail>();
                    SQLiteConnection sqlite_conn;
                    SQLiteCommand sqlite_cmd;

                    // Create a new database connection:
                    sqlite_conn = new SQLiteConnection(myConnectionString);
                    sqlite_conn.Open();
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    sqlite_cmd.CommandText = "SELECT strike, last FROM pair_details_company WHERE pair=\"" + commodity + "\" AND month like '" + strMonthId + "%';";
                    SQLiteDataReader rdr = sqlite_cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        PairDetail pair = new PairDetail();
                        string value = rdr.GetString(0);
                        pair.type = value.Substring(value.Length - 1);
                        pair.strike = value.Substring(0, value.Length - 1);
                        pair.strike = pair.strike.Replace("s", "").Replace("-", ".");
                        value = rdr.GetString(1);
                        pair.last = value.Replace("s", "").Replace("-", ".");
                        listPairs.Add(pair);
                    }
                    rdr.Close();
                    sqlite_conn.Close();

                    float fpremium_call = 0, fpremium_put = 0;
                    // process for call
                    PairDetail selectedCallHighPair = null, selectedCallLowPair = null;
                    foreach (PairDetail pair in listPairs)
                    {
                        if (pair.type.ToLower() == "c")
                        {
                            float fstrike = float.Parse(pair.strike);
                            if (fstrike >= currentPrice)
                            {
                                selectedCallHighPair = pair;
                                break;
                            }
                            selectedCallLowPair = pair;
                        }
                    }

                    if (selectedCallHighPair != null && selectedCallLowPair != null)
                    {
                        float fstrikeHigh = float.Parse(selectedCallHighPair.strike);
                        float fstrikeLow = float.Parse(selectedCallLowPair.strike);
                        float flastHigh = float.Parse(selectedCallHighPair.last);
                        float flastLow = float.Parse(selectedCallLowPair.last);

                        float fdeltaLast = flastHigh - flastLow;
                        float fdeltaStrike = fstrikeHigh - currentPrice;
                        float frate = fdeltaStrike / (fstrikeHigh - fstrikeLow);
                        float fdeltaPremium = frate * fdeltaLast;
                        fpremium_call = (flastLow - fdeltaPremium) * fPremiumUnit;

                        premium_call_array.Add(fpremium_call);
                    }

                    // process for put
                    PairDetail selectedPutHighPair = null, selectedPutLowPair = null;
                    foreach (PairDetail pair in listPairs)
                    {
                        if (pair.type.ToLower() == "p")
                        {
                            float fstrike = float.Parse(pair.strike);
                            if (fstrike >= currentPrice)
                            {
                                selectedPutHighPair = pair;
                                break;
                            }
                            selectedPutLowPair = pair;
                        }
                    }

                    if (selectedPutHighPair != null && selectedPutLowPair != null)
                    {
                        float fstrikeHigh = float.Parse(selectedPutHighPair.strike);
                        float fstrikeLow = float.Parse(selectedPutLowPair.strike);
                        float flastHigh = float.Parse(selectedPutHighPair.last);
                        float flastLow = float.Parse(selectedPutLowPair.last);

                        float fdeltaLast = flastHigh - flastLow;
                        float fdeltaStrike = fstrikeLow - currentPrice;
                        float frate = fdeltaStrike / (fstrikeHigh - fstrikeLow);
                        float fdeltaPremium = frate * fdeltaLast;
                        fpremium_put = (flastLow - fdeltaPremium) * fPremiumUnit;
                        premium_put_array.Add(fpremium_put);
                    }

                    if (fpremium_call != 0 && fpremium_put != 0)
                    {
                        int frequency = nMonthIndex;

                        sqlite_conn.Open();
                        sqlite_cmd = sqlite_conn.CreateCommand();
                        try
                        {
                            sqlite_cmd.CommandText = "INSERT INTO premium_callput_company(datetime, pair, current_price, strike_call_high_low, last_call_high_low, strike_put_high_low, last_put_high_low, frequency, premium_call, premium_put) VALUES (" +
                            "\"" + nowDate.ToShortDateString() + " " + nowDate.ToString("HH:mm") + "\"" +
                            ", \"" + commodity + "\"" +
                            ", \"" + currentPrice.ToString() + "\"" +
                            ", \"" + selectedCallHighPair.strike + "-" + selectedCallLowPair.strike + "\"" +
                            ", \"" + selectedCallHighPair.last + "-" + selectedCallLowPair.last + "\"" +
                            ", \"" + selectedPutHighPair.strike + "-" + selectedPutLowPair.strike + "\"" +
                            ", \"" + selectedPutHighPair.last + "-" + selectedPutLowPair.last + "\"" +
                            ", \"" + frequency + "\"" +
                            ", \"" + fpremium_call.ToString() + "\"" +
                            ", \"" + fpremium_put.ToString() + "\");";

                            sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                        }
                        sqlite_conn.Close();

                        if (Math.Abs(fpremium_call - fpremium_put) > fVariation || ((fpremium_put / fpremium_call) < fratiocall))
                        {
                            strSubjectEmail = commodity + " call";
                            strEmailCommdoity = commodity;
                            strNotifyEmailBody = commodity + "   people are buying this company,  the ratio after analyze is   " + fpremium_put / fpremium_call + " on " + DateTime.Now.ToLongTimeString() + " . La frquence calculer " + frequency;
                            SendEmailGmail();

                        }
                        else if (Math.Abs(fpremium_call - fpremium_put) < fVariationPut || ((fpremium_put / fpremium_call) > fratioput))
                        {
                            strSubjectEmail = commodity + " put ";
                            strEmailCommdoity = commodity;
                            strNotifyEmailBody = commodity + "   people are selling this company, the ratio after analyze is  " + fpremium_put / fpremium_call + " on " + DateTime.Now.ToLongTimeString() + " . La frequence calculer " + frequency;
                            SendEmailGmail();
                        }
                    }
                }
            }
        }

        private void DownloadPairDetailsFromCommoditySplit(string commodity, int nbasicprogress)
        {
            premium_call_array.Clear();
            premium_put_array.Clear();
            int fromIndex = int.Parse(textBoxFromIndex.Text);
            int EndIndex = int.Parse(textBoxIndexEnd.Text);

            if (!isCommodity)
            {
                arrExpiration.Clear();
                string url = getHomeUrl(commodity, -1);
                webView1.Url = url;
                sleep(3000);
                while (arrExpiration.Count < 6 && backgroundWorker1.CancellationPending == false)
                {
                    sleep(500);
                    getExpiration();
                }

                if (arrExpiration.Count == 0)
                    return;
            }

            int nDelta = EndIndex - fromIndex;
            for (int nMonthIndex = fromIndex; nMonthIndex <= EndIndex; nMonthIndex+=nDelta)
            {
                backgroundWorker1.ReportProgress(nbasicprogress + nMonthIndex);

                if (backgroundWorker1.CancellationPending == true) break;

                string url = getHomeUrl(commodity, nMonthIndex);
                if (url.Length == 0) continue;

                webView1.Url = url;
                Console.WriteLine(url);
                sleep(2000);

                bool isExistOption = true;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Safari/537.36";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                request.PreAuthenticate = true;

                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                var json = myStreamReader.ReadToEnd();
                var headers = response.Headers;


                string laravel_token = "";
                string xsrf_token = "";
                string laravel_session = "";
                string market = "";

                foreach (var header in headers)
                {
                    IEnumerable<string> values;
                    string HeaderItemValue = "";
                    values = response.Headers.GetValues(header.ToString());

                    foreach (var valueItem in values)
                    {
                        HeaderItemValue = HeaderItemValue + valueItem + ";";
                    }

                    Console.WriteLine(header + " : " + HeaderItemValue);
                    if ((string)header == "Set-Cookie")
                    {
                        string[] token_datas = HeaderItemValue.Split(';');
                        foreach (string token in token_datas)
                        {
                            if (token.ToLower().Contains("token") || token.Contains("session") || token.Contains("market"))
                            {
                                if (token.Contains("laravel_token"))
                                {
                                    laravel_token = token.Split('=')[1];
                                }
                                if (token.Contains("laravel_session"))
                                {
                                    laravel_session = token.Split('=')[1];
                                }
                                if (token.Contains("XSRF-TOKEN"))
                                {
                                    xsrf_token = token.Split('=')[1];
                                    xsrf_token = xsrf_token.Remove(xsrf_token.Length - 3);
                                    xsrf_token.Insert(xsrf_token.Length, "=");
                                }
                                if (token.Contains("market"))
                                {
                                    market = token.Split('=')[1];
                                }
                            }
                        }
                    }
                }

                string prefix = "https://www.barchart.com/proxies/core-api/v1/quotes/get?symbol=D6";
                string suffix = "&list=futures.options&fields=strike%2ChighPrice%2ClowPrice%2ClastPrice%2CpriceChange%2CbidPrice%2CaskPrice%2Cvolume%2CopenInterest%2Cpremium%2CtradeTime%2ClongSymbol%2CsymbolCode%2CsymbolType%2ChasOptions&meta=field.shortName%2Cfield.description%2Cfield.shortName%2Cfield.type%2Clists.lastUpdate&orderBy=strike&orderDir=asc&hasOptions=true&raw=1";

                string mon = url.Substring(53, 3), year = url.Substring(57, 2), request_url = "", mid = "";
                switch (mon)
                {
                    case "jan":
                        mid = "F"; break;
                    case "feb":
                        mid = "G"; break;
                    case "mar":
                        mid = "H"; break;
                    case "apr":
                        mid = "J"; break;
                    case "may":
                        mid = "K"; break;
                    case "jun":
                        mid = "M"; break;
                    case "jul":
                        mid = "N"; break;
                    case "aug":
                        mid = "Q"; break;
                    case "sep":
                        mid = "U"; break;
                    case "oct":
                        mid = "V"; break;
                    case "nov":
                        mid = "X"; break;
                    case "dec":
                        mid = "Z"; break;
                }

                request_url = prefix + mid + year + suffix;
                request = (HttpWebRequest)WebRequest.Create(request_url);

                request.Method = "GET";
                request.Referer = url;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Safari/537.36";
                string cookie = "market=" + market + "; laravel_token=" + laravel_token + "; XSRF-TOKEN=" + xsrf_token + "; laravel_session=" + laravel_session + ";";
                request.Accept = "application/json";
                request.Headers.Add("X-xsrf-token", xsrf_token);
                request.Headers.Add("Cookie", cookie);

                response = request.GetResponse();
                responseStream = response.GetResponseStream();
                myStreamReader = new StreamReader(responseStream, Encoding.Default);
                string jsonString = myStreamReader.ReadToEnd();

                JObject obj = JObject.Parse(jsonString);

              

                if (jsonString != null)
                {
                    int columnCount;

                    if (!isStaked)
                    {
                        if (isCommodity)
                            columnCount = 11;
                        else
                            columnCount = 19;
                    }

                    string tableContent = "11";

                    for (int i = 0; i < Int32.Parse(obj["count"].ToString()); i++)
                    {
                        //   Console.WriteLine(obj["data"][i]["strike"]);
                        tableContent += "_" + obj["data"][i]["strike"];
                        tableContent += "_" + obj["data"][i]["highPrice"];
                        tableContent += "_" + obj["data"][i]["lowPrice"];
                        tableContent += "_" + obj["data"][i]["lastPrice"];
                        tableContent += "_" + obj["data"][i]["priceChange"];
                        tableContent += "_" + obj["data"][i]["bidPrice"];
                        tableContent += "_" + obj["data"][i]["askPrice"];
                        tableContent += "_" + obj["data"][i]["volumn"];
                        tableContent += "_" + obj["data"][i]["openInterest"];
                        tableContent += "_" + obj["data"][i]["premium"];
                        tableContent += "_" + obj["data"][i]["tradeTime"];
                    }

                    processTable(nMonthIndex, tableContent, commodity);
                    if (isExistOption)
                        processPremiumPutandCall(commodity, nMonthIndex);
                }


               
               
            }
        }

        private void DownloadPairDetailsFromCommodity(string commodity, int nbasicprogress)
        {
            premium_call_array.Clear();
            premium_put_array.Clear();
            int fromIndex = int.Parse(textBoxFromIndex.Text);
            int EndIndex = int.Parse(textBoxIndexEnd.Text);
             
            if (!isCommodity)
            {
                arrExpiration.Clear();
                string url = getHomeUrl(commodity, -1);
                webView1.Url = url;
                sleep(3000);
                while (arrExpiration.Count < 6 && backgroundWorker1.CancellationPending == false)
                {
                    sleep(500);
                    getExpiration();
                }

                if (arrExpiration.Count == 0)
                    return;
            }

            for (int nMonthIndex = fromIndex; nMonthIndex <= EndIndex; nMonthIndex++)
            {
                backgroundWorker1.ReportProgress(nbasicprogress + nMonthIndex);

                if (backgroundWorker1.CancellationPending == true) break;

                string url = getHomeUrl(commodity, nMonthIndex);
                if (url.Length == 0) continue;
               
                webView1.Url = url;
                Console.WriteLine(url);
                sleep(2000);

                bool isExistOption = true;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";               
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Safari/537.36";                
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                request.PreAuthenticate = true;

                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                var json = myStreamReader.ReadToEnd();
                var headers = response.Headers;


                string laravel_token = "";
                string xsrf_token = "";
                string laravel_session = "";
                string market = "";

                foreach (var header in headers)
                {
                    IEnumerable<string> values;
                    string HeaderItemValue = "";
                    values = response.Headers.GetValues(header.ToString());

                    foreach (var valueItem in values)
                    {
                        HeaderItemValue = HeaderItemValue + valueItem + ";";
                    }

                    Console.WriteLine(header + " : " + HeaderItemValue);
                    if ((string)header == "Set-Cookie")
                    {
                        string[] token_datas = HeaderItemValue.Split(';');
                        foreach (string token in token_datas)
                        {
                            if (token.ToLower().Contains("token") || token.Contains("session") || token.Contains("market"))
                            {
                                if (token.Contains("laravel_token"))
                                {
                                    laravel_token = token.Split('=')[1];
                                }
                                if (token.Contains("laravel_session"))
                                {
                                    laravel_session = token.Split('=')[1];
                                }
                                if (token.Contains("XSRF-TOKEN"))
                                {
                                    xsrf_token = token.Split('=')[1];
                                    xsrf_token = xsrf_token.Remove(xsrf_token.Length - 3);
                                    xsrf_token.Insert(xsrf_token.Length, "=");
                                }
                                if (token.Contains("market"))
                                {
                                    market = token.Split('=')[1];
                                }
                            }
                        }
                    }
                }

                string sx = pair_map_commidity[commodity].Substring(0,2);
                string prefix = "https://www.barchart.com/proxies/core-api/v1/quotes/get?symbol=" + sx;
                string suffix = "&list=futures.options&fields=strike%2ChighPrice%2ClowPrice%2ClastPrice%2CpriceChange%2CbidPrice%2CaskPrice%2Cvolume%2CopenInterest%2Cpremium%2CtradeTime%2ClongSymbol%2CsymbolCode%2CsymbolType%2ChasOptions&meta=field.shortName%2Cfield.description%2Cfield.shortName%2Cfield.type%2Clists.lastUpdate&orderBy=strike&orderDir=asc&hasOptions=true&raw=1";

                string mon = url.Substring(53, 3), year = url.Substring(57, 2), request_url = "", mid = "";
                switch (mon)
                {
                    case "jan":
                        mid = "F"; break;
                    case "feb":
                        mid = "G"; break;
                    case "mar":
                        mid = "H"; break;
                    case "apr":
                        mid = "J"; break;
                    case "may":
                        mid = "K"; break;
                    case "jun":
                        mid = "M"; break;
                    case "jul":
                        mid = "N"; break;
                    case "aug":
                        mid = "Q"; break;
                    case "sep":
                        mid = "U"; break;
                    case "oct":
                        mid = "V"; break;
                    case "nov":
                        mid = "X"; break;
                    case "dec":
                        mid = "Z"; break;
                }

                request_url = prefix + mid + year + suffix;
                request = (HttpWebRequest)WebRequest.Create(request_url);

                request.Method = "GET";
                request.Referer = url;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Safari/537.36";
                string cookie = "market=" + market + "; laravel_token=" + laravel_token + "; XSRF-TOKEN=" + xsrf_token + "; laravel_session=" + laravel_session + ";";
                request.Accept = "application/json";
                request.Headers.Add("X-xsrf-token", xsrf_token);
                request.Headers.Add("Cookie", cookie);

                response = request.GetResponse();
                responseStream = response.GetResponseStream();
                myStreamReader = new StreamReader(responseStream, Encoding.Default);
                string jsonString = myStreamReader.ReadToEnd();

                JObject obj = JObject.Parse(jsonString);

                for (int i = 0; i < Int32.Parse(obj["count"].ToString()); i++)
                {
                    Console.WriteLine(obj["data"][i]["strike"]);
                }

                if (jsonString != null && obj["count"].ToString() != "0")
                {
                    int columnCount;

                    if (!isStaked)
                    {
                        if (isCommodity)
                            columnCount = 11;
                        else
                            columnCount = 19;
                    }

                    string tableContent = "11";

                    for (int i = 0; i < Int32.Parse(obj["count"].ToString()); i++)
                    {
                        //   Console.WriteLine(obj["data"][i]["strike"]);
                        tableContent += "_" + obj["data"][i]["strike"];
                        tableContent += "_" + obj["data"][i]["highPrice"];
                        tableContent += "_" + obj["data"][i]["lowPrice"];
                        tableContent += "_" + obj["data"][i]["lastPrice"];
                        tableContent += "_" + obj["data"][i]["priceChange"];
                        tableContent += "_" + obj["data"][i]["bidPrice"];
                        tableContent += "_" + obj["data"][i]["askPrice"];
                        tableContent += "_" + obj["data"][i]["volumn"];
                        tableContent += "_" + obj["data"][i]["openInterest"];
                        tableContent += "_" + obj["data"][i]["premium"];
                        tableContent += "_" + obj["data"][i]["tradeTime"];
                    }

                    processTable(nMonthIndex, tableContent, commodity);
                    if (isExistOption)
                        processPremiumPutandCall(commodity, nMonthIndex);
                }


                /*
                 if (isExistinTable(commodity, nMonthIndex) == false)

                {
                    item_monthid = nMonthIndex;

                    string tableContent = "";
                    string htmlPage = "";
                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    htmlDocument.OptionFixNestedTags = true;
                    HtmlNodeCollection tables = null;
                    HtmlNodeCollection divResults = null;

                    while (tables == null && isExistOption == true && 
                        (divResults == null || divResults.Count < 6) && 
                        backgroundWorker1.CancellationPending == false)
                    {
                        sleep(1000);
                        htmlPage = webView1.GetHtml();
                        htmlDocument.LoadHtml(htmlPage);
                        tables = htmlDocument.DocumentNode.SelectNodes("//table");
                        divResults = htmlDocument.DocumentNode.SelectNodes("//div[@class='bc-futures-options-quotes-totals__data-row']");

                        HtmlNodeCollection divErrors = htmlDocument.DocumentNode.SelectNodes("//div[@class='error-text']");
                        if (divErrors != null)
                        {
                            foreach (HtmlNode divError in divErrors)
                            {
                                if (divError.InnerText.IndexOf("No options were found for") >= 0 ||
                                    divError.InnerText.IndexOf("does not have any options") >= 0)
                                {
                                    isExistOption = false;
                                    break;
                                }
                            }
                        }
                    }

                    sleep(500);
                    htmlPage = webView1.GetHtml();

                    htmlDocument.LoadHtml(htmlPage);



                    //var scraper = new HtmlWeb();
                    //var page = scraper.Load(url);
                    //var tableID = page.GetElementbyId("_root");

                    //tables = htmlDocument.DocumentNode.SelectNodes("//table");
                    //htmlDocument = new HtmlWeb().Load(url);
                    //tables = htmlDocument.DocumentNode.SelectNodes("//div[@class='bc-datatable ng-isolate-scope']");





    
                    if (tables != null && tables.Count >= 2)
                    {
                        HtmlNode table = tables[0];
                        if (!isStaked) {                            
                            table = isCommodity ? tables[1] : tables[2];
                        }                            
                        HtmlNodeCollection ths = table.SelectNodes(".//th");
                        if (ths != null)
                        {
                            int columnIndex = 0;
                            int columnCount = ths.Count;

                            if (!isStaked)
                            {
                                if (isCommodity)
                                    columnCount = 11;
                                else
                                    columnCount = 19;
                            }
                            tableContent = (columnCount - 1).ToString() + "_";
                            if (!isStaked)
                            {
                                tableContent = (columnCount - 2).ToString() + "_";
                            }
                            HtmlNodeCollection trs = table.SelectNodes(".//tr/td");
                            if (trs != null)
                            {
                                foreach (var cell in trs) // **notice the .**
                                {
                                    string someVariable = cell.InnerText.Replace("\n", "");
                                    if (someVariable.Contains("Overview") == false)
                                    {
                                        string tablecell = someVariable.Trim();
                                        if (columnIndex < columnCount - 1)
                                            tableContent += (tablecell + "_");                                        
                                    }
                                    columnIndex++;
                                    if (columnIndex >= columnCount)
                                        columnIndex = 0;
                                }

                                processTable(nMonthIndex, tableContent, commodity);                                
                            }
                        }

                        if (!isCommodity && isStaked)
                        {
                            table = tables[1];
                            ths = table.SelectNodes(".//th");
                            if (ths != null)
                            {
                                int columnIndex = 0;
                                int columnCount = ths.Count;
                                tableContent = (columnCount - 1).ToString() + "_";
                                HtmlNodeCollection trs = table.SelectNodes(".//tr/td");
                                if (trs != null)
                                {
                                    foreach (var cell in trs) // **notice the .**
                                    {
                                        string someVariable = cell.InnerText.Replace("\n", "");
                                        string tablecell = someVariable.Trim();
                                        if (columnIndex < columnCount - 1)
                                            tableContent += (tablecell + "_");
                                        columnIndex++;
                                        if (columnIndex >= columnCount)
                                            columnIndex = 0;
                                    }

                                    processTable(nMonthIndex, tableContent, commodity, false);
                                }
                            }
                        }

                        divResults = htmlDocument.DocumentNode.SelectNodes("//div[@class='bc-futures-options-quotes-totals__data-row']");
                        if (divResults != null && divResults.Count == 6)
                        {
                            string strPutPremiumTotal = "";
                            string strCallPremiumTotal = "";
                            string strPremiumRatio = "";
                            string strPutInterestTotal = "";
                            string strCallInterestTotal = "";
                            string strInterestRatio = "";

                            HtmlNode strong1 = divResults[0].SelectSingleNode("strong");
                            if (strong1 != null)
                                strPutPremiumTotal = strong1.InnerText;

                            HtmlNode strong2 = divResults[1].SelectSingleNode("strong");
                            if (strong2 != null)
                                strCallPremiumTotal = strong2.InnerText;

                            HtmlNode strong3 = divResults[2].SelectSingleNode("strong");
                            if (strong3 != null)
                                strPremiumRatio = strong3.InnerText;

                            HtmlNode strong4 = divResults[3].SelectSingleNode("strong");
                            if (strong4 != null)
                                strPutInterestTotal = strong4.InnerText;

                            HtmlNode strong5 = divResults[4].SelectSingleNode("strong");
                            if (strong5 != null)
                                strCallInterestTotal = strong5.InnerText;

                            HtmlNode strong6 = divResults[5].SelectSingleNode("strong");
                            if (strong6 != null)
                                strInterestRatio = strong6.InnerText;

                            strPutPremiumTotal = strPutPremiumTotal.Trim().Replace(",", "");
                            strCallPremiumTotal = strCallPremiumTotal.Trim().Replace(",", "");
                            strPremiumRatio = strPremiumRatio.Trim().Replace(",", "");
                            strPutInterestTotal = strPutInterestTotal.Trim().Replace(",", "");
                            strCallInterestTotal = strCallInterestTotal.Trim().Replace(",", "");
                            strInterestRatio = strInterestRatio.Trim().Replace(",", "");

                            if (processRatios(commodity, nMonthIndex, strPutPremiumTotal, strCallPremiumTotal, strPremiumRatio,
                                strPutInterestTotal, strCallInterestTotal, strInterestRatio) == false)
                                break;

                        }
                    }


                }
                */
                           
            }
        }

        public float getCurrentPrice(string url)
        {
            float currentPrice = 0;
            if (webView1.Url != url)
            {
                webView1.Url = url;
                sleep(2000);
             }

            string htmlPage = "";
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlPage = webView1.GetHtml();
            htmlDocument.LoadHtml(htmlPage);
            HtmlNodeCollection spans = htmlDocument.DocumentNode.SelectNodes("//span[@data-ng-class]");
            foreach (HtmlNode span in spans)
            {
                try
                {
                    if (span.Attributes["data-ng-class"].Value == "highlightValue('lastPrice')")
                    {
                        string txtPrice = span.InnerText.Replace("s", "").Replace("-", ".");
                        currentPrice = float.Parse(txtPrice);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return currentPrice;
        }

        public float getPremiumCall(float currentprice, float unit)
        {
            float fcall = 0;

            return fcall;
        }

        public float getPremiumPut(float currentprice, float unit)
        {
            float fput = 0;

            return fput;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Please input user Id", "Alert");
            }
            else if (txtPwd.Text == "")
            {
                MessageBox.Show("Please input user password", "Alert");
            }
            else if (txtPwdConfirm.Text == "" || txtPwdConfirm.Text != txtPwd.Text)
            {
                MessageBox.Show("Please confirm password correctly", "Alert");
            }
            else
            {
            if (nMode == mode_download_pair_sel)
            {
                int nProgress = 0;
                for (int i = 0; i < selected_pair_array.Count; i++)
                {
                    if (checkBox1.Checked)
                    {
                        DownloadPairDetailsFromCommoditySplit(selected_pair_array[i], nProgress);
                    }
                    else
                    {
                        DownloadPairDetailsFromCommodity(selected_pair_array[i], nProgress);
                    }
                    nProgress += 50;
                }
                nMode = mode_notworking;
            }
            else
            {
                int nLastDeletedHour = -1;
                while (backgroundWorker1.CancellationPending == false)
                {
                    Thread.Sleep(1000);
                    if (isDelete)
                    {
                        if (DateTime.Now.Day == 1 && DateTime.Now.Hour != nLastDeletedHour)
                        {
                            if (deleteDetailsTable() > 0)
                            {
                                Invoke(new Action(() => {
                                    txtLastDeleteTime.Text = DateTime.Now.ToShortTimeString();
                                }));
                            }
                            nLastDeletedHour = DateTime.Now.Hour;
                        }
                    }


                    if (isDownloadAll)
                    {                            
                        if (DateTime.Now.Hour % 12 == nDownloadHour)
                        {
                            Invoke(new Action(() => {
                                txtLastDownTime.Text = DateTime.Now.ToShortTimeString();
                                lblCurrentStatus.Text = "Downloading All Pairs details ...";
                            }));

                            int nProgress = 0;
                            for (int i = 0; i < selected_pair_array.Count; i++)
                            {
                                if (checkBox1.Checked)
                                {
                                    DownloadPairDetailsFromCommoditySplit(selected_pair_array[i], nProgress);
                                    if (backgroundWorker1.CancellationPending == true) break;
                                    nProgress += 50;
                                }
                                else
                                {
                                    DownloadPairDetailsFromCommodity(selected_pair_array[i], nProgress);
                                    if (backgroundWorker1.CancellationPending == true) break;
                                    nProgress += 50;
                                }
                            }

                            Invoke(new Action(() => {
                                lblCurrentStatus.Text = "Waiting Delete or Download timing ...";
                            }));
                        }
                    }
                }
            }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (isCommodity)
            {
              groupCommodity.Enabled = true;
            }
            else
            {
                groupCompany.Enabled = true;
            }
            chkDeletePairDetails.Enabled = true;
            chkDownloadTime.Enabled = true;
            chkNotifyEmail.Enabled = true;
            cmbDownloadTime.Enabled = true;
            btnAllStart.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            nMode = mode_notworking;
            lblCurrentStatus.Text = "Stopped";

            AutoClosingMessageBox.Show("Completed !!!","Download completed",30000);
        }

        public bool login(string userId, string userpwd)
        {
            skey = "";

            string jscode = "$('#ctl01_mHolder_txtUserID').val('" + userId + "')";
            get_void_javascript(jscode);
            sleep(500);

            jscode = "$('#ctl01_mHolder_txtGlobalPassword').val('" + userpwd + "')";
            get_void_javascript(jscode);
            sleep(500);

            jscode = "$('#ctl01_mHolder_loginButton').click()";
            get_void_javascript(jscode);
            sleep(500);

            while (webView1.IsLoading)
            {
                sleep(100);
                continue;
            }
            return true;
        }

        public bool logout()
        {
            while (webView1.IsLoading)
            {
                sleep(100);
                continue;
            }

            sleep(1000);
            while (webView1.IsLoading)
            {
                sleep(130);
                continue;
            }

            DateTime lastPickTime = DateTime.Now;
            while (backgroundWorker1.CancellationPending == false)                
            {
                TimeSpan span = DateTime.Now - lastPickTime;
                if (span.TotalMilliseconds >= 1000 * 55)
                    break;
                sleep(100);
            }

            return true;
        }

        public bool reload()
        {
            if (webView1.IsLoading)
            {
              webView1.ExecCommand(0x01);
            }

            DateTime lastPickTime = DateTime.Now;
            while (backgroundWorker1.CancellationPending == false)
            {
                TimeSpan span = DateTime.Now - lastPickTime;
                if (span.TotalMilliseconds >= 1000 * 55)
                    break;
                sleep(100);
            }

            return true;
        }

        public string get_skey()
        {
            string jscode = @"var skey = document.getElementsByTagName('ebb-home')[0].getAttribute('skey'); skey;";
            return get_str_javascript(jscode);
        }

        public bool search(string option)
        {
             string jscode, strcuroption;

            jscode = @"document.getElementsByTagName('saved-search-dropdown')[0].innerText;";
            strcuroption = get_str_javascript(jscode);
            if (strcuroption.Equals(option) == false)
            {
                jscode = @"document.getElementsByTagName('saved-search-dropdown')[0].children[0].children[0].click();";
                get_void_javascript(jscode);
                sleep(500);
            }

            int noptions = 0;
            jscode = @"document.getElementsByTagName('saved-search-dropdown')[0].children[0].children[1].childElementCount;";
            noptions = get_int_javascript(jscode);

            if (noptions > 3)
            {
                for (int i = 1; i < noptions - 2; i++)
                {
                    jscode = @"document.getElementsByTagName('saved-search-dropdown')[0].children[0].children[1].children[" + i + @"].innerText;";
                    string item = get_str_javascript(jscode);

                    if (option.Equals(item))
                    {
                        jscode = @"document.getElementsByTagName('saved-search-dropdown')[0].children[0].children[1].children[" + i + "].children[0].click();";
                        get_void_javascript(jscode);
                        sleep(100);

                        jscode = @"document.getElementsByClassName('searchAction')[0].children[1].children[1].click();";
                        get_void_javascript(jscode);

                        sleep(2000);

                        break;
                    }
                }
            }            

            return true;
        }

        private void get_void_javascript(string jscode)
        {
            try
            {
                webView1.EvalScript(jscode);
            }
            catch (Exception ex)
            {
                writeLog("get_void_javascript error: " + ex.Message);
                writeLog(jscode);
            }
        }

        private string get_str_javascript(string jscode)
        {
            string result = "";
            try
            {
                 result = (string)webView1.EvalScript(jscode);
            }
            catch (Exception ex)
            {
                writeLog("get_str_javascript error: " + ex.Message);
                writeLog(jscode);
            }
            return result;
        }

        private bool get_bool_javascript(string jscode)
        {
              bool result = false;
            try
            {
                result = (bool)webView1.EvalScript(jscode);
            }
            catch (Exception ex)
            {
                writeLog("get_bool_javascript error: " + ex.Message);
                writeLog(jscode);
            }
            return result;            
        }

        private int get_int_javascript(string jscode)
        {
            int result = 0;
            try
            {
                 result = (int)webView1.EvalScript(jscode);
            }
            catch (Exception ex)
            {
                writeLog("get_int_javascript error: " + ex.Message);
                writeLog(jscode);
            }
            return result;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkEOTrial())
            {
                timer1.Stop();
            }
        }

        public void sleep(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }

        private void btnStopAlert_Click(object sender, EventArgs e)
        {
            if (player != null)
            player.Stop();
        }

        private void writeLog(String strLog)
        {
        }

        public void getExpiration()
        {
            arrExpiration.Clear();

            string jscode = @"document.getElementsByClassName('clearfix left bc-dropdown filter expiration-name')[0].children[0].length";
            int ncount = get_int_javascript(jscode);

            if (ncount >= 6)
            {
                for (int i = 0; i < ncount; i++)
                {
                    jscode = "document.getElementsByClassName('clearfix left bc-dropdown filter expiration-name')[0].children[0].children[" + i + "].value";
                    string expiration = get_str_javascript(jscode);

                    arrExpiration.Add(expiration);
                }
            }
        }

        public string expirationDate(int nMonthIdx)
        {
            DateTime BeginDate = DateTime.Now.AddMonths(nMonthIdx);
            string strDate = BeginDate.ToString("yyyy-MM");
            for (int i = 0; i < arrExpiration.Count; i++)
            {
                if (arrExpiration[i].IndexOf(strDate) == 0 && arrExpiration[i].IndexOf('m') > 0)
                {
                    return arrExpiration[i];
                }
            }

            return "";
        }

        public string getHomeUrl(string commodity, int nMonthIdx)
        {
            string homeurl = "";
            if (isCommodity)
            {
                homeurl = "https://www.barchart.com/futures/quotes/";
                if (pair_map_commidity.ContainsKey(commodity))
                {
                    homeurl += (pair_map_commidity[commodity] + "/options/");

                    DateTime BeginDate = DateTime.Now.AddMonths(nMonthIdx);
                    string strMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(BeginDate.Month);
                    string strYear = BeginDate.Year.ToString().Substring(2);
                    string strMonthId = strMonth.ToLower() + "-" + strYear;

                    homeurl += strMonthId;
                    if (isStaked)
                        homeurl += "?futuresOptionsView=merged";
                    else
                        homeurl += "?futuresOptionsView=split";
                }
            }
            else
            {
            homeurl = "https://www.barchart.com/stocks/quotes/";
            if (pair_map_savedcompany.ContainsKey(commodity))
            {
                homeurl += (pair_map_savedcompany[commodity] + "/options");
                if (nMonthIdx > 0)
                {
                    string strExpDate = expirationDate(nMonthIdx);
                    if (strExpDate.Length > 0)
                        homeurl += ("?expiration=" + strExpDate);
                    else
                        homeurl = "";
                }
                if (homeurl.Contains("?expiration"))
                {
                    if (isStaked && homeurl.Length > 0)
                        homeurl += "&futuresOptionsView=merged&view=stacked";
                    else
                        homeurl += "&futuresOptionsView=merged&view=sbs";
                }
                else
                {
                    if (isStaked && homeurl.Length > 0)
                        homeurl += "?futuresOptionsView=merged&view=stacked";
                    else
                        homeurl += "?futuresOptionsView=merged&view=sbs";
                }
            }
            }

            return homeurl;
        }

        private void webView1_LoadCompleted(object sender, EO.WebBrowser.LoadCompletedEventArgs e)
        {
            string urlPage = webView1.Url;
            if (urlPage == url_home)
            {
                pair_map_commidity.Clear();
                treeCommodity.Nodes.Clear();
                TreeNode rootNode = treeCommodity.Nodes.Add("All Categories");

                string htmlPage = webView1.GetHtml();

                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(htmlPage);

                HtmlNodeCollection selects = htmlDocument.DocumentNode.SelectNodes("//select");
                if (selects != null)
                {
                    HtmlNode select = selects[0];
                    HtmlNodeCollection optionGroups = select.SelectNodes(".//optgroup");
                    foreach (HtmlNode optionGroup in optionGroups)
                    {
                        string groupLabel = optionGroup.GetAttributeValue("label", "");
                        TreeNode optNode = rootNode.Nodes.Add(groupLabel);

                        HtmlNodeCollection options = optionGroup.SelectNodes(".//option");
                        foreach (HtmlNode option in options)
                        {
                            string value = option.GetAttributeValue("value", "");
                            if (value.Length > 0)
                            {
                                string commodity = option.InnerText;
                                string pairurl = value.Replace("/futures/quotes/", "").Replace("/futures-prices", "");
                                optNode.Nodes.Add(commodity);
                                pair_map_commidity.Add(groupLabel + "_" + commodity, pairurl);
                            }
                        }
                    }
                }
                rootNode.Expand();

                dataViewToolStripMenuItem.Enabled = true;
                btnStart.Enabled = true;
                btnAllStart.Enabled = true;
                lblCurrentStatus.Text = "Stopped";
                timer1.Start();
            }            
        }

        private void treeCommodity_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selected_pair_array.Clear();
            if (treeCommodity.SelectedNode.Level == 0)
            {
                txtCurCommodity.Text = "All Pairs in " + treeCommodity.SelectedNode.Text;             
                foreach (TreeNode category in treeCommodity.Nodes[0].Nodes)
                {
                    foreach (TreeNode pair in category.Nodes)
                    {
                        string selectedNode = pair.Parent.Text + "_" + pair.Text;
                        selected_pair_array.Add(selectedNode);
                    }
                }
            }
            else if (treeCommodity.SelectedNode.Level == 1)
            {
                txtCurCommodity.Text = "Selected Category: " + treeCommodity.SelectedNode.Text;
                selected_pair_array.Clear();

                foreach (TreeNode pair in treeCommodity.SelectedNode.Nodes)
                {
                    string selectedNode = pair.Parent.Text + "_" + pair.Text;
                    selected_pair_array.Add(selectedNode);
                }
            }            
            else
            {
                txtCurCommodity.Text = "Selected Pair: " + treeCommodity.SelectedNode.Text;
                string selectedNode = treeCommodity.SelectedNode.Parent.Text + "_" + treeCommodity.SelectedNode.Text;
                selected_pair_array.Add(selectedNode);
            }

            lblSelectedCount.Text = "Selected: " + selected_pair_array.Count.ToString();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
             toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void dataViewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void emailNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboard to = new Dashboard();
            to.Show();
        }

        private void dataviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void chkDownloadTime_CheckedChanged(object sender, EventArgs e)
        {
            isDownloadAll = chkDownloadTime.Checked;
        }

        private void chkDeletePairDetails_CheckedChanged(object sender, EventArgs e)
         {
             isDelete = chkDeletePairDetails.Checked;
        }

        public void SendEmailGmail()
        {
            if (isNotifyEmail)
            {
                var fromAddress = new MailAddress("emianouatfood@gmail.com","M"+ DateTime.Now.ToShortDateString()+strEmailCommdoity);
                var toAddress = new MailAddress(strNotifyEmailAddr, " LE PDG");
                const string fromPassword = "Quebec2018!";
                string subject = strSubjectEmail;
                string body = strNotifyEmailBody;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),

                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    try
                    {
                        smtp.Send(message);
                    }
                    catch (Exception)
                    {
                    }                    
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void premiunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Premiun to = new Premiun(this, true);
            to.Show();
        }

        private void pairDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataView to = new DataView(true);
            to.Show();
        }

        private void pairStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pair_statistics to = new Pair_statistics(true);
            to.Show();
        }

        private void txtVariationCond_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDownloadTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            textBoxTimer2.Text = DateTime.Now.ToLongTimeString();


            if (backgroundWorker1.IsBusy)
            {
                AutoClosingMessageBox.Show("The process will be kill and start over", "caption", 12000);
                backgroundWorker1.CancelAsync();

            }

            downloadselect1();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxFrequency_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTimer2_TextChanged(object sender, EventArgs e)
        {

        }

        private void webControl1_Click(object sender, EventArgs e)
        {

        }

        private void webView1_CertificateError(object sender, CertificateErrorEventArgs e)
        {
             e.Continue();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBoxIndexEnd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchCompany_Click(object sender, EventArgs e)
        {
            companyNameList.Clear();
            companySymbolList.Clear();
            cmbSearchResult.Items.Clear();

            if (txtSearchCompany.Text.Length > 0)
            {
            using (var client = new WebClient())
            {
                string http_query = "https://instruments-prod.aws.barchart.com/instruments/search/" + txtSearchCompany.Text.ToLower() + "?region=us";
                string responseString = client.DownloadString(http_query);
                dynamic dynObj = JsonConvert.DeserializeObject(responseString);

                if (dynObj != null)
                {
                    foreach (var instrument in dynObj.instruments)
                    {
                        string symbol = (string)instrument.symbol;
                        string name = (string)instrument.name;

                        companyNameList.Add(name);
                        companySymbolList.Add(symbol);                            
                        cmbSearchResult.Items.Add("Company: " + name + ", Symbol: " + symbol);
                    }

                    if (cmbSearchResult.Items.Count > 0)
                        cmbSearchResult.SelectedIndex = 0;
                }
            }                               
            }
        }

        private void cmbSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIndex = cmbSearchResult.SelectedIndex;
            if (nIndex >= 0 && nIndex < companyNameList.Count)
            {
                txtSelectedCompanyName.Text = companyNameList[nIndex];
                txtSelectedCompanyId.Text = companySymbolList[nIndex];                         
            }
        }

        private void webView1_UrlChanged(object sender, EventArgs e)
        {
            textBox1.Text = webView1.Url;
        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            if (txtSelectedCompanyName.Text.Length > 0 && txtSelectedCompanyId.Text.Length > 0)
            {
                try
                {
                    string[] row = { txtSelectedCompanyName.Text, txtSelectedCompanyId.Text };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                    pair_map_savedcompany.Add(txtSelectedCompanyName.Text + "_" + txtSelectedCompanyId.Text, txtSelectedCompanyId.Text);
                }
                catch (Exception)
                {

                }                
            }
        }

        private void btnRemoveCompany_Click(object sender, EventArgs e)
        {
            try
            {
            var selectedItems = this.listView1.CheckedItems
                                 .Cast<ListViewItem>()
                                 .Select(x => x);

            foreach (ListViewItem item in selectedItems)
                item.Remove();
            }
            catch (Exception)
            {
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            selected_pair_array.Clear();

            try
            {
                var selectedItems = this.listView1.CheckedItems
                                 .Cast<ListViewItem>()
                                 .Select(x => x);

                foreach (ListViewItem item in selectedItems)
                {
                    selected_pair_array.Add(item.SubItems[0].Text + "_" + item.SubItems[1].Text);
                }
            }
            catch (Exception)
            {
            }                 
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Premiun to = new Premiun(this, false);
            to.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
            {
            DataView to = new DataView(false);
            to.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Pair_statistics to = new Pair_statistics(false);
            to.Show();
        }

        private void cmbCommodity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCommodity.SelectedIndex == 0)
            {
                isCommodity = true;
                groupCommodity.Enabled = true;
                groupCompany.Enabled = false;
            }
            else
            {
                isCommodity = false;
                groupCommodity.Enabled = false;
                groupCompany.Enabled = true;
            }
        }

        private void cmbStaked_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (cmbStaked.SelectedIndex == 0)
            {
            isStaked = true;
            }
            else
            {
            isStaked = false;
            }
        }
    }
}
