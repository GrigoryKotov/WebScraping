using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PairDownloader
{
    
    public partial class Premiun : Form
    {
        public decimal FilterRatioPUT;
        public decimal FilterVariationPUT;
        public decimal FilterRatioCall;
        public decimal FilterVariationCall;
        public string Startdate;
        public string EndDate;
        public Graphics chartElevation;
        public Form1 parentForm;
        public bool isCommodity = true;
        public string tablename = "premium_callput";
        public Premiun(Form1 parent, bool flag)
        {
            isCommodity = flag;
            if (flag == false)
                tablename = "premium_callput_company";
            parentForm = parent;
            InitializeComponent();
        }

        private void Premiun_Load(object sender, EventArgs e)
        {
            label1.Text = "Database " + tablename + " Table";

            //chartElevation = panel1.CreateGraphics();
            //chartElevation.Clear(Color.White);

            string[] pairs = getCommodityPairs();
            foreach (var pairKey in pairs)
            {
                cmbCommodity.Items.Add(pairKey);
                cmbCommodity.SelectedIndex = 0;
            }            

            for (int i = 1; i <= 50; i++)
            {
                cmbFrequency.Items.Add(i.ToString());
                cmbFrequency.SelectedIndex = 0;
            }            

            Dataview();
            DrawGraphicChart();
        }

        private string[] getCommodityPairs()
        {
            List<string> pairs = new List<string>();
            try
            {
                SQLiteConnection myconnection = new SQLiteConnection("Data Source=db.sqlite; Version = 3; New = True; Compress = True;");
                myconnection.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = myconnection;
                cmd.CommandText = "SELECT pair FROM " + tablename + " GROUP BY pair";
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string pair = rdr.GetString(0);
                    pairs.Add(pair);
                }
                rdr.Close();
                myconnection.Close();
            }
            catch (Exception)
            {
            }
            return pairs.ToArray();
        }

        private void Dataview()
        {
            string commodity = cmbCommodity.SelectedItem.ToString(); // show the data according combolist
            int frequency = cmbFrequency.SelectedIndex + 1;
            SQLiteConnection myconnection = new SQLiteConnection("Data Source=db.sqlite; Version = 3; New = True; Compress = True;");
            myconnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = myconnection;
            cmd.CommandText = "select *, premium_call- premium_put as variation ,  CAST((premium_put/premium_call)   AS FLOAT) AS RATIO From " + tablename + "  WHERE pair=\"" + commodity + "\" AND frequency=" + frequency.ToString();
            using (SQLiteDataReader sdr = cmd.ExecuteReader())
            {
                //Create a new DataTable.
                DataTable dt = new DataTable();
                //Load DataReader into the DataTable.
                dt.Load(sdr);
                sdr.Close();
                myconnection.Close();
                dataGridView1.DataSource = dt;
            }
        }

        private void dataviewRequestCall ()
        {

            FilterRatioCall = Decimal.Parse(textBoxFiltreSQLRCALL.Text);
            FilterVariationCall = decimal.Parse(textBoxFiltreSQL1VCALL.Text);

            string commodity = cmbCommodity.SelectedItem.ToString(); // show the data according combolist
            int frequency = cmbFrequency.SelectedIndex + 1;
            SQLiteConnection myconnection = new SQLiteConnection("Data Source=db.sqlite; Version = 3; New = True; Compress = True;");
            myconnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = myconnection;
            cmd.CommandText = "select *, premium_call- premium_put as Variation ,  CAST((premium_put/premium_call)   AS FLOAT) AS RATIO From " + tablename + "  WHERE pair=\"" + commodity + "\" AND frequency=\"" + frequency.ToString() + "\" AND Ratio <=\"" + FilterRatioCall.ToString() + "\" AND Variation >=" + FilterVariationCall.ToString(); 
            using (SQLiteDataReader sdr = cmd.ExecuteReader())
            {
                //Create a new DataTable.
                DataTable dt = new DataTable();
                //Load DataReader into the DataTable.
                dt.Load(sdr);
                sdr.Close();
                myconnection.Close();
                dataGridView1.DataSource = dt;

            }
        }
        private void dataviewFilterByDaysAvg()
        {

            Startdate = (textBoxDateStart.Text);
            EndDate = (textBoxEndDate.Text);

            string commodity = cmbCommodity.SelectedItem.ToString(); // show the data according combolist
            int frequency = cmbFrequency.SelectedIndex + 1;
            SQLiteConnection myconnection = new SQLiteConnection("Data Source=db.sqlite; Version = 3; New = True; Compress = True;");
            myconnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = myconnection;
            cmd.CommandText = "SELECT pair, datetime, frequency, avg(premium_put/premium_call) as Ratio, avg(premium_call-premium_put) as Variation from " + tablename + " where pair=\"" + commodity + "\" AND DateTime Between \"" + Startdate.ToString() + "\" AND \"" + EndDate.ToString() + "\" Group  by  strftime('%d',datetime) having  frequency=" + frequency.ToString();
            using (SQLiteDataReader sdr = cmd.ExecuteReader())
            {
                //Create a new DataTable.
                DataTable dt = new DataTable();
                //Load DataReader into the DataTable.
                dt.Load(sdr);
                sdr.Close();
                myconnection.Close();
                dataGridView1.DataSource = dt;

            }
        }
        private void dataviewFilterDate()
        {

            Startdate = (textBoxDateStart.Text);
            EndDate = (textBoxEndDate.Text);

            string commodity = cmbCommodity.SelectedItem.ToString(); // show the data according combolist
            int frequency = cmbFrequency.SelectedIndex + 1;
            SQLiteConnection myconnection = new SQLiteConnection("Data Source=db.sqlite; Version = 3; New = True; Compress = True;");
            myconnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = myconnection;
            cmd.CommandText = "SELECT *,(premium_put/premium_call) as Ratio, (premium_put/premium_call) as Variation  FROM " + tablename + "  WHERE pair=\"" + commodity + "\" AND DateTime Between \""+ Startdate.ToString() + "\" AND \"" + EndDate.ToString() + "\" AND frequency=" + frequency.ToString();
            using (SQLiteDataReader sdr = cmd.ExecuteReader())
            {
                //Create a new DataTable.
                DataTable dt = new DataTable();
                //Load DataReader into the DataTable.
                dt.Load(sdr);
                sdr.Close();
                myconnection.Close();
                dataGridView1.DataSource = dt;

            }
        }
        private void graphdatafilther()
        {
            string commodity2 = cmbCommodity.SelectedItem.ToString();
            int frequency2 = cmbFrequency.SelectedIndex + 1;

            SQLiteConnection myconnection1 = new SQLiteConnection("Data Source=db.sqlite; Version = 3; New = True; Compress = True;");
            myconnection1.Open();
            SQLiteCommand cmd1 = new SQLiteCommand();
            cmd1.Connection = myconnection1;
            cmd1.CommandText = "SELECT *, (premium_put/premium_call) as Ratio, (premium_put/premium_call) as variation FROM " + tablename + "  WHERE pair=\"" + commodity2 + "\" AND DateTime Between \"" + Startdate.ToString() + "\" AND \"" + EndDate.ToString() + "\" AND frequency=" + frequency2.ToString();
            using (SQLiteDataReader sdr = cmd1.ExecuteReader())


            {
                //Create a new DataTable.
                DataTable dt = new DataTable();
                //Load DataReader into the DataTable.

                dt.Load(sdr);
                sdr.Close();
                myconnection1.Close();

                chart1.DataSource = dt;
                chart1.Series["Premium Call"].XValueMember = "datetime";
                chart1.Series["Premium Call"].YValueMembers = "Ratio";
                chart1.Series["Premium Put"].XValueMember = "datetime";
                chart1.Series["Premium Put"].YValueMembers = "Ratio";
                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chart1.Series["Premium Call"].IsValueShownAsLabel = false;
                chart1.Series["Premium Put"].IsValueShownAsLabel = false;
                chart1.DataBind();
            }

        }
        private void dataviewRequestPut()
        {

            FilterRatioPUT = Decimal.Parse(textBoxFiltreSQLRPUT.Text);
            FilterVariationPUT = decimal.Parse(textBoxFiltreSQL1VPUT.Text);

            string commodity = cmbCommodity.SelectedItem.ToString(); // show the data according combolist
            int frequency = cmbFrequency.SelectedIndex + 1;
            SQLiteConnection myconnection = new SQLiteConnection("Data Source=db.sqlite; Version = 3; New = True; Compress = True;");
            myconnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = myconnection;
            cmd.CommandText = "select *, premium_call- premium_put as Variation ,  CAST((premium_put/premium_call)   AS FLOAT) AS RATIO From " + tablename + "  WHERE pair=\"" + commodity + "\" AND frequency=\"" + frequency.ToString() + "\" AND Ratio >=\"" + FilterRatioPUT.ToString() + "\" AND Variation <=" + FilterVariationPUT.ToString();
            using (SQLiteDataReader sdr = cmd.ExecuteReader())
            {
                //Create a new DataTable.
                DataTable dt = new DataTable();
                //Load DataReader into the DataTable.
                dt.Load(sdr);
                sdr.Close();
                myconnection.Close();
                dataGridView1.DataSource = dt;

            }
        }
        private void DrawGraphicChart()
        {
            if (checkBoxRatio.Checked == true)
            {
                string commodity1 = cmbCommodity.SelectedItem.ToString();
                int frequency1 = cmbFrequency.SelectedIndex + 1;

                SQLiteConnection myconnection1 = new SQLiteConnection("Data Source=db.sqlite; Version = 3; New = True; Compress = True;");
                myconnection1.Open();
                SQLiteCommand cmd1 = new SQLiteCommand();
                cmd1.Connection = myconnection1;
                cmd1.CommandText = "Select datetime,current_price , (premium_put/premium_call) AS 'Ratio' FROM " + tablename + " WHERE pair=\"" + commodity1 + "\" AND frequency=" + frequency1.ToString();
                using (SQLiteDataReader sdr = cmd1.ExecuteReader())
                {
                    //Create a new DataTable.
                    DataTable dt = new DataTable();
                    //Load DataReader into the DataTable.

                    dt.Load(sdr);
                    sdr.Close();
                    myconnection1.Close();

                    chart1.DataSource = dt;
                    chart1.Series["Premium Call"].XValueMember = "datetime";
                    chart1.Series["Premium Call"].YValueMembers = "Ratio";
                    chart1.Series["Premium Put"].XValueMember = "datetime";
                    chart1.Series["Premium Put"].YValueMembers = "Ratio";
                    chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                    chart1.Series["Premium Call"].IsValueShownAsLabel = false;
                    chart1.Series["Premium Put"].IsValueShownAsLabel = false;
                    chart1.DataBind();
                }
            }
            else if (checkBoxVariation.Checked == true && checkBoxRatio.Checked == false)
            {
                string commodity = cmbCommodity.SelectedItem.ToString();
                int frequency = cmbFrequency.SelectedIndex + 1;

                SQLiteConnection myconnection = new SQLiteConnection("Data Source=db.sqlite; Version = 3; New = True; Compress = True;");
                myconnection.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = myconnection;
                cmd.CommandText = "Select datetime,current_price, premium_call,  (premium_call -premium_put) AS 'Variation' FROM " + tablename + " WHERE pair=\"" + commodity + "\" AND frequency=" + frequency.ToString();
                using (SQLiteDataReader sdr = cmd.ExecuteReader())


                {
                    //Create a new DataTable.
                    DataTable dt = new DataTable();
                    //Load DataReader into the DataTable.

                    dt.Load(sdr);
                    sdr.Close();
                    myconnection.Close();

                    chart1.DataSource = dt;
                    chart1.Series["Premium Call"].XValueMember = "current_price";
                    chart1.Series["Premium Call"].YValueMembers = "Variation";
                    chart1.Series["Premium Put"].XValueMember = "current_price";
                    chart1.Series["Premium Put"].YValueMembers = "Variation";
                    chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
                    chart1.Series["Premium Call"].IsValueShownAsLabel = false;
                    chart1.Series["Premium Put"].IsValueShownAsLabel = false;
                    chart1.DataBind();
                }

            } else if (checkBoxRatio.Checked == false && checkBoxVariation.Checked == false)
            {


                string commodity = cmbCommodity.SelectedItem.ToString();
                int frequency = cmbFrequency.SelectedIndex + 1;

                SQLiteConnection myconnection = new SQLiteConnection("Data Source=db.sqlite; Version = 3; New = True; Compress = True;");
                myconnection.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = myconnection;
                cmd.CommandText = "Select current_price, premium_call, premium_put FROM " + tablename + " WHERE pair=\"" + commodity + "\" AND frequency=" + frequency.ToString();
                using (SQLiteDataReader sdr = cmd.ExecuteReader())


                {
                    //Create a new DataTable.
                    DataTable dt = new DataTable();
                    //Load DataReader into the DataTable.

                    dt.Load(sdr);
                    sdr.Close();
                    myconnection.Close();

                    chart1.DataSource = dt;
                    chart1.Series["Premium Call"].XValueMember = "current_price";
                    chart1.Series["Premium Call"].YValueMembers = "premium_call";
                    chart1.Series["Premium Put"].XValueMember = "current_price";
                    chart1.Series["Premium Put"].YValueMembers = "premium_put";
                    chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                    chart1.Series["Premium Call"].IsValueShownAsLabel = false;
                    chart1.Series["Premium Put"].IsValueShownAsLabel = false;
                    chart1.DataBind();
                }

            }

        

        }

        private void cmbCommodity_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DrawGraphicChart();
            Dataview();
        }

        private void cmbFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawGraphicChart();
            Dataview();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void buttonRatio_Click(object sender, EventArgs e)
        {
            DrawGraphicChart();

        }

        private void buttonSQL_Click(object sender, EventArgs e)
        {
            dataviewRequestCall();
        }

        private void buttonSQLP_Click(object sender, EventArgs e)
        {
            dataviewRequestPut();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBoxEndDate.Text == textBoxDateStart.Text)
            {

                MessageBox.Show("Please verify your different date", "Alert");
            }

            dataviewFilterDate();
            graphdatafilther();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void lab_X_Aix_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataviewFilterByDaysAvg();
        }
    }
}
