using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HW5HealthRecords
{
    public partial class PatientTable : Form
    {

        public PatientTable()
        {
            InitializeComponent();
        }

        private void UpdateTable()
        {
            String strConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Huechi\\source\\repos\\HW5HealthRecords\\HW5HealthRecords\\PatientsInfo.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from [dbo].[Table]";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        private void PatientTable_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientNewEntry newEntry = new PatientNewEntry();
            newEntry.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String strConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Huechi\\source\\repos\\HW5HealthRecords\\HW5HealthRecords\\PatientsInfo.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from [dbo].[Table]";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
            
            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }
    }
}
