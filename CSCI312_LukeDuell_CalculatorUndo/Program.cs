using System;
using System.Runtime.CompilerServices;

namespace CSCI312_LukeDuell_CalculatorAssignment
{
    class InputErrorChecking
    {
        public int result { get; set; }
        public float output_int { get; set; }
        public string output_string { get; set; }

        public InputErrorChecking(int result_priv)
        {
            //takes in input from user
            float input_int_priv;
            string input_string_priv = Console.ReadLine();
            //tries input to see if input is a string
            try
            {
                input_int_priv = float.Parse(input_string_priv);
                output_int = input_int_priv;
                output_string = output_int.ToString();
            }
            //if input is a string error is caught
            catch (FormatException)
            {
                if ((input_string_priv!="+") && (input_string_priv != "-") && (input_string_priv != "/") && (input_string_priv != "*") && (input_string_priv != "UNDO") && (input_string_priv != "CLEAR") && (input_string_priv != "EXIT"))
                {
                    Console.WriteLine("Input entered is incorrect format");
                    result_priv = 1;
                }
                else
                {
                    output_string = input_string_priv;
                }
            }
            //if there is an unexpected character it is caught here
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected Error: {exception.Message}");
                result_priv = 1;
            }
            //result is stored in a public int
            result = result_priv;
            
        }
    }
    class Program
    {
        static void Main()
        {
        clear:
            //prompting the user to enter a number or operator
            Console.WriteLine("After each number or operator press enter.\n Example: 10 *PRESS ENTER* + *PRESS ENTER* 10 *PRESS ENTER*");


            int order = 0;
            int ErrorCheck = 0;
            float firstdigit = 1543, lastdigit = 0;
            string operatorstorage = string.Empty;
            string type = string.Empty;
            string storedtype = string.Empty;
            float[] output = new float[10];
            float outputconsole = 0;
            int j = 0;



        here:
            InputErrorChecking u_input = new InputErrorChecking(ErrorCheck);

            string test = u_input.output_string;
            float i = 0;
            


            //checking to see if string has a number
            bool result = float.TryParse(test, out i);
            if (result)
            {
                type = "digit";
            }
            else if ((result == false) && ((test == "/") || (test == "*") || (test == "-") || (test == "+")))
            {
                type = "operator";
            }
            else if( (result == false) && ((test != "UNDO") || (test != "CLEAR") || (test != "EXIT")))
            {
                type = "prog";
            }


            switch (type)
            {
                //case if the input is a number
                case "digit":
                    if(order == 0)
                    {
                        firstdigit = i;
                    }
                    else
                    {
                        lastdigit = i;

                        switch (operatorstorage)
                        {
                            //case for plus
                            case "+":
                                if(firstdigit == 1543)
                                {
                                    outputconsole = outputconsole + lastdigit;
                                    Console.WriteLine($"SUM: {output[j-1]} + {lastdigit} = {outputconsole};RUNNING TOTAL: {outputconsole}");
                                }
                                else
                                {
                                    outputconsole = firstdigit + lastdigit;
                                    Console.WriteLine($"SUM: {firstdigit} + {lastdigit} = {outputconsole};RUNNING TOTAL: {outputconsole}");
                                }
                                
                                firstdigit = 1543;
                                //incrementing for every output
                                j++;
                                break;

                            //case for minus
                            case "-":
                                if (firstdigit == 1543)
                                {
                                    outputconsole = outputconsole - lastdigit;
                                    Console.WriteLine($"SUB: {output[j - 1]} - {lastdigit} = {outputconsole};RUNNING TOTAL: {outputconsole}");
                                }
                                else
                                {
                                    outputconsole = firstdigit - lastdigit;
                                    Console.WriteLine($"SUB: {firstdigit} - {lastdigit} = {outputconsole};RUNNING TOTAL: {outputconsole}");
                                }

                                firstdigit = 1543;
                                //incrementing for every output
                                j++;
                                break;

                            //case for mult
                            case "*":
                                if (firstdigit == 1543)
                                {
                                    outputconsole = outputconsole * lastdigit;
                                    Console.WriteLine($"MULT: {output[j - 1]} * {lastdigit} = {outputconsole};RUNNING TOTAL: {outputconsole}");
                                }
                                else
                                {
                                    outputconsole = firstdigit * lastdigit;
                                    Console.WriteLine($"MULT: {firstdigit} * {lastdigit} = {outputconsole};RUNNING TOTAL: {outputconsole}");
                                }
                                
                                firstdigit = 1543;
                                //incrementing for every output
                                j++;
                                break;

                            //case for div
                            case "/":
                                if (firstdigit == 1543)
                                {
                                    outputconsole = outputconsole / lastdigit;
                                    Console.WriteLine($"DIV: {output[j - 1]} / {lastdigit} = {outputconsole};RUNNING TOTAL: {outputconsole}");
                                }
                                else
                                {
                                    outputconsole = firstdigit / lastdigit;
                                    Console.WriteLine($"DIV: {firstdigit} / {lastdigit} = {outputconsole};RUNNING TOTAL: {outputconsole}");
                                }
                                
                                firstdigit = 1543;
                                //incrementing for every output
                                j++;
                                break;

                        }
                        order = 0;
                    }
                    break;

                case "operator":
                    switch (test)
                    {
                        //case for plus
                        case "+":
                            operatorstorage = test;
                            order = 1;
                            break;

                        //case for minus
                        case "-":
                            operatorstorage = test;
                            order = 1;
                            break;

                        //case for mult
                        case "*":
                            operatorstorage = test;
                            order = 1;
                            break;

                        //case for div
                        case "/":
                            operatorstorage = test;
                            order = 1;
                            break;

                    }
                    break;

                case "prog":
                    switch (test)
                    {
                        //case for UNDO
                        case "UNDO":
                            if(output[0] == 0)
                            {
                                Console.WriteLine("UNDO IS NOT AVAILABLE");
                                goto clear;
                            }
                            else
                            {
                                j--;
                                outputconsole = output[j-1];
                                Console.WriteLine($"RUNNING TOTAL: {outputconsole}");
                            }
                            break;

                        //case for CLEAR
                        case "CLEAR":
                            Console.Clear();
                            goto clear;

                        //case for EXIT
                        case "EXIT":
                            System.Environment.Exit(0);
                            break;
                    }
                    break;
            }
            //shifting the outputs for UNDO sequence

            if(j > 0)
            {
                output[j - 1] = outputconsole;
            }
            else
            {
                output[j] = outputconsole;
            }
            storedtype = type;
            goto here;
        }
    }
}
