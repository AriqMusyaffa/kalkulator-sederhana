using System;

namespace Kalkulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int act;
            char op, retry;
            double num1, num2, result;
            bool valid, re1;

            Console.Clear();

            Restart:
            act = 0;
            op = ' ';
            result = 0;
            valid = re1 = false;

            while (!valid)
            {
                Console.WriteLine("Enter the action to be performed :");
                Console.WriteLine("Press [1] for Addition");
                Console.WriteLine("Press [2] for Subtraction");
                Console.WriteLine("Press [3] for Multiplication");
                Console.WriteLine("Press [4] for Division\n");
                Console.Write("Input : ");

                try
                {
                    act = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    InvalidInput(true);
                    goto Restart;
                }

                if (act < 1 || act > 4)
                {
                    Console.Clear();
                    InvalidInput(true);
                    goto Restart;
                }
                else
                {
                    switch (act)
                    {
                        case 1:
                            op = '+';
                            break;
                        case 2:
                            op = '-';
                            break;
                        case 3:
                            op = 'x';
                            break;
                        case 4:
                            op = ':';
                            break;
                        default:
                            op = ' ';
                            break;
                    }
                    valid = true;
                }
                Console.WriteLine("==================================\n");
            }

            FirstNum:
            num1 = 0;
            Console.Write("Input 1st number : ");
            try
            {
                num1 = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e1)
            {
                InvalidInput(false);
                goto FirstNum;
            }

            SecondNum:
            num2 = 0;

            if (re1)
            {
                Console.WriteLine("Input 1st number : " + num1);
                re1 = false;
            }

            Console.Write("Input 2nd number : ");
            try
            {
                num2 = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e2)
            {
                InvalidInput(false);
                re1 = true;
                goto SecondNum;
            }
            
            Console.WriteLine("==================================\n");
            Console.Write("Result : \t" + num1 + " " + op + " ");
            if (num2 < 0)
            {
                Console.Write("(" + num2 + ")");
            }
            else
            {
                Console.Write(num2);
            }
            Console.Write(" = ");
            switch (act)
            {
                case 1:
                    result = num1 + num2;
                    break;
                case 2:
                    result = num1 - num2;
                    break;
                case 3:
                    result = num1 * num2;
                    break;
                case 4:
                    result = num1 / num2;
                    break;
                default:
                    result = 0;
                    break;
            }
            if (result < 0)
            {
                Console.WriteLine("(" + result + ")");
            }
            else
            {
                Console.WriteLine(result);
            }

            Retry:
            retry = ' ';
            Console.WriteLine("==================================\n");
            Console.WriteLine("Restart Calculator? [Y/N]\n");
            Console.Write("Input : ");
            try
            {
                retry = Convert.ToChar(Console.ReadLine());
            }
            catch (Exception er)
            {
                InvalidInput(false);
                goto Retry;
            }
            retry = Char.ToUpper(retry);
            switch (retry)
            {
                case 'Y':
                    Console.Clear();
                    goto Restart;
                    break;
                case 'N':
                    Console.WriteLine("\n==================================");
                    Console.WriteLine("End program.");
                    Console.WriteLine("==================================\n");
                    break;
                default:
                    InvalidInput(false);
                    goto Retry;
                    break;
            }
        }

        static void InvalidInput(bool x)
        {
            Console.WriteLine("\nInvalid input! Please try again.");
            if (x)
            {
                Console.WriteLine("==================================\n");
            }
            else
            {
                Console.WriteLine("\n");
            }
        }
    }
}