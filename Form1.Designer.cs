namespace PairDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webControl1 = new EO.WinForm.WebControl();
            this.webView1 = new EO.WebBrowser.WebView();
            this.groupCommodity = new System.Windows.Forms.GroupBox();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.txtCurCommodity = new System.Windows.Forms.TextBox();
            this.treeCommodity = new System.Windows.Forms.TreeView();
            this.txtPwdConfirm = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataviewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.premiunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pairDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pairStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailNotificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbDownloadTime = new System.Windows.Forms.ComboBox();
            this.chkDownloadTime = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDeletePairDetails = new System.Windows.Forms.CheckBox();
            this.btnAllStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLastDownTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLastDeleteTime = new System.Windows.Forms.TextBox();
            this.chkNotifyEmail = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCurrentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.txtNotifyEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPremiumUnit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVariationCond = new System.Windows.Forms.TextBox();
            this.textboxVariationPut = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBoxTimer2 = new System.Windows.Forms.TextBox();
            this.textBoxIntervalDownload = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxRatioCall = new System.Windows.Forms.TextBox();
            this.textBoxRatioPut = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxFromIndex = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxIndexEnd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmailBody = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1btc = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbStaked = new System.Windows.Forms.ComboBox();
            this.cmbCommodity = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupCompany = new System.Windows.Forms.GroupBox();
            this.btnRemoveCompany = new System.Windows.Forms.Button();
            this.btnAddCompany = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSelectedCompanyId = new System.Windows.Forms.TextBox();
            this.txtSelectedCompanyName = new System.Windows.Forms.TextBox();
            this.cmbSearchResult = new System.Windows.Forms.ComboBox();
            this.btnSearchCompany = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchCompany = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBoxRule3 = new System.Windows.Forms.CheckBox();
            this.groupCommodity.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupCompany.SuspendLayout();
            this.SuspendLayout();
            // 
            // webControl1
            // 
            this.webControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webControl1.BackColor = System.Drawing.SystemColors.WindowText;
            this.webControl1.Location = new System.Drawing.Point(586, 66);
            this.webControl1.Name = "webControl1";
            this.webControl1.Size = new System.Drawing.Size(702, 624);
            this.webControl1.TabIndex = 0;
            this.webControl1.Text = "webControl1";
            this.webControl1.WebView = this.webView1;
            this.webControl1.Click += new System.EventHandler(this.webControl1_Click);
            // 
            // webView1
            // 
            this.webView1.InputMsgFilter = null;
            this.webView1.ObjectForScripting = null;
            this.webView1.Title = null;
            this.webView1.UrlChanged += new System.EventHandler(this.webView1_UrlChanged);
            this.webView1.CertificateError += new EO.WebBrowser.CertificateErrorHandler(this.webView1_CertificateError);
            this.webView1.LoadCompleted += new EO.WebBrowser.LoadCompletedEventHandler(this.webView1_LoadCompleted);
            // 
            // groupCommodity
            // 
            this.groupCommodity.Controls.Add(this.lblSelectedCount);
            this.groupCommodity.Controls.Add(this.txtCurCommodity);
            this.groupCommodity.Controls.Add(this.treeCommodity);
            this.groupCommodity.Controls.Add(this.txtPwdConfirm);
            this.groupCommodity.Controls.Add(this.txtPwd);
            this.groupCommodity.Controls.Add(this.label2);
            this.groupCommodity.Controls.Add(this.label1);
            this.groupCommodity.Controls.Add(this.txtId);
            this.groupCommodity.Location = new System.Drawing.Point(12, 34);
            this.groupCommodity.Name = "groupCommodity";
            this.groupCommodity.Size = new System.Drawing.Size(267, 446);
            this.groupCommodity.TabIndex = 1;
            this.groupCommodity.TabStop = false;
            this.groupCommodity.Text = "Commidity";
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.Location = new System.Drawing.Point(7, 80);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSelectedCount.Size = new System.Drawing.Size(55, 13);
            this.lblSelectedCount.TabIndex = 6;
            this.lblSelectedCount.Text = "Selected: ";
            this.lblSelectedCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCurCommodity
            // 
            this.txtCurCommodity.Location = new System.Drawing.Point(88, 77);
            this.txtCurCommodity.Name = "txtCurCommodity";
            this.txtCurCommodity.ReadOnly = true;
            this.txtCurCommodity.Size = new System.Drawing.Size(173, 20);
            this.txtCurCommodity.TabIndex = 5;
            // 
            // treeCommodity
            // 
            this.treeCommodity.Location = new System.Drawing.Point(6, 103);
            this.treeCommodity.Name = "treeCommodity";
            this.treeCommodity.Size = new System.Drawing.Size(255, 328);
            this.treeCommodity.TabIndex = 4;
            this.treeCommodity.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeCommodity_AfterSelect);
            // 
            // txtPwdConfirm
            // 
            this.txtPwdConfirm.Location = new System.Drawing.Point(186, 51);
            this.txtPwdConfirm.Name = "txtPwdConfirm";
            this.txtPwdConfirm.PasswordChar = '*';
            this.txtPwdConfirm.Size = new System.Drawing.Size(75, 20);
            this.txtPwdConfirm.TabIndex = 3;
            this.txtPwdConfirm.Text = "kri*BH#sZY6L2Nv";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(88, 50);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(92, 20);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.Text = "kri*BH#sZY6L2Nv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Pwd";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User ID";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(88, 25);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(173, 20);
            this.txtId.TabIndex = 0;
            this.txtId.Text = "kobenan1@msn.com";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(976, 726);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 24);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(1082, 726);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 24);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Download Selected";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataViewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1302, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // dataViewToolStripMenuItem
            // 
            this.dataViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.dataviewToolStripMenuItem1,
            this.emailNotificationToolStripMenuItem});
            this.dataViewToolStripMenuItem.Name = "dataViewToolStripMenuItem";
            this.dataViewToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.dataViewToolStripMenuItem.Text = "Settings";
            this.dataViewToolStripMenuItem.Click += new System.EventHandler(this.dataViewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem1.Text = "Graph (Company)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem2.Text = "Premiun Call && Put";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem3.Text = "Pair Details";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem4.Text = "Pair Statistics";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // dataviewToolStripMenuItem1
            // 
            this.dataviewToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.premiunToolStripMenuItem,
            this.pairDetailsToolStripMenuItem,
            this.pairStatisticsToolStripMenuItem});
            this.dataviewToolStripMenuItem1.Name = "dataviewToolStripMenuItem1";
            this.dataviewToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.dataviewToolStripMenuItem1.Text = "Graph (Commodity)";
            this.dataviewToolStripMenuItem1.Click += new System.EventHandler(this.dataviewToolStripMenuItem1_Click);
            // 
            // premiunToolStripMenuItem
            // 
            this.premiunToolStripMenuItem.Name = "premiunToolStripMenuItem";
            this.premiunToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.premiunToolStripMenuItem.Text = "Premiun Call && Put";
            this.premiunToolStripMenuItem.Click += new System.EventHandler(this.premiunToolStripMenuItem_Click);
            // 
            // pairDetailsToolStripMenuItem
            // 
            this.pairDetailsToolStripMenuItem.Name = "pairDetailsToolStripMenuItem";
            this.pairDetailsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.pairDetailsToolStripMenuItem.Text = "Pair Details";
            this.pairDetailsToolStripMenuItem.Click += new System.EventHandler(this.pairDetailsToolStripMenuItem_Click);
            // 
            // pairStatisticsToolStripMenuItem
            // 
            this.pairStatisticsToolStripMenuItem.Name = "pairStatisticsToolStripMenuItem";
            this.pairStatisticsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.pairStatisticsToolStripMenuItem.Text = "Pair Statistics";
            this.pairStatisticsToolStripMenuItem.Click += new System.EventHandler(this.pairStatisticsToolStripMenuItem_Click);
            // 
            // emailNotificationToolStripMenuItem
            // 
            this.emailNotificationToolStripMenuItem.Name = "emailNotificationToolStripMenuItem";
            this.emailNotificationToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.emailNotificationToolStripMenuItem.Text = "Dashboard ";
            this.emailNotificationToolStripMenuItem.Click += new System.EventHandler(this.emailNotificationToolStripMenuItem_Click);
            // 
            // cmbDownloadTime
            // 
            this.cmbDownloadTime.FormattingEnabled = true;
            this.cmbDownloadTime.Items.AddRange(new object[] {
            "00 ",
            "01 ",
            "02 ",
            "03 ",
            "04",
            "05 ",
            "06 ",
            "07 ",
            "08 ",
            "09 ",
            "10 ",
            "11 "});
            this.cmbDownloadTime.Location = new System.Drawing.Point(150, 68);
            this.cmbDownloadTime.Name = "cmbDownloadTime";
            this.cmbDownloadTime.Size = new System.Drawing.Size(70, 21);
            this.cmbDownloadTime.TabIndex = 5;
            this.cmbDownloadTime.SelectedIndexChanged += new System.EventHandler(this.cmbDownloadTime_SelectedIndexChanged);
            // 
            // chkDownloadTime
            // 
            this.chkDownloadTime.AutoSize = true;
            this.chkDownloadTime.Location = new System.Drawing.Point(25, 70);
            this.chkDownloadTime.Name = "chkDownloadTime";
            this.chkDownloadTime.Size = new System.Drawing.Size(114, 17);
            this.chkDownloadTime.TabIndex = 6;
            this.chkDownloadTime.Text = "Download twice at";
            this.chkDownloadTime.UseVisualStyleBackColor = true;
            this.chkDownloadTime.CheckedChanged += new System.EventHandler(this.chkDownloadTime_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "AM | PM";
            // 
            // chkDeletePairDetails
            // 
            this.chkDeletePairDetails.AutoSize = true;
            this.chkDeletePairDetails.Location = new System.Drawing.Point(25, 138);
            this.chkDeletePairDetails.Name = "chkDeletePairDetails";
            this.chkDeletePairDetails.Size = new System.Drawing.Size(257, 17);
            this.chkDeletePairDetails.TabIndex = 8;
            this.chkDeletePairDetails.Text = "Delete Pair Details in Database (1th day Monthly)";
            this.chkDeletePairDetails.UseVisualStyleBackColor = true;
            this.chkDeletePairDetails.CheckedChanged += new System.EventHandler(this.chkDeletePairDetails_CheckedChanged);
            // 
            // btnAllStart
            // 
            this.btnAllStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllStart.Location = new System.Drawing.Point(1188, 726);
            this.btnAllStart.Name = "btnAllStart";
            this.btnAllStart.Size = new System.Drawing.Size(100, 24);
            this.btnAllStart.TabIndex = 9;
            this.btnAllStart.Text = "Start Monitoring";
            this.btnAllStart.UseVisualStyleBackColor = true;
            this.btnAllStart.Click += new System.EventHandler(this.btnAllStart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Last Download Time";
            // 
            // txtLastDownTime
            // 
            this.txtLastDownTime.Location = new System.Drawing.Point(150, 98);
            this.txtLastDownTime.Name = "txtLastDownTime";
            this.txtLastDownTime.ReadOnly = true;
            this.txtLastDownTime.Size = new System.Drawing.Size(121, 20);
            this.txtLastDownTime.TabIndex = 11;
            this.txtLastDownTime.Text = "0000-00-00 00:00:00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Last Delete Time";
            // 
            // txtLastDeleteTime
            // 
            this.txtLastDeleteTime.Location = new System.Drawing.Point(150, 162);
            this.txtLastDeleteTime.Name = "txtLastDeleteTime";
            this.txtLastDeleteTime.ReadOnly = true;
            this.txtLastDeleteTime.Size = new System.Drawing.Size(121, 20);
            this.txtLastDeleteTime.TabIndex = 11;
            this.txtLastDeleteTime.Text = "0000-00-00 00:00:00";
            // 
            // chkNotifyEmail
            // 
            this.chkNotifyEmail.AutoSize = true;
            this.chkNotifyEmail.Checked = true;
            this.chkNotifyEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotifyEmail.Location = new System.Drawing.Point(23, 353);
            this.chkNotifyEmail.Name = "chkNotifyEmail";
            this.chkNotifyEmail.Size = new System.Drawing.Size(122, 17);
            this.chkNotifyEmail.TabIndex = 13;
            this.chkNotifyEmail.Text = "Notify Email Address";
            this.chkNotifyEmail.UseVisualStyleBackColor = true;
            this.chkNotifyEmail.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentStatus,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 727);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1302, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(51, 17);
            this.lblCurrentStatus.Text = "Stopped";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(450, 16);
            // 
            // txtNotifyEmail
            // 
            this.txtNotifyEmail.Location = new System.Drawing.Point(148, 351);
            this.txtNotifyEmail.Name = "txtNotifyEmail";
            this.txtNotifyEmail.Size = new System.Drawing.Size(121, 20);
            this.txtNotifyEmail.TabIndex = 15;
            this.txtNotifyEmail.Text = "15062272316@msg.koodomobile.com ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 313);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Premium Unit";
            // 
            // txtPremiumUnit
            // 
            this.txtPremiumUnit.Location = new System.Drawing.Point(148, 310);
            this.txtPremiumUnit.Name = "txtPremiumUnit";
            this.txtPremiumUnit.Size = new System.Drawing.Size(121, 20);
            this.txtPremiumUnit.TabIndex = 19;
            this.txtPremiumUnit.Text = "5000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 255);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Variation Condition";
            // 
            // txtVariationCond
            // 
            this.txtVariationCond.Location = new System.Drawing.Point(148, 252);
            this.txtVariationCond.Name = "txtVariationCond";
            this.txtVariationCond.Size = new System.Drawing.Size(121, 20);
            this.txtVariationCond.TabIndex = 20;
            this.txtVariationCond.Text = "45";
            this.txtVariationCond.TextChanged += new System.EventHandler(this.txtVariationCond_TextChanged);
            // 
            // textboxVariationPut
            // 
            this.textboxVariationPut.Location = new System.Drawing.Point(148, 281);
            this.textboxVariationPut.Name = "textboxVariationPut";
            this.textboxVariationPut.Size = new System.Drawing.Size(67, 20);
            this.textboxVariationPut.TabIndex = 21;
            this.textboxVariationPut.Text = "-45";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 284);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Variation Put";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textBoxTimer2
            // 
            this.textBoxTimer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTimer2.Location = new System.Drawing.Point(621, 728);
            this.textBoxTimer2.Name = "textBoxTimer2";
            this.textBoxTimer2.Size = new System.Drawing.Size(100, 20);
            this.textBoxTimer2.TabIndex = 23;
            this.textBoxTimer2.TextChanged += new System.EventHandler(this.textBoxTimer2_TextChanged);
            // 
            // textBoxIntervalDownload
            // 
            this.textBoxIntervalDownload.Location = new System.Drawing.Point(148, 384);
            this.textBoxIntervalDownload.Name = "textBoxIntervalDownload";
            this.textBoxIntervalDownload.Size = new System.Drawing.Size(121, 20);
            this.textBoxIntervalDownload.TabIndex = 24;
            this.textBoxIntervalDownload.Text = "300000";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 732);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Last Download ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 387);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Interval of Minutes";
            // 
            // textBoxRatioCall
            // 
            this.textBoxRatioCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRatioCall.Location = new System.Drawing.Point(787, 728);
            this.textBoxRatioCall.Name = "textBoxRatioCall";
            this.textBoxRatioCall.Size = new System.Drawing.Size(50, 20);
            this.textBoxRatioCall.TabIndex = 27;
            this.textBoxRatioCall.Text = "0.55";
            // 
            // textBoxRatioPut
            // 
            this.textBoxRatioPut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRatioPut.Location = new System.Drawing.Point(904, 728);
            this.textBoxRatioPut.Name = "textBoxRatioPut";
            this.textBoxRatioPut.Size = new System.Drawing.Size(48, 20);
            this.textBoxRatioPut.TabIndex = 28;
            this.textBoxRatioPut.Text = "1.7";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(727, 732);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Ratio Call";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(844, 731);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Ratio Put";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(43, 194);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Download from";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // textBoxFromIndex
            // 
            this.textBoxFromIndex.Location = new System.Drawing.Point(150, 191);
            this.textBoxFromIndex.Name = "textBoxFromIndex";
            this.textBoxFromIndex.Size = new System.Drawing.Size(33, 20);
            this.textBoxFromIndex.TabIndex = 35;
            this.textBoxFromIndex.Text = "1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(200, 194);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "To";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // textBoxIndexEnd
            // 
            this.textBoxIndexEnd.Location = new System.Drawing.Point(239, 191);
            this.textBoxIndexEnd.Name = "textBoxIndexEnd";
            this.textBoxIndexEnd.Size = new System.Drawing.Size(32, 20);
            this.textBoxIndexEnd.TabIndex = 37;
            this.textBoxIndexEnd.Text = "6";
            this.textBoxIndexEnd.TextChanged += new System.EventHandler(this.textBoxIndexEnd_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Notify Email Body";
            // 
            // txtEmailBody
            // 
            this.txtEmailBody.Location = new System.Drawing.Point(148, 220);
            this.txtEmailBody.Multiline = true;
            this.txtEmailBody.Name = "txtEmailBody";
            this.txtEmailBody.Size = new System.Drawing.Size(121, 23);
            this.txtEmailBody.TabIndex = 16;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(144, 414);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 17);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.Text = "checkBoxOnebyOne";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1btc
            // 
            this.textBox1btc.Location = new System.Drawing.Point(46, 411);
            this.textBox1btc.Name = "textBox1btc";
            this.textBox1btc.Size = new System.Drawing.Size(39, 20);
            this.textBox1btc.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbStaked);
            this.groupBox2.Controls.Add(this.cmbCommodity);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBox1btc);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.textBoxIndexEnd);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.textBoxFromIndex);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBoxIntervalDownload);
            this.groupBox2.Controls.Add(this.txtNotifyEmail);
            this.groupBox2.Controls.Add(this.chkNotifyEmail);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textboxVariationPut);
            this.groupBox2.Controls.Add(this.txtVariationCond);
            this.groupBox2.Controls.Add(this.txtPremiumUnit);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtEmailBody);
            this.groupBox2.Controls.Add(this.txtLastDeleteTime);
            this.groupBox2.Controls.Add(this.txtLastDownTime);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chkDeletePairDetails);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.chkDownloadTime);
            this.groupBox2.Controls.Add(this.cmbDownloadTime);
            this.groupBox2.Location = new System.Drawing.Point(285, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 446);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // cmbStaked
            // 
            this.cmbStaked.FormattingEnabled = true;
            this.cmbStaked.Items.AddRange(new object[] {
            "Staked",
            "Side by Side"});
            this.cmbStaked.Location = new System.Drawing.Point(156, 28);
            this.cmbStaked.Name = "cmbStaked";
            this.cmbStaked.Size = new System.Drawing.Size(117, 21);
            this.cmbStaked.TabIndex = 42;
            this.cmbStaked.SelectedIndexChanged += new System.EventHandler(this.cmbStaked_SelectedIndexChanged);
            // 
            // cmbCommodity
            // 
            this.cmbCommodity.FormattingEnabled = true;
            this.cmbCommodity.Items.AddRange(new object[] {
            "Commodity",
            "Company"});
            this.cmbCommodity.Location = new System.Drawing.Point(50, 28);
            this.cmbCommodity.Name = "cmbCommodity";
            this.cmbCommodity.Size = new System.Drawing.Size(100, 21);
            this.cmbCommodity.TabIndex = 41;
            this.cmbCommodity.SelectedIndexChanged += new System.EventHandler(this.cmbCommodity_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Mode";
            // 
            // groupCompany
            // 
            this.groupCompany.Controls.Add(this.btnRemoveCompany);
            this.groupCompany.Controls.Add(this.btnAddCompany);
            this.groupCompany.Controls.Add(this.label20);
            this.groupCompany.Controls.Add(this.label19);
            this.groupCompany.Controls.Add(this.label18);
            this.groupCompany.Controls.Add(this.listView1);
            this.groupCompany.Controls.Add(this.txtSelectedCompanyId);
            this.groupCompany.Controls.Add(this.txtSelectedCompanyName);
            this.groupCompany.Controls.Add(this.cmbSearchResult);
            this.groupCompany.Controls.Add(this.btnSearchCompany);
            this.groupCompany.Controls.Add(this.label3);
            this.groupCompany.Controls.Add(this.txtSearchCompany);
            this.groupCompany.Location = new System.Drawing.Point(14, 490);
            this.groupCompany.Name = "groupCompany";
            this.groupCompany.Size = new System.Drawing.Size(555, 200);
            this.groupCompany.TabIndex = 41;
            this.groupCompany.TabStop = false;
            this.groupCompany.Text = "Company";
            // 
            // btnRemoveCompany
            // 
            this.btnRemoveCompany.Location = new System.Drawing.Point(184, 159);
            this.btnRemoveCompany.Name = "btnRemoveCompany";
            this.btnRemoveCompany.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCompany.TabIndex = 9;
            this.btnRemoveCompany.Text = "Remove";
            this.btnRemoveCompany.UseVisualStyleBackColor = true;
            this.btnRemoveCompany.Click += new System.EventHandler(this.btnRemoveCompany_Click);
            // 
            // btnAddCompany
            // 
            this.btnAddCompany.Location = new System.Drawing.Point(103, 159);
            this.btnAddCompany.Name = "btnAddCompany";
            this.btnAddCompany.Size = new System.Drawing.Size(75, 23);
            this.btnAddCompany.TabIndex = 8;
            this.btnAddCompany.Text = "Add";
            this.btnAddCompany.UseVisualStyleBackColor = true;
            this.btnAddCompany.Click += new System.EventHandler(this.btnAddCompany_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 129);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 13);
            this.label20.TabIndex = 7;
            this.label20.Text = "Comapny Symbol";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 96);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "Comapny Name";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(357, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Selected Company";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(271, 44);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(269, 138);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Symbol";
            this.columnHeader2.Width = 80;
            // 
            // txtSelectedCompanyId
            // 
            this.txtSelectedCompanyId.Location = new System.Drawing.Point(103, 126);
            this.txtSelectedCompanyId.Name = "txtSelectedCompanyId";
            this.txtSelectedCompanyId.ReadOnly = true;
            this.txtSelectedCompanyId.Size = new System.Drawing.Size(156, 20);
            this.txtSelectedCompanyId.TabIndex = 5;
            // 
            // txtSelectedCompanyName
            // 
            this.txtSelectedCompanyName.Location = new System.Drawing.Point(103, 93);
            this.txtSelectedCompanyName.Name = "txtSelectedCompanyName";
            this.txtSelectedCompanyName.ReadOnly = true;
            this.txtSelectedCompanyName.Size = new System.Drawing.Size(156, 20);
            this.txtSelectedCompanyName.TabIndex = 4;
            // 
            // cmbSearchResult
            // 
            this.cmbSearchResult.FormattingEnabled = true;
            this.cmbSearchResult.Location = new System.Drawing.Point(12, 59);
            this.cmbSearchResult.Name = "cmbSearchResult";
            this.cmbSearchResult.Size = new System.Drawing.Size(247, 21);
            this.cmbSearchResult.TabIndex = 3;
            this.cmbSearchResult.SelectedIndexChanged += new System.EventHandler(this.cmbSearchResult_SelectedIndexChanged);
            // 
            // btnSearchCompany
            // 
            this.btnSearchCompany.Location = new System.Drawing.Point(204, 23);
            this.btnSearchCompany.Name = "btnSearchCompany";
            this.btnSearchCompany.Size = new System.Drawing.Size(55, 23);
            this.btnSearchCompany.TabIndex = 2;
            this.btnSearchCompany.Text = "Search";
            this.btnSearchCompany.UseVisualStyleBackColor = true;
            this.btnSearchCompany.Click += new System.EventHandler(this.btnSearchCompany_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name";
            // 
            // txtSearchCompany
            // 
            this.txtSearchCompany.Location = new System.Drawing.Point(48, 25);
            this.txtSearchCompany.Name = "txtSearchCompany";
            this.txtSearchCompany.Size = new System.Drawing.Size(150, 20);
            this.txtSearchCompany.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(586, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(702, 20);
            this.textBox1.TabIndex = 42;
            // 
            // checkBoxRule3
            // 
            this.checkBoxRule3.AutoSize = true;
            this.checkBoxRule3.Location = new System.Drawing.Point(374, 11);
            this.checkBoxRule3.Name = "checkBoxRule3";
            this.checkBoxRule3.Size = new System.Drawing.Size(119, 17);
            this.checkBoxRule3.TabIndex = 43;
            this.checkBoxRule3.Text = "Calculation rule of 3";
            this.checkBoxRule3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSearchCompany;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 749);
            this.Controls.Add(this.checkBoxRule3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupCompany);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxRatioPut);
            this.Controls.Add(this.textBoxRatioCall);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTimer2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnAllStart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupCommodity);
            this.Controls.Add(this.webControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1318, 724);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pair Downloader _ 2022-06-18";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupCommodity.ResumeLayout(false);
            this.groupCommodity.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupCompany.ResumeLayout(false);
            this.groupCompany.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupCommodity;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPwdConfirm;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtCurCommodity;
        private System.Windows.Forms.TreeView treeCommodity;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataviewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem emailNotificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem premiunToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbDownloadTime;
        private System.Windows.Forms.CheckBox chkDownloadTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDeletePairDetails;
        private System.Windows.Forms.Button btnAllStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLastDownTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLastDeleteTime;
        private System.Windows.Forms.CheckBox chkNotifyEmail;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentStatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TextBox txtNotifyEmail;
        private System.Windows.Forms.ToolStripMenuItem pairDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pairStatisticsToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPremiumUnit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVariationCond;
        private System.Windows.Forms.TextBox textboxVariationPut;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBoxTimer2;
        private System.Windows.Forms.TextBox textBoxIntervalDownload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxRatioCall;
        private System.Windows.Forms.TextBox textBoxRatioPut;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxFromIndex;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxIndexEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmailBody;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1btc;
        public EO.WebBrowser.WebView webView1;
        public EO.WinForm.WebControl webControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchCompany;
        private System.Windows.Forms.Button btnSearchCompany;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbSearchResult;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtSelectedCompanyName;
        private System.Windows.Forms.TextBox txtSelectedCompanyId;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnRemoveCompany;
        private System.Windows.Forms.Button btnAddCompany;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ComboBox cmbStaked;
        private System.Windows.Forms.ComboBox cmbCommodity;
        private System.Windows.Forms.CheckBox checkBoxRule3;
    }
}

