using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringHandling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnParseName_Click(object sender, System.EventArgs e)
        {
            // TODO: Add code to parse name
            bool isEmpty = string.IsNullOrEmpty(txtFullName.Text);

            if (isEmpty)
            {
                MessageBox.Show("Please enter a valid name (First, Middle, Last)/(First, Last), Incorrect name format found!");
            }

            else
            {
                string fullName = txtFullName.Text;
                fullName = fullName.Trim();
                var nameParts = fullName.Split();
                int spaces = nameParts.Length;
                Console.WriteLine("Spaces in Name: " + spaces);
                
                if(spaces > 3)
                {
                    MessageBox.Show("Please enter a valid name in the appropriate format (First, Middle, Last)/(First, Last), Incorrect name format found!");
                }
                else if(spaces == 1)
                {
                    string firstName = nameParts[0];
                    firstName = UppercaseFirst(firstName);
                    Console.WriteLine("If statement/First name: " + firstName);
                    MessageBox.Show("First Name: " + firstName + "\n", "Entered Name");
                }
                else if(spaces == 2)
                {
                    string firstName = nameParts[0];
                    string lastName = nameParts[1];
                    firstName = UppercaseFirst(firstName);
                    lastName = UppercaseFirst(lastName);
                    Console.WriteLine("If statement/First name: " + firstName);
                    MessageBox.Show("First Name: " + firstName + "\n" +
                        "Last Name: " + lastName, "Entered Name");
                }
                else if(spaces == 3)
                {
                    string firstName = nameParts[0];
                    string middleName = nameParts[1];
                    string lastName = nameParts[2];
                    firstName = UppercaseFirst(firstName);
                    middleName = UppercaseFirst(middleName);
                    lastName = UppercaseFirst(lastName);
                    Console.WriteLine("If statement/First name: " + firstName);
                    MessageBox.Show("First Name: " + firstName + "\n" +
                        "Middle Name: " + middleName + "\n" +
                        "Last Name: " + lastName, "Entered Name");

                }
            }
            
            /*string firstName = "";
            string middleName = " ";
            string lastName = " ";*/
            /*if(firstSpace == -1)
            {
                firstName = fullName;
                firstName = UppercaseFirst(firstName);
                Console.WriteLine("If statement/First name: " + firstName);
                MessageBox.Show("First Name: " + firstName + "\n" +
                    "Middle Name: " + middleName + "\n" +
                    "Last Name: " + lastName, "Entered Name");
            }
            else
            {
                firstName = fullName.Substring(0, firstSpace);
                firstName = UppercaseFirst(firstName);
                Console.WriteLine("Else statement/First name: " + firstName);
                Console.WriteLine("First name: " + firstName);
                MessageBox.Show("First Name: " + firstName + "\n" +
                    "Middle Name: " + middleName + "\n" +
                    "Last Name: " + lastName, "Entered Name");
            }*/
        }

        private void btnEditPhoneNumber_Click(object sender, System.EventArgs e)
        {
            // TODO: Add code to edit the phone number
        }

        // TODO: Add ToInitialCap method here

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private static string UppercaseFirst(string s)
        {
            Console.WriteLine(s);
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

    }
}