namespace SharpCalculator
{
    internal class Program{
        static void Main(string[] args){
            
            do{
                double num1 = 0;
                double num2 = 0;
                double result = 0;
                string option;


                Console.WriteLine("\n- - - - - - - - - - - -");
                Console.WriteLine("| - C # Calculator -  |");
                Console.WriteLine("- - - - - - - - - - - -");


                Console.Write("Enter number 1: ");
                num1 = Convert.ToDouble(Console.ReadLine());


                do {
                    Console.Write("\t+ : Add");
                    Console.Write("\t\t- : Subtract\n");
                    Console.Write("\t* : Multiply");
                    Console.Write("\t/ : Divide\n");
                    Console.Write("Enter an option: ");
                    option = Console.ReadLine();

                    if(option != "+" && option != "-" && option != "*" && option != "/"){

                        Console.WriteLine("no valid option!");
                    }

                }while (option != "+" && option != "-" && option != "*" && option != "/");


                Console.Write("Enter number 2: ");
                num2 = Convert.ToDouble(Console.ReadLine());


                switch (option){

                    case "+":
                        result = num1 + num2;
                        Console.WriteLine($"Your result: {num1} + {num2} = " + result);
                        break;
                    case "-":
                        result = num1 - num2;
                        Console.WriteLine($"Your result: {num1} - {num2} = " + result);
                        break;
                    case "*":
                        result = num1 * num2;
                        Console.WriteLine($"Your result: {num1} * {num2} = " + result);
                        break;
                    case "/":
                        result = num1 / num2;
                        Console.WriteLine($"Your result: {num1} / {num2} = " + result);
                        break;
                }

                Console.Write("\nContinue? (Y = yes, N = No): ");

            } while (Console.ReadLine().ToUpper() == "Y");

            Console.WriteLine("Bye!");
            Console.ReadKey();
        }
    }
}