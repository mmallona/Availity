using System;
using System.Diagnostics;
using System.Text;

namespace LispValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test");

            if ( args.Length > 0 )
            {
                StringBuilder lispCoced = new StringBuilder();

                foreach(string line in args)
                {
                    lispCoced.Append(line);
                }

                bool IsCorrect = ValidateLispExpressions(lispCoced.ToString());

                Console.WriteLine($"Is Lisp Expression correct : {IsCorrect}");
            }
            else
                Console.WriteLine("No Parameters were passed, please enter a lisp sequence in the Debug arguments ");

            Console.WriteLine("Exiting!");
           // Console.ReadLine();
        }

        static bool ValidateLispExpressions(string lispInput)
        {
            bool IsCorrect = false;
            int openCounter = 0;
            int closeCounter = 0;

            int locationOpen = lispInput.IndexOf('(');
            int locationClosed = lispInput.IndexOf(')');

            if (locationOpen > -1)
            {
                openCounter++;
            }

            // the Close is the first character
            if (locationOpen > locationClosed)
            {
                return IsCorrect;
            }

            string [] openAr = lispInput.Split("(");
            string[] closedAr = lispInput.Split(")");

            openCounter = openAr.Length;
            closeCounter = closedAr.Length;

            if ( openCounter ==  closeCounter)
            {
                IsCorrect = true;
            }

            return IsCorrect;
        }
    }
}
