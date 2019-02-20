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

namespace HealthRecords
{
    public partial class PatientTable : Form
    {

        public PatientTable()
        {
            InitializeComponent();
        }

        private void UpdateTable()
        {
            //connection string must be updated to correct file location to work
            String strConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Huechi\\source\\repos\\PatientInformation\\HealthRecords\\PatientsInfo.mdf;Integrated Security=True;Connect Timeout=30";

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
            UpdateTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var row = dataGridView1.CurrentCell.RowIndex;
                var col = dataGridView1.CurrentCell.ColumnIndex;

                var id = dataGridView1.Rows[row].Cells[0].Value;

                var value = textBox1.Text;

                var columnName = dataGridView1.CurrentCell.OwningColumn.HeaderText;

                //connection string must be updated to correct file location to work
                SqlConnection con = new SqlConnection
                       ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Huechi\\source\\repos\\PatientInformation\\HealthRecords\\PatientsInfo.mdf;Integrated Security=True;Connect Timeout=30");
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Table] SET [" + columnName + "]=" + "'" + value + "'" + "WHERE [Patient ID]=" + id, con);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("You've entered an invalid input");
                }
                con.Close();
                UpdateTable();
            }
            catch
            {
                MessageBox.Show("Nothing to edit!");
            }
            textBox1.ResetText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var row = dataGridView1.CurrentCell.RowIndex;
                var id = dataGridView1.Rows[row].Cells[0].Value;

                //connection string must be updated to correct file location to work
                SqlConnection con = new SqlConnection
                       ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Huechi\\source\\repos\\PatientInformation\\HealthRecords\\PatientsInfo.mdf;Integrated Security=True;Connect Timeout=30");
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Table] WHERE [Patient ID]=" + id, con);
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
                UpdateTable();
            }
            catch
            {
                MessageBox.Show("Nothing to delete!");

            }
        }
    }
}
