using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Duc Tran
 * CIS 3309 - 9.2: Working With Strings
 * Professor Frank Friedman
 * Last Updated: February 11, 2019
 */ 

namespace StringHandling
{
    public partial class Form1 : Form
    {

        /*
         * Variable used to aid in the determination of the phone number being valid or not
         */

        Boolean isValid = true;

        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Checks if text box is empty, otherwise trims the entered name and splits it into parts with split and counts spaces based on the length of the splitted sections.
         * 
         * The form then uses spaces to check if the format of the name is valid.
         *  -If space > 3, the user will be notified to enter a valid name due to the incorrect format of the input.
         *  -If space == 1, the first name will be set to the first split section, its first letter will be capitalized using UppercaseFirst() method and then displayed in a message box.
         *  -If space == 2, the first and last name will be set to the first to split sections respectively, both of their first letters will be capitalized using UppercaseFirst() method
         *   and then displayed in a message box.
         *  -If space == 3, the first, middle, and last name will be set to the first, second and last split sections respectively, first letters will be capitalized using UppercaseFirst() method
         *   and then displayed in a message box.
         *   
         *   After any of these conditions, the focus will be switched to txtFullName text box in case the user would like to parse a new name.
         * 
         */

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
                //Console.WriteLine("Spaces in Name: " + spaces);
                
                if(spaces > 3)
                {
                    MessageBox.Show("Please enter a valid name in the appropriate format \n(First, Middle, Last) / (First, Last) \n\nAttention, please do not put extra spaces between First, Middle and Last names.", 
                        "Incorrect name format found!");
                    txtFullName.Focus();
                }
                else if(spaces == 1)
                {
                    string firstName = nameParts[0];
                    firstName = UppercaseFirst(firstName);
                    //Console.WriteLine("If statement/First name: " + firstName);
                    MessageBox.Show("First Name: " + firstName + "\n", "Entered Name");
                    txtFullName.Focus();
                }
                else if(spaces == 2)
                {
                    string firstName = nameParts[0];
                    string lastName = nameParts[1];
                    firstName = UppercaseFirst(firstName);
                    lastName = UppercaseFirst(lastName);
                    //Console.WriteLine("If statement/First name: " + firstName);
                    MessageBox.Show("First Name: " + firstName + "\n" +
                        "Last Name: " + lastName, "Entered Name");
                    txtFullName.Focus();
                }
                else if(spaces == 3)
                {
                    string firstName = nameParts[0];
                    string middleName = nameParts[1];
                    string lastName = nameParts[2];
                    firstName = UppercaseFirst(firstName);
                    middleName = UppercaseFirst(middleName);
                    lastName = UppercaseFirst(lastName);
                    //Console.WriteLine("If statement/First name: " + firstName);
                    MessageBox.Show("First Name: " + firstName + "\n" +
                        "Middle Name: " + middleName + "\n" +
                        "Last Name: " + lastName, "Entered Name");
                    txtFullName.Focus();

                }
            }
        }

        /*
         * Checks if the phone number is empty
         *  -If empty, a message box will notify the user to enter a 10-digit phone number and the corresponding text box will be focused for user input.
         *  -Otherwise, StringBuilder is used to create the "Only Digits" phone number using several if statements with conditions based on the format of the phone number inputted.
         *  
         * StringBuilder follows a series of if statements with conditions depending on the format of the phone number inputted. 
         * Once finished, the StringBuilder is converted to String and evaluated by its length to determine if it's a valid number.
         *  -Uses class variable called 'isValid' and if statements to confirm if SB of phone number is valid or not.
         *  -If not valid, a message box will notify the user if the phone number is too long or short to be a valid number.
         *  -Otherwise, the form progresses through another series of if statements and SBs depending on the format of the inputted phone number.
         *  
         * At the end of the if statements and creation of the standard phone number, the inputted number, digits-only and standard number are displayed onto a message box
         * for the user to see the three different setups of their phone number.
         */

        private void btnEditPhoneNumber_Click(object sender, System.EventArgs e)
        {
            // TODO: Add code to edit the phone number
            bool isEmpty = string.IsNullOrEmpty(txtPhoneNumber.Text);

            if (isEmpty)
            {
                MessageBox.Show("Please enter the 10-digits for your phone number",
                    "No phone number found!");
                txtPhoneNumber.Focus();
            }
            else if (!isEmpty)
            {
                StringBuilder phoneNumber = new StringBuilder();
                isValid = true;

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
                /*
                if((phoneNumberSubStringCheck(txtPhoneNumber.Text, "000-000-0000")) || (phoneNumberSubStringCheck(txtPhoneNumber.Text, "(000) 000-0000")))
                {
                    MessageBox.Show("The phone number you entered is not in the correct format.", "Incorrect Format Error");
                    txtPhoneNumber.Focus();
                }
                */
                if(resultPhoneNumber.Length > 10)
                {
                    MessageBox.Show("The number you have entered is too long to be a phone number!", "Invalid Number Detected");
                    isValid = false;
                    txtPhoneNumber.Focus();
                }
                else if(resultPhoneNumber.Length < 10)
                {
                    MessageBox.Show("The number you have entered is too short to be a phone number!", "Invalid Number Detected");
                    isValid = false;
                    txtPhoneNumber.Focus();
                }
            }
            if (isValid)
            {
                if ((txtPhoneNumber.Text.Contains('(')) && (txtPhoneNumber.Text.Contains(')')))
                {
                    //Console.WriteLine("Phone Number length: " + txtPhoneNumber.Text.Length);
                    StringBuilder phoneNumber = new StringBuilder();
                    StringBuilder stdPhoneNumber = new StringBuilder();

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
                    phoneNumber = phoneNumber.Insert(3, '-');
                    phoneNumber = phoneNumber.Insert(7, '-');
                    string stdPhoneNumberResult = phoneNumber.ToString();
                    Console.WriteLine(stdPhoneNumberResult);
                    //Console.WriteLine("Phone Number Entered: " + resultPhoneNumber);
                    MessageBox.Show("Entered: " + txtPhoneNumber.Text + "\n" +
                        "Digits only: " + resultPhoneNumber + "\n" +
                        "Standard format: " + stdPhoneNumberResult);
                    txtPhoneNumber.Focus();
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
                    phoneNumber = phoneNumber.Insert(3, '-');
                    phoneNumber = phoneNumber.Insert(7, '-');
                    string stdPhoneNumberResult = phoneNumber.ToString();
                    Console.WriteLine(stdPhoneNumberResult);
                    MessageBox.Show("Entered: " + txtPhoneNumber.Text + "\n" +
                        "Digits only: " + resultPhoneNumber + "\n" +
                        "Standard format: " + stdPhoneNumberResult);
                    txtPhoneNumber.Focus();
                }
            }
        }

        /*
         * Exits the application upon clicking
         */

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /*
         * Capitalizes the initial letter of the string and returns back the string with the beginning letter as capitalized.
         *  -Used for the input of names
         */

        private static string UppercaseFirst(string s)
        {
            Console.WriteLine(s);
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        /*
        private static bool phoneNumberSubStringCheck(string input, string pattern)
        {
            Console.WriteLine("phoneNumberSubStringCheck initiated...");
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
                Console.WriteLine(ithCharOk);
            }
            return false;
        }
        */
    }
}