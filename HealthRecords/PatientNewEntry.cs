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

namespace HealthRecords
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
            firstNameTextBox.ResetText();
            lastNameTextBox.ResetText();
            addressTextBox.ResetText();
            cityTextBox.ResetText();
            statesComboBox.ResetText();
            zipCodeTextBox.ResetText();
            phoneNumMaskedTextBox.ResetText();
            dateTimePicker1.ResetText();
            heightMaskedTextBox.ResetText();
            weightMaskedTextBox.ResetText();           

        }

        // add to patient to database
        private void AddPatientToDatabase(Patient p)
        {
            // must update connection string to correct file location to work correctly
            SqlConnection con = new SqlConnection
               ("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Huechi\\source\\repos\\PatientInformation\\HealthRecords\\PatientsInfo.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Table]" +

                "([Patient ID], [First Name], [Last Name], [Birth Date], [Age], [Address], [City], [State], [Zip Code], [Phone Number], [BMI], [Maximum Heart Rate], [Target Heart Rate Range])" +
                " VALUES(@ID, @fName, @lName, @bDate, @age, @address, @city, @state, @zip, @pNum, @bmi, @maxHR, @targetHR)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", p.ID);
            cmd.Parameters.AddWithValue("@fName", p.fName);
            cmd.Parameters.AddWithValue("@lName", p.lName);
            cmd.Parameters.AddWithValue("@bDate", p.birthDate);
            cmd.Parameters.AddWithValue("@age", p.age);
            cmd.Parameters.AddWithValue("@address", p.address);
            cmd.Parameters.AddWithValue("@city", p.city);
            cmd.Parameters.AddWithValue("@state", p.state);
            cmd.Parameters.AddWithValue("@zip", p.zip);
            cmd.Parameters.AddWithValue("@pNum", p.phoneNumber);
            cmd.Parameters.AddWithValue("@bmi", p.getBMI(p.BMI));
            cmd.Parameters.AddWithValue("@maxHR", p.maxHeartRate);
            cmd.Parameters.AddWithValue("@targetHR", p.targetHeartRate);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // create new patient with information from textboxes
        private void CreateNewPatient()
        {

            Random rand = new Random();
            int randomInt = 1 + rand.Next(1000, 10000);

            Patient newPatient = new Patient();
          
            newPatient.ID = randomInt;
            newPatient.fName = firstNameTextBox.Text;
            newPatient.lName = lastNameTextBox.Text;
            newPatient.address = addressTextBox.Text;
            newPatient.city = cityTextBox.Text;
            newPatient.state = statesComboBox.SelectedItem.ToString();
            newPatient.zip = int.Parse(zipCodeTextBox.Text);
            newPatient.phoneNumber = phoneNumMaskedTextBox.Text;
            newPatient.height = double.Parse(heightMaskedTextBox.Text);
            newPatient.weight = double.Parse(weightMaskedTextBox.Text);
            newPatient.setBMI(newPatient.weight, newPatient.height);

            // get date of birth
            newPatient.birthDate = dateTimePicker1.Text;
            string[] birthDate = dateTimePicker1.Text.Split('/');
            newPatient.birthMonth = int.Parse(birthDate[0]);
            newPatient.birthDay = int.Parse(birthDate[1]);
            newPatient.birthYear = int.Parse(birthDate[2]);
         
            // set age for new patient
            newPatient.setAge(newPatient.birthYear, newPatient.birthMonth, newPatient.birthDay);

            newPatient.setMaxHeartRate(newPatient.age);
            newPatient.setTargetHeartRange(newPatient.maxHeartRate);

            AddPatientToDatabase(newPatient);
        }

        // add states from text file into combobox of states
        private void GetListOfStates()
        {
            // add states from text file into combobox of states
            var fileName = HealthRecords.Properties.Resources.States;

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
            // creates new patient information and adds it to the database
            try
            {
                CreateNewPatient();
                // indicate success of added patient info
                MessageBox.Show("Patient Information Added.");
                // reset form only if successfully added to avoid having to refill information
                ResetForm();
            }
            catch
            {
                MessageBox.Show("An error occured, check to see if form was completed.");
            }       
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            PatientTable pt = new PatientTable();
            pt.ShowDialog();
        }
    }
}
