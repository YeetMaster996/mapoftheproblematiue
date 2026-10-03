namespace MapOfTheProblematique.Utilities
{
    public static class Recursion
    {

        public static int RecursionNumber(int number)
        {

            if (number >= 0)
            {
                return 0;
            }

            Console.WriteLine(number);
            return RecursionNumber(number - 1);

        }
       
        public static int ReverseCountFactorialRecursion(int factorialNumber)
        {
            if (factorialNumber == 1)
                return 1;

            else
            {
                return factorialNumber * ReverseCountFactorialRecursion(factorialNumber - 1);
            }
        }
        public static int SumOfNumber(int number)

        {
            if (number == 0)
            {
                return 0;
            }
            else
            {
                return number+SumOfNumber(number - 1);
            }
        }
    }



}
