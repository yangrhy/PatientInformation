using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW5HealthRecords
{
    public partial class PatientTable : Form
    {
        public PatientTable()
        {
            InitializeComponent();
        }

        private void PatientTable_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'patientsInfoDataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.patientsInfoDataSet.Table);

        }
    }
}
