using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Previous input
        double previousInput = 0;
        //Current Input
        double userInput = 0;

        double result = 0;

        //Determines whether the value in the textbox can be erased
        bool changeValue = false;
        //Counter for determining arithmetic jobs
        int count = 1;
        string input = "";
        //Operations
        char x; 
        public MainWindow()
        {
            InitializeComponent();
            txtResult.Text = ""+0;
            lblInput.Content = "";
            //Gets current date and time
            lblDate.Content = DateTime.Now.ToString();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            //Conditional to check whether the value in the textbox is erased
            if (txtResult.Text.Equals("" + 0) || changeValue == true)
            {
                txtResult.Text = String.Empty;
                txtResult.FontSize = 30;
            }
            //Max of 16 numbers
            if (txtResult.Text.Length < 16)
            {
                txtResult.Text += 8;
                //Decreasing font size to fit all of the numbers in the textbox
                if (txtResult.Text.Length > 10 && txtResult.Text.Length <= 16)
                    txtResult.FontSize -= 1;
            }
            //Calculating the user's input based on value in textbox
                 userInput = Convert.ToDouble(txtResult.Text);
            //Setting changeValue to false to prevent value from being erased
            changeValue = false;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {

            if (txtResult.Text.Equals("" + 0) || changeValue == true)
            {
                txtResult.Text = String.Empty;
                txtResult.FontSize = 30;
            }
            if (txtResult.Text.Length < 16)
            {
                txtResult.Text += 7;

                if (txtResult.Text.Length > 10 && txtResult.Text.Length <= 16)
                    txtResult.FontSize -= 1;
            }

                userInput = Convert.ToDouble(txtResult.Text);
            changeValue = false;
        }

        private void buttonDecimal_Click(object sender, RoutedEventArgs e)
        {
            //Preventing user from constantly adding decimals
            if (txtResult.Text.Contains("."))
            {
                if(changeValue == true)
                {
                    txtResult.Text = "0.";
                    changeValue = false;
                }
            }
            else
            {
                if (changeValue == true)
                {
                    txtResult.Text = "0.";
                }
                else
                {
                    txtResult.Text = txtResult.Text + ".";
                }
                changeValue = false;
            }

        }

        private void plusMinus_Click(object sender, RoutedEventArgs e)
        {
            //Conditional to determine sign
            if (Convert.ToDouble(txtResult.Text) < 0)
            {
                    txtResult.Text = "" + Math.Abs(Convert.ToDouble(txtResult.Text));   
            }
            else
            {          
                    txtResult.Text = "" + -Math.Abs(Convert.ToDouble(txtResult.Text)); 
            }
            
            userInput = Convert.ToDouble(txtResult.Text);
            changeValue = false;
        }

        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
               //Conditional to set value for result and write it to the textbox
            if (count >= 2)
            {
                if (count == 2)
                {
                    switch (x)
                    {
                        case '+':
                            result = previousInput + userInput;
                           
                            break;
                        case '-':
                            result = previousInput - userInput;
                            break;
                        case '%':
                            //Conditional to prevent value of 0 for operand two
                            if (userInput == 0 || userInput < 0)
                            {
                                txtResult.Text = "Result is undefined";
                            }
                            else
                            {
                                result = previousInput % userInput;
                            }
                            break;
                        case '/':

                            if (userInput == 0 || userInput < 0)
                            {
                                txtResult.Text = "Cannot divide by zero";
                            }
                            else
                            {
                                result = previousInput / userInput;
                            }
                            break;
                        case '*':
                            result = previousInput * userInput;
                            break;
                    }

                    txtResult.Text = "" + result;
                    
                }
                else if (count > 2)
                {
                    switch (x)
                    {
                        case '+':
                            result += userInput;
                            break;
                        case '-':
                            result -= userInput;
                            break;
                        case '%':
                            if (userInput == 0 || userInput < 0)
                            {
                                txtResult.Text = "Result is undefined";
                            }
                            else
                            {
                                result %= userInput;
                            }
                            break;
                        case '/':
                            if (userInput == 0 || userInput < 0)
                            {
                                txtResult.Text = "Cannot divide by zero";
                            }
                            else
                            {
                                result /= userInput;
                            }
                            break;
                        case '*':
                            result *= userInput;
                            break;
                    }
                    txtResult.Text = "" + result;
                }
            }
            //Conditional to display user input above the text box
            if (userInput >= 0)
            {
                lblInput.Content += userInput + " + ";
                previousInput = Convert.ToDouble(userInput);
            }
            else
            {
                lblInput.Content += "negate(" + Math.Abs(userInput) + ")" + " + ";
                previousInput = Convert.ToDouble(userInput);
            }
           //Increasing count
            count++;
            changeValue = true;
            //setting operation to plus for equal sign event handler
            x = '+';
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {

            if (txtResult.Text.Equals("" + 0) || changeValue == true)
            {
                txtResult.Text = String.Empty;
                txtResult.FontSize = 30;
            }
            if (txtResult.Text.Length < 16)
            {
                txtResult.Text += 1;

                if (txtResult.Text.Length > 10 && txtResult.Text.Length <= 16)
                    txtResult.FontSize -= 1;
            }
       
              userInput = Convert.ToDouble(txtResult.Text);
            changeValue = false;
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {

            if (txtResult.Text.Equals("" + 0) || changeValue == true)
            {
                txtResult.Text = String.Empty;
                txtResult.FontSize = 30;
            }
            if (txtResult.Text.Length < 16)
            {
                txtResult.Text += 2;

                if (txtResult.Text.Length > 10 && txtResult.Text.Length <= 16)
                    txtResult.FontSize -= 1;
            }
       
                 userInput = Convert.ToDouble(txtResult.Text);
            changeValue = false;
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {

            if (txtResult.Text.Equals("" + 0) || changeValue == true)
            {
                txtResult.Text = String.Empty;
                txtResult.FontSize = 30;
            }

            if (txtResult.Text.Length < 16)
            {
                txtResult.Text += 3;

                if (txtResult.Text.Length > 10 && txtResult.Text.Length <= 16)
                    txtResult.FontSize -= 1;
            }

             userInput = Convert.ToDouble(txtResult.Text);
            changeValue = false;
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {

            if (txtResult.Text.Equals("" + 0) || changeValue == true)
            {
                txtResult.Text = String.Empty;
                txtResult.FontSize =30;
            }
            if (txtResult.Text.Length < 16)
            {
                txtResult.Text += 4;

                if (txtResult.Text.Length > 10 && txtResult.Text.Length <= 16)
                    txtResult.FontSize -= 1;
            }
            
             userInput = Convert.ToDouble(txtResult.Text);
            changeValue = false;
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {

            if (txtResult.Text.Equals("" + 0) || changeValue == true)
            {
                txtResult.Text = String.Empty;
                txtResult.FontSize = 30;
            }
            if (txtResult.Text.Length < 16)
            {
                txtResult.Text += 5;

                if (txtResult.Text.Length > 10 && txtResult.Text.Length <= 16)
                    txtResult.FontSize -= 1;
            }
            
            userInput = Convert.ToDouble(txtResult.Text);
            changeValue = false;
        }
        private void button6_Click(object sender, RoutedEventArgs e)
        {

            if (txtResult.Text.Equals("" + 0) || changeValue == true)
            {
                txtResult.Text = String.Empty;
                txtResult.FontSize = 30;
            }
            if (txtResult.Text.Length < 16)
            {
                txtResult.Text += 6;

                if (txtResult.Text.Length > 10 && txtResult.Text.Length <= 16)
                    txtResult.FontSize -= 1;
            }
            
                userInput = Convert.ToDouble(txtResult.Text);
            changeValue = false;
        }
        private void button9_Click(object sender, RoutedEventArgs e)
        {

            if (txtResult.Text.Equals("" + 0) || changeValue == true)
            {
                txtResult.Text = String.Empty;
                txtResult.FontSize = 30;
            }
            if (txtResult.Text.Length < 16)
            {
                txtResult.Text += 9;

                if (txtResult.Text.Length > 10 && txtResult.Text.Length <= 16)
                    txtResult.FontSize -= 1;
            }
            
               userInput = Convert.ToDouble(txtResult.Text);
            changeValue = false;
        }
        private void buttonEqual_Click(object sender, RoutedEventArgs e)
        {
           //Clearing the label above the textbox
            lblInput.Content = "";
            //A count of 1 does nothing
            if (count == 1)
            {
                txtResult.Text = "" + userInput;
            }
            else if (count == 2)
            {
                switch (x)
                {
                    case '+':
                        //Making sure changeValue is set to false to ensure that the previousInput has been erased
                        //and a new value is set to userInput
                        if (changeValue == false)
                            result = previousInput + userInput;
                        else
                            result = userInput;
                        break;
                    case '-':
                        if (changeValue == false)
                            result = previousInput - userInput;
                        else
                            result = userInput;
                        break;
                    case '%':
                        if (userInput == 0 || userInput < 0)
                        {
                            txtResult.FontSize = 15;
                            txtResult.Text = "Result is undefined";
                            //Resetting count to perform a new arithmetic sequence
                            count = 1;
                            //Setting userInput to result in case user wants to continue adding on from the start of the result
                            userInput = result;
                        }
                        else 
                        {
                            if (changeValue == false)
                                result = previousInput % userInput;
                            else
                                result = userInput;
                        }
                        break;
                    case '/':
                        if (userInput == 0 || userInput < 0)
                        {
                            txtResult.FontSize = 15;
                            if (userInput == 0)
                            {
                                txtResult.Text = "Cannot divide by zero";
                                count = 1;
                                userInput = result;
                            }
                            else
                            {
                                txtResult.Text = "Cannot divide by negative";
                                count = 1;
                                userInput = result;
                            }
                        }
                        else
                        {
                            if (changeValue == false)
                                result = previousInput / userInput;
                            else
                                result = userInput;
                        }
                        break;
                    case '*':
                        if (changeValue == false)
                            result = previousInput * userInput;
                        else
                            result = userInput;
                        break;
                }
                
                if (userInput == 0 && x == '/' || userInput == 0 && x == '%')
                {
                    //Do nothing 
                }
                else
                {
                    //Setting input to be a string representation of result for the 
                    //purpose of counting the length of result instead of txtResult.Text.Length which is currently
                    //set to userInput's length
                    input = Convert.ToString(result);
                    if (input.Length <= 10)
                    {
                        txtResult.FontSize = 30;
                    }
                    else
                    {
                        if (input.Length > 10 && input.Length <= 16)
                        {
                            txtResult.FontSize = 30 - (input.Length - 10) * 5;
                        }
                        else if(input.Length > 16)
                        {
                            txtResult.FontSize = 15;
                        }
                    }
                    txtResult.Text = "" + result;
                    count = 1;
                    userInput = result;
                }
            }
            else if(count > 2)
            {
                switch (x)
                {
                    case '+':
                        if (changeValue == false)
                        {
                            result += userInput;
                        }
                        break;
                    case '-':
                        if(changeValue == false)
                            result -= userInput;
                        break;
                    case '%':
                        if (userInput == 0 || userInput < 0)
                        {
                            txtResult.FontSize = 15;
                            txtResult.Text = "Result is undefined";
                            count = 1;
                            userInput = result;
                        }
                        else
                        {
                            if(changeValue == false)
                            result %= userInput;
                        }
                        break;
                    case '/':
                        if (userInput == 0 || userInput < 0)
                        {
                            txtResult.FontSize = 15;
                            if (userInput == 0){
                                txtResult.Text = "Cannot divide by zero";
                                count = 1;
                                userInput = result;
                            }
                            else {
                                txtResult.Text = "Cannot divide by negative";
                                count = 1;
                                userInput = result;
                            }
                            }
                        else
                        {
                           if(changeValue == false)
                                result /= userInput;
                        }
                        break;
                    case '*':
                        if(changeValue == false)
                        result *= userInput;
                        break;
                }
                if (userInput == 0 && x == '/' || userInput == 0 && x == '%')
                {

                }
                else
                {
                    input = Convert.ToString(result);
                    if (input.Length <= 10)
                    {
                        txtResult.FontSize = 30;
                    }
                    else
                    {
                        if (input.Length > 10 && input.Length <= 16)
                        {
                            txtResult.FontSize = 30 - (input.Length - 10) * 5;
                        }
                        else if (input.Length > 16)
                        {
                            txtResult.FontSize = 15;
                        }
                    }
                    txtResult.Text = "" + result;
                    count = 1;
                    userInput = result;
                }
            }
            //Resetting the result to 0
            result = 0;
            //Allowing the user to erase the current result and start a new arithmetic sequence
            changeValue = true;
           
        }
        private void buttonMod_Click(object sender, RoutedEventArgs e)
        { 
            if (count >= 2)
            {
                if (count == 2)
                {
                    switch (x)
                    {
                        case '+':
                                result = previousInput + userInput;
                            break;
                        case '-':
                                result = previousInput - userInput;
                            break;
                        case '%':
                            if (userInput == 0 || userInput < 0)
                            {
                                txtResult.Text = "Result is undefined";
                            }
                            else
                            {
                                    result = previousInput % userInput;
                            }
                            break;
                        case '/':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Cannot divide by zero";
                            }
                            else
                            {
                                    result = previousInput / userInput;
                            }
                            break;
                        case '*':
                                result = previousInput * userInput;
                            break;
                    }

                    txtResult.Text = "" + result;
                }
                else if (count > 2)
                {
                    switch (x)
                    {
                        case '+':
                                result += userInput; 
                            break;
                        case '-':
                            result -= userInput;
                            break;
                        case '%':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Result is undefined";
                            }
                            else
                            {
                                result %= userInput;
                            }
                            break;
                        case '/':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Cannot divide by zero";
                            }
                            else
                            {
                                result /= userInput;
                            }
                            break;
                        case '*':
                            result *= userInput;
                            break;
                    }
                    txtResult.Text = "" + result;
                }
            }
            if (userInput >= 0)
            {
                lblInput.Content += userInput + " Mod ";
                previousInput = Convert.ToDouble(userInput);
            }
            else
            {
                lblInput.Content += "negate(" + Math.Abs(userInput) + ")" + " Mod ";
                previousInput = Convert.ToDouble(userInput);
            }
            count++;
            x = '%';
            changeValue = true;
        }
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            //Clearing the textbox and label and resetting all variables
            txtResult.FontSize = 30;
            txtResult.Text = "" + 0;
            lblInput.Content = "";
            userInput = 0;
            previousInput = 0;
            result = 0;
            count = 1;
        }
        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
           //Increases the font size as textbox length goes down
            if(txtResult.Text.Length > 10 && txtResult.Text.Length <= 16)
                txtResult.FontSize += 1;
            if (changeValue == true)
            {

            }
            else
            {
                //Conditional to erase last number based on whether its a decimal or integer
                if (!txtResult.Text.Contains("."))
                {
                    txtResult.Text = "" + Convert.ToInt64(txtResult.Text) / 10;
                }
                else
                {
                    txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
                }
                userInput = Convert.ToDouble(txtResult.Text);
                changeValue = false;
            }
           

        }
        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {

            if (count >= 2)
            {
                if (count == 2)
                {
                    switch (x)
                    {
                        case '+':
                            result = previousInput + userInput;
                            //txtResult.Text = "" + result;
                            break;
                        case '-':
                            result = previousInput - userInput;
                            break;
                        case '%':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Result is undefined";
                            }
                            else
                            {
                                result = previousInput % userInput;
                            }
                            break;
                        case '/':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Cannot divide by zero";
                            }
                            else
                            {
                                result = previousInput / userInput;
                            }
                            break;
                        case '*':
                            result = previousInput * userInput;
                            break;
                    }

                    txtResult.Text = "" + result;
                }
                else if (count > 2)
                {
                    switch (x)
                    {
                        case '+':
                            result += userInput;
                            break;
                        case '-':
                            result -= userInput;
                            break;
                        case '%':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Result is undefined";
                            }
                            else
                            {
                                result %= userInput;
                            }
                            break;
                        case '/':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Cannot divide by zero";
                            }
                            else
                            {
                                result /= userInput;
                            }
                            break;
                        case '*':
                            result *= userInput;
                            break;
                    }
                    txtResult.Text = "" + result;
                }
            }
         
            if (userInput >= 0)
            {
                lblInput.Content += userInput + " / ";
                previousInput = Convert.ToDouble(userInput);
            }
            else
            {
                lblInput.Content += "negate(" + Math.Abs(userInput) + ")" + " / ";
                previousInput = Convert.ToDouble(userInput);
            }
            count++;
            x = '/';
            changeValue = true;
        }
        private void buttonTimes_Click(object sender, RoutedEventArgs e)
        {

            if (count >= 2)
            {
                if (count == 2)
                {
                    switch (x)
                    {
                        case '+':
                            result = previousInput + userInput;
                            break;
                        case '-':
                            result = previousInput - userInput;
                            break;
                        case '%':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Result is undefined";
                            }
                            else
                            {
                                result = previousInput % userInput;
                            }
                            break;
                        case '/':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Cannot divide by zero";
                            }
                            else
                            {
                                result = previousInput / userInput;
                            }
                            break;
                        case '*':
                            result = previousInput * userInput;
                            break;
                    }

                    txtResult.Text = "" + result;
                }
                else if (count > 2)
                {
                    switch (x)
                    {
                        case '+':
                            result += userInput;
                            break;
                        case '-':
                            result -= userInput;
                            break;
                        case '%':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Result is undefined";
                            }
                            else
                            {
                                result %= userInput;
                            }
                            break;
                        case '/':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Cannot divide by zero";
                            }
                            else
                            {
                                result /= userInput;
                            }
                            break;
                        case '*':
                            result *= userInput;
                            break;
                    }
                    txtResult.Text = "" + result;
                }
            }
       
            if (userInput >= 0)
            {
                lblInput.Content += userInput + " * ";
                previousInput = Convert.ToDouble(userInput);
            }
            else
            {
                lblInput.Content += "negate(" + Math.Abs(userInput) + ")" + " * ";
                previousInput = Convert.ToDouble(userInput);
            }
            count++;
            x = '*';
            changeValue = true;

        }
        private void button0_Click(object sender, RoutedEventArgs e)
        {

            if (txtResult.Text.Equals("" + 0) || changeValue == true)
            {
                txtResult.Text = String.Empty;
                txtResult.FontSize = 30;
            }
            if (txtResult.Text.Length < 16)
            {
                txtResult.Text += 0;

                if (txtResult.Text.Length > 10 && txtResult.Text.Length <= 16)
                    txtResult.FontSize -= 1;
            }
            userInput = Convert.ToDouble(txtResult.Text);
            changeValue = false;
        }
        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {

            if (count >= 2)
            {
                if (count == 2)
                {
                    switch (x)
                    {
                        case '+':
                            result = previousInput + userInput;
                          
                            break;
                        case '-':
                            result = previousInput - userInput;
                            break;
                        case '%':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Result is undefined";
                            }
                            else
                            {
                                result = previousInput % userInput;
                            }
                            break;
                        case '/':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Cannot divide by zero";
                            }
                            else
                            {
                                result = previousInput / userInput;
                            }
                            break;
                        case '*':
                            result = previousInput * userInput;
                            break;
                    }

                    txtResult.Text = "" + result;
                }
                else if (count > 2)
                {
                    switch (x)
                    {
                        case '+':
                            result += userInput;
                            break;
                        case '-':
                            result -= userInput;
                            break;
                        case '%':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Result is undefined";
                            }
                            else
                            {
                                result %= userInput;
                            }
                            break;
                        case '/':
                            if (userInput == 0)
                            {
                                txtResult.Text = "Cannot divide by zero";
                            }
                            else
                            {
                                result /= userInput;
                            }
                            break;
                        case '*':
                            result *= userInput;
                            break;
                    }
                    txtResult.Text = "" + result;
                }
            }
        
            if (userInput >= 0)
            {
                lblInput.Content += userInput + " - ";
                previousInput = Convert.ToDouble(userInput);
            }
            else
            {
                lblInput.Content += "negate(" + Math.Abs(userInput) + ")" + " - ";
                previousInput = Convert.ToDouble(userInput);
            }
            count++;
            x = '-';
            changeValue = true;
        }
    }
}
