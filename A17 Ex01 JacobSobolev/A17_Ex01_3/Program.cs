using System;

namespace A17_Ex01_3 {
    public class Program {

        public static void Main() {
            createAdvancedSandClock();
        }


        private static void createAdvancedSandClock() {

            int numOfLines = getInputFromUserAndValidate();

            string sandClockAdvancedStr = A17_Ex01_2.Program.CreateSandClockStr(numOfLines);
            Console.WriteLine(sandClockAdvancedStr);
        }

        private static int getInputFromUserAndValidate() {
            bool isInputValid;
            int returnNumOfLines;
            string strToValidate;
            Console.WriteLine(@"Hi There! 
Please enter the positive number (1 and above) of lines the sand clock will have:");

            do {
                strToValidate = Console.ReadLine();
                isInputValid = validateUserInput(strToValidate, out returnNumOfLines);
                if (!isInputValid) {
                    Console.WriteLine("The input is invalid. Read the instructions again and try again");
                }
            }
            while (!isInputValid);

            return returnNumOfLines;

        }

        private static bool validateUserInput(string i_StrToValidate, out int o_NumOfLines) {
            bool returnIsInputValid = false;

            returnIsInputValid = int.TryParse(i_StrToValidate, out o_NumOfLines);
            if (o_NumOfLines <= 0) {
                returnIsInputValid = false;
            }

            return returnIsInputValid;
        }



    }
}
