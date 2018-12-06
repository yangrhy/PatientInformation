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
using System.Data.SqlClient;

namespace HW5HealthRecords
{
    public partial class PatientNewEntry : Form
    {

        List<Patient> patientList = new List<Patient>();

        public PatientNewEntry()
        {
            InitializeComponent();
        }

        private void PatientNewEntry_Load(object sender, EventArgs e)
        {
            GetListOfStates();
            statesComboBox.SelectedIndex = 0;
        }

        private void ResetForm()
        {
            PatientNewEntry newPatientEntry = new PatientNewEntry();
            newPatientEntry.Show();
            this.Dispose(false);
        }

        // create new patient with information from textboxes
        private void CreateNewPatient()
        {
            Patient newPatient = new Patient();
            newPatient.ID = 1 + patientList.Count();
            newPatient.fName = firstNameTextBox.Text;
            newPatient.lName = lastNameTextBox.Text;
            newPatient.address = addressTextBox.Text;
            newPatient.city = cityTextBox.Text;
            newPatient.state = statesComboBox.SelectedText;
            newPatient.zip = int.Parse(zipCodeTextBox.Text);
            newPatient.phoneNumber = phoneNumMaskedTextBox.Text;
            newPatient.height = double.Parse(heightMaskedTextBox.Text);
            newPatient.weight = double.Parse(weightMaskedTextBox.Text);
            newPatient.setBMI(newPatient.height, newPatient.weight);

            string[] birthDate = dateTimePicker1.Text.Split('/');

            newPatient.birthMonth = int.Parse(birthDate[0]);
            newPatient.birthDay = int.Parse(birthDate[1]);
            newPatient.birthYear = int.Parse(birthDate[2]);
         
            // set age for new patient
            newPatient.setAge(newPatient.birthYear, newPatient.birthMonth, newPatient.birthDay);

            newPatient.setMaxHeartRate(newPatient.age);
            newPatient.setTargetHeartRange(newPatient.maxHeartRate);

            // append to list of patients
            patientList.Add(newPatient);
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

            try
            {
                CreateNewPatient();
            }
            catch
            {
                MessageBox.Show("An error occured, check to see if form was completed.");
            }

            // indicate success of added patient info
            MessageBox.Show("Patient Information Added.");

            ResetForm();
        }
    }
}
