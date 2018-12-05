using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5HealthRecords
{
    class Patient
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string gender { get; set; }
        public int birthMonth { get; set; }
        public int birthDay { get; set; }
        public int birthYear { get; set; }
        public int age { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public double BMI { get; set; }
        public string ID { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phoneNumber { get; set; }
        public double maxHeartRate { get; set; }
        public string targetHeartRate { get; set; }

        public void setBirthDate(int year, int month, int day)
        {
            DateTime birthday = new DateTime(year, month, day);

            this.age = (int)Math.Floor((DateTime.Now - birthday).TotalDays/365.25);
        }

        public void setBMI (double weight, double height)
        {
            this.BMI = (weight * 703) / (height * height); 
        }

        public string getBMI()
        {
            string bmiValue = string.Empty;

            if (this.BMI < 18.5)
            {
                bmiValue = this.BMI + ": Underweight";
            }
            else if (this.BMI >= 18.5 && this.BMI < 25)
            {
                bmiValue = this.BMI + ": Normal";
            }
            else if (this.BMI >= 25 && this.BMI < 30)
            {
                bmiValue = this.BMI + ": Overweight";
            }
            else if (this.BMI > 30)
            {
                bmiValue = this.BMI + ": Obese";
            }

            return bmiValue;
        }

        public void setMaxHeartRate()
        {
            this.maxHeartRate = (220 - this.age);
        }

        public void setTargetHeartRange()
        {
            this.targetHeartRate = $"{this.maxHeartRate * 0.5} - {this.maxHeartRate * 0.8}";
        }
    }
}
