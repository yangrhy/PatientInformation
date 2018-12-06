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
        public string birthDate { get; set; }
        public int birthMonth { get; set; }
        public int birthDay { get; set; }
        public int birthYear { get; set; }
        public int age { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public double BMI { get; set; }
        public int ID { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public string phoneNumber { get; set; }
        public int maxHeartRate { get; set; }
        public string targetHeartRate { get; set; }

        public void setAge(int year, int month, int day)
        {
            DateTime birthday = new DateTime(year, month, day);

            this.age = (int)Math.Floor((DateTime.Now.Subtract(birthday)).TotalDays/365.25);
        }

        public void setBMI (double weight, double height)
        {
            this.BMI = (weight * 703) / (height * height); 
        }

        // get BMI string to place into chart
        public string getBMI(double bmi)
        {
            string bmiValue = string.Empty;

            if (bmi < 18.5)
            {
                bmiValue = bmi + ": Underweight";
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                bmiValue = this.BMI + ": Normal";
            }
            else if (bmi >= 25 && bmi < 30)
            {
                bmiValue = bmi + ": Overweight";
            }
            else if (bmi > 30)
            {
                bmiValue = bmi + ": Obese";
            }

            return bmiValue;
        }

        public void setMaxHeartRate(int age)
        {
            this.maxHeartRate = (220 - age);
        }

        public void setTargetHeartRange(int maxHR)
        {
            this.targetHeartRate = $"{maxHR * 0.5} - {maxHR * 0.8}";
        }
    }
}
