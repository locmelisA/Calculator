using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Prevent_operations_to_use();
        }

        bool operation_is_finished = false;
        bool dot_decimal_is_used = false;
        bool operation_is_used = false;

        public void dot_decimal_is_used_control_function()
        {
            if (dot_decimal_is_used == true)
            {
                Decimal_Button.Enabled = false;
            }
            if (operation_is_used == true)
            {
                Decimal_Button.Enabled = true;
                dot_decimal_is_used = false;
            }
        }

        public void Allow_operations_to_use()
        {
            Plus_Button.Enabled = true;
            Minus_Button.Enabled = true;
            Mult_Button.Enabled = true;
            Divide_Button.Enabled = true;
            Decimal_Button.Enabled = true;
            Equals_Button.Enabled = true;
            operation_is_finished = false;
        }

        public void Prevent_operations_to_use()
        {
            Plus_Button.Enabled = false;
            Minus_Button.Enabled = false;
            Mult_Button.Enabled = false;
            Divide_Button.Enabled = false;
            Decimal_Button.Enabled = false;
            Equals_Button.Enabled = false;
            operation_is_finished = false;
        }

        public void Check_Operation()
        {
            if (operation_is_finished == true)
            {
                richTextBox1.Text = "";
            }
        }

        public void Update_RichTextBox_When_Number_Is_Pressed(string number)
        {
            richTextBox1.Text = richTextBox1.Text + number;
            Allow_operations_to_use();
            dot_decimal_is_used_control_function();
            operation_is_used = false;
        }

        public void Update_RickTextBox_When_Operation_Is_Pressed(string operation)
        {
            richTextBox1.Text = richTextBox1.Text + operation;
            Prevent_operations_to_use();
            operation_is_used = true;
        }

        private void Number0_Button_Click(object sender, EventArgs e)
        {
            Check_Operation();
            string number0 = "0";
            Update_RichTextBox_When_Number_Is_Pressed(number0);

        }

        private void Number1_Button_Click(object sender, EventArgs e)
        {
            Check_Operation();
            string number1 = "1";
            Update_RichTextBox_When_Number_Is_Pressed(number1);
        }

        private void Number2_Button_Click(object sender, EventArgs e)
        {
            Check_Operation();
            string number2 = "2";
            Update_RichTextBox_When_Number_Is_Pressed(number2);
        }

        private void Number3_Button_Click(object sender, EventArgs e)
        {
            Check_Operation();
            string number3 = "3";
            Update_RichTextBox_When_Number_Is_Pressed(number3);
        }

        private void Number4_Button_Click(object sender, EventArgs e)
        {
            Check_Operation();
            string number4 = "4";
            Update_RichTextBox_When_Number_Is_Pressed(number4);
        }

        private void Number5_Button_Click(object sender, EventArgs e)
        {
            Check_Operation();
            string number5 = "5";
            Update_RichTextBox_When_Number_Is_Pressed(number5);
        }

        private void Number6_Button_Click(object sender, EventArgs e)
        {
            Check_Operation();
            string number6 = "6";
            Update_RichTextBox_When_Number_Is_Pressed(number6);
        }

        private void Number7_Button_Click(object sender, EventArgs e)
        {
            Check_Operation();
            string number7 = "7";
            Update_RichTextBox_When_Number_Is_Pressed(number7);
        }

        private void Number8_Button_Click(object sender, EventArgs e)
        {
            Check_Operation();
            string number8 = "8";
            Update_RichTextBox_When_Number_Is_Pressed(number8);
        }

        private void Number9_Button_Click(object sender, EventArgs e)
        {
            Check_Operation();
            string number9 = "9";
            Update_RichTextBox_When_Number_Is_Pressed(number9);
        }

        private void Plus_Button_Click(object sender, EventArgs e)
        {
            string plus = " + ";
            Update_RickTextBox_When_Operation_Is_Pressed(plus);
        }

        private void Minus_Button_Click(object sender, EventArgs e)
        {
            string minus = " - ";
            Update_RickTextBox_When_Operation_Is_Pressed(minus);
        }

        private void Mult_Button_Click(object sender, EventArgs e)
        {
            string mult = " * ";
            Update_RickTextBox_When_Operation_Is_Pressed(mult);
        }

        private void Divide_Button_Click(object sender, EventArgs e)
        {
            string divide = " / ";
            Update_RickTextBox_When_Operation_Is_Pressed(divide);
        }

        private void Decimal_Button_Click(object sender, EventArgs e)
        {
            string dot = ".";
            Update_RickTextBox_When_Operation_Is_Pressed(dot);
            //can be bad with operation is finished = false! need to test this.. so far it seems working!
        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            Prevent_operations_to_use();
            dot_decimal_is_used = false;
            operation_is_used = false;
        }

        private void Equals_Button_Click(object sender, EventArgs e)
        {
            string result_string = richTextBox1.Text.Replace(" ", string.Empty);
            string number_builder = "";
            string simplified_result_string = "";
            double result = 0;
            double temporary_result = 0;
            bool plus_flag = false;
            bool minus_flag = false;
            bool mult_flag = false;
            bool div_flag = false;
            bool first_time = true;
            bool E_is_used = false;

            foreach (char c in result_string)
            {
                if (c == '+')
                {
                    if (first_time == false)
                    {
                        if (mult_flag == true)
                        {
                            temporary_result = temporary_result * double.Parse(number_builder);
                        }
                        if (div_flag == true)
                        {
                            temporary_result = temporary_result / double.Parse(number_builder);
                        }
                        simplified_result_string = simplified_result_string + temporary_result.ToString() + c;
                        number_builder = "";
                        temporary_result = 0;
                        first_time = true;
                        mult_flag = false;
                        div_flag = false;
                    }
                    else if (E_is_used == true)
                    {
                        number_builder = number_builder + c;
                        E_is_used = false;
                    }
                    else
                    {
                        simplified_result_string = simplified_result_string + number_builder + c;
                        number_builder = "";
                        first_time = true;
                        mult_flag = false;
                        div_flag = false;
                    }
                }
                else if (c == '-')
                {
                    if (first_time == false)
                    {
                        if (mult_flag == true)
                        {
                            temporary_result = temporary_result * double.Parse(number_builder);
                        }
                        if (div_flag == true)
                        {
                            temporary_result = temporary_result / double.Parse(number_builder);
                        }
                        simplified_result_string = simplified_result_string + temporary_result.ToString() + c;
                        number_builder = "";
                        temporary_result = 0;
                        first_time = true;
                        mult_flag = false;
                        div_flag = false;
                    }
                    else if (E_is_used == true)
                    {
                        number_builder = number_builder + c;
                        E_is_used = false;
                    }
                    else
                    {
                        simplified_result_string = simplified_result_string + number_builder + c;
                        number_builder = "";
                        first_time = true;
                        mult_flag = false;
                        div_flag = false;
                    }
                }
                else if (c == '*')
                {
                    if (first_time == true) //if first operation is *
                    {
                        temporary_result = temporary_result + double.Parse(number_builder);
                        number_builder = "";
                        first_time = false;
                        mult_flag = true;
                        div_flag = false;
                    }
                    else if (div_flag == true)
                    {
                        temporary_result = temporary_result / double.Parse(number_builder);
                        number_builder = "";
                        mult_flag = true;
                        div_flag = false;
                    }
                    else
                    {
                        temporary_result = temporary_result * double.Parse(number_builder);
                        number_builder = "";
                        mult_flag = true;
                        div_flag = false;
                    }
                }

                else if (c == '/')
                {
                    if (first_time == true) //if first operation is /
                    {
                        temporary_result = temporary_result + double.Parse(number_builder);
                        number_builder = "";
                        first_time = false;
                        mult_flag = false;
                        div_flag = true;
                    }
                    else if (mult_flag == true)
                    {
                        temporary_result = temporary_result * double.Parse(number_builder);
                        number_builder = "";
                        mult_flag = false;
                        div_flag = true;
                    }
                    else
                    {
                        temporary_result = temporary_result / double.Parse(number_builder);
                        number_builder = "";
                        mult_flag = false;
                        div_flag = true;
                    }
                }
                else if (c == 'E')
                {
                    number_builder = number_builder + c;
                    E_is_used = true;
                }


                else
                {
                    number_builder = number_builder + c;
                }
            }


            if (mult_flag == true)
            {
                temporary_result = temporary_result * double.Parse(number_builder);
                simplified_result_string = simplified_result_string + temporary_result.ToString();
                //MessageBox.Show(simplified_result_string); //debug purpose
            }
            else if (div_flag == true)
            {
                temporary_result = temporary_result / double.Parse(number_builder);
                simplified_result_string = simplified_result_string + temporary_result.ToString();
                //MessageBox.Show(simplified_result_string); //debug purpose
            }
            else
            {
                simplified_result_string = simplified_result_string + number_builder;
                //MessageBox.Show(simplified_result_string); //debug purpose
            }

            result_string = simplified_result_string;
            number_builder = "";



            foreach (char c in result_string)
            {
                if (c == '+')
                {
                    if (first_time == true) //if first operation is +
                    {
                        result = result + double.Parse(number_builder);
                        number_builder = "";
                        first_time = false;
                        plus_flag = true;
                        minus_flag = false;
                    }
                    else if (minus_flag == true) // if previous operation is -
                    {
                        result = result - double.Parse(number_builder);
                        number_builder = "";
                        plus_flag = true;
                        minus_flag = false;
                    }
                    else if (E_is_used == true)
                    {
                        number_builder = number_builder + c;
                        E_is_used = false;
                    }
                    else // if previous operation is + (it can be huge + + + + + +)
                    {
                        result = result + double.Parse(number_builder);
                        number_builder = "";
                        plus_flag = true;
                        minus_flag = false;
                    }
                }
                else if (c == '-') //if first operation is -
                {
                    if (first_time == true)
                    {
                        try
                        {
                            result = result + double.Parse(number_builder);//0+50=50
                            number_builder = "";
                            first_time = false;
                            plus_flag = false;
                            minus_flag = true;
                        }
                        catch (FormatException)
                        {
                            number_builder = number_builder + c;
                        }
                    }
                    else if (E_is_used == true)
                    {
                        number_builder = number_builder + c;
                        E_is_used = false;
                    }
                    else if (plus_flag == true) //if previous operation is -
                    {
                        result = result + double.Parse(number_builder);
                        number_builder = "";
                        plus_flag = false;
                        minus_flag = true;
                    }
                    else // if previous operation is - (it can be huge - - - - - -)
                    {
                        try
                        {
                            result = result - double.Parse(number_builder);
                            number_builder = "";
                            plus_flag = false;
                            minus_flag = true;
                        }
                        catch(FormatException)
                        {
                            number_builder = number_builder + c;
                        }
                    }
                }
                else if (c == 'E')
                {
                    number_builder = number_builder + c;
                    E_is_used = true;
                }
                else
                {
                    number_builder = number_builder + c;
                }
            }

            if (plus_flag == true) //add the last number to the result
            {
                result = result + double.Parse(number_builder);
            }
            else if (minus_flag == true) // take away last number from the result
            {
                result = result - double.Parse(number_builder);
            }
            else
            {
                result = result + double.Parse(number_builder);
            }

            if (result.ToString() == "∞" || result.ToString() == "-∞")
            {
                richTextBox1.Text = "Error: Cannot divide by zero or you got float out of bounds";
                Plus_Button.Enabled = false;
                Minus_Button.Enabled = false;
                Mult_Button.Enabled = false;
                Divide_Button.Enabled = false;
                Decimal_Button.Enabled = false;
            }
            else
            {
                richTextBox1.Text = result.ToString();
            }
            operation_is_finished = true;
            Decimal_Button.Enabled = false;
            Equals_Button.Enabled = false;
            dot_decimal_is_used = false;
        }
    }
}
