using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace HW5HealthRecords
{
    public partial class PatientNewEntry : Form
    {
        public PatientNewEntry()
        {
            InitializeComponent();
        }

        private void PatientNewEntry_Load(object sender, EventArgs e)
        {
            GetListOfStates();
        }

        // add states from text file into combobox of states
        private void GetListOfStates()
        {
            // add states from text file into combobox of states
            var fileName = Properties.Resources.States;

            string[] words = fileName.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in words)
            {
                statesComboBox.Items.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PatientTable patientTable = new PatientTable();
            patientTable.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Patient newPatient = new Patient();
        }
    }
}
