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
                MessageBox.Show("Please enter a valid name \n(First, Middle, Last) / (First, Last)", 
                    "Incorrect name format found!");
                txtFullName.Focus();
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
                    MessageBox.Show("Please enter a valid name in the appropriate format \n(First, Middle, Last) / (First, Last)", 
                        "Incorrect name format found!");
                    txtFullName.Focus();
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
        }

        private void btnEditPhoneNumber_Click(object sender, System.EventArgs e)
        {
            // TODO: Add code to edit the phone number
            bool isEmpty = string.IsNullOrEmpty(txtPhoneNumber.Text);

            if (isEmpty)
            {
                MessageBox.Show("Please enter the 10-digits for your phone number",
                    "Incorrect phone number format found!");
                txtPhoneNumber.Focus();
            }
            else if (!isEmpty)
            {
                StringBuilder phoneNumber = new StringBuilder();

                for (int i = 0; i < txtPhoneNumber.Text.Length; i++)
                {
                    if (txtPhoneNumber.Text[i] == '(' || txtPhoneNumber.Text[i] == ')' || txtPhoneNumber.Text[i] == '-')
                    {
                        i++;
                        if (txtPhoneNumber.Text[i] == ' ')
                        {
                            i++;
                        }
                        phoneNumber.Append(txtPhoneNumber.Text[i]);
                    }
                    else
                    {
                        phoneNumber.Append(txtPhoneNumber.Text[i]);
                    }
                }
                string resultPhoneNumber = phoneNumber.ToString();
                Console.WriteLine("Phone Number Entered: " + resultPhoneNumber);
                if((phoneNumberSubStringCheck(txtPhoneNumber.Text, "000-000-0000")) || (phoneNumberSubStringCheck(txtPhoneNumber.Text, "(000) 000-0000")))
                {
                    MessageBox.Show("The phone number you entered is not in the correct format.", "Incorrect Format Error");
                    txtPhoneNumber.Focus();
                }
                if(resultPhoneNumber.Length > 10)
                {
                    MessageBox.Show("The number you have entered is too long to be a phone number!", "Invalid Number Detected");
                    txtPhoneNumber.Focus();
                }
            }

            if((txtPhoneNumber.Text.Contains('(')) && (txtPhoneNumber.Text.Contains(')')))
            {
                //Console.WriteLine("Phone Number length: " + txtPhoneNumber.Text.Length);
                StringBuilder phoneNumber = new StringBuilder();

                for(int i = 0; i < txtPhoneNumber.Text.Length; i++)
                {
                    if(txtPhoneNumber.Text[i] == '(' || txtPhoneNumber.Text[i] == ')' || txtPhoneNumber.Text[i] == '-')
                    {
                        i++;
                        if(txtPhoneNumber.Text[i] == ' ')
                        {
                            i++;
                        }
                        phoneNumber.Append(txtPhoneNumber.Text[i]);
                    }
                    else
                    {
                        phoneNumber.Append(txtPhoneNumber.Text[i]);
                    }
                }
                string resultPhoneNumber = phoneNumber.ToString();
                Console.WriteLine("Phone Number Entered: " + resultPhoneNumber);
            }
            else if (txtPhoneNumber.Text.Contains('-'))
            {
                //Console.WriteLine("I contain a -");
                StringBuilder phoneNumber = new StringBuilder();

                for (int i = 0; i < txtPhoneNumber.Text.Length; i++)
                {
                    if (txtPhoneNumber.Text[i] == '(' || txtPhoneNumber.Text[i] == ')' || txtPhoneNumber.Text[i] == '-')
                    {
                        i++;
                        if (txtPhoneNumber.Text[i] == ' ')
                        {
                            i++;
                        }
                        phoneNumber.Append(txtPhoneNumber.Text[i]);
                    }
                    else
                    {
                        phoneNumber.Append(txtPhoneNumber.Text[i]);
                    }
                }
                string resultPhoneNumber = phoneNumber.ToString();
                Console.WriteLine("Phone Number Entered: " + resultPhoneNumber);
            }
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

        private static bool phoneNumberSubStringCheck(string input, string pattern)
        {
            if(input.Length != pattern.Length)
            {
                return false;
            }

            for(int i = 0; i < input.Length; i++)
            {
                bool ithCharOk;
                if(Char.IsDigit(pattern, i))
                {
                    ithCharOk = Char.IsDigit(input, i);
                }
                else
                {
                    ithCharOk = (input[i] == pattern[i]);
                }

                if (!ithCharOk)
                {
                    return false;
                }
            }
            return false;
        }

    }
}