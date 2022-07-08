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
    public partial class Pair_statistics : Form
    {
        public bool isCommodity = true;
        public Pair_statistics(bool flag)
        {
            isCommodity = flag;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SQLiteConnection myconnection = new SQLiteConnection("Data Source=db.sqlite; Version = 3; New = True; Compress = True;");
            myconnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = myconnection;

            if (isCommodity)
                cmd.CommandText = "Select *FROM pair_statistics";
            else
                cmd.CommandText = "Select *FROM pair_statistics_company";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
