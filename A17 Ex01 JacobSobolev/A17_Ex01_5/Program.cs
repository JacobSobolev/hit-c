using System;
using System.Collections.Generic;
using System.Text;


namespace A17_Ex01_5 {
    class Program {

        public static void Main() {
            staticsNumbers();
        }

        private static void staticsNumbers() {
            string validUserInputString;
            int validUserInputLength = 7;
            int largestDigit;
            int smallestDigit;
            int numOfDigitsGreaterThanUnitsDigit;
            int numOfDigitsLessThanUnitsDigit;

            validUserInputString = getInputFromUserAndValidate(validUserInputLength);

            largestDigit = findTheLargetDigitInString(validUserInputString);
            smallestDigit = findTheSmallestDigitInString(validUserInputString);
            numOfDigitsGreaterThanUnitsDigit = checkAmoutOfDigitisGreaterThanUnitsDigit(validUserInputString);
            numOfDigitsLessThanUnitsDigit = checkAmoutOfDigitisLessThanUnitsDigit(validUserInputString);

            displayResults(largestDigit, smallestDigit, numOfDigitsGreaterThanUnitsDigit, numOfDigitsLessThanUnitsDigit);

        }


        private static string getInputFromUserAndValidate(int i_ValidUserInputLength) {
            bool isUserInputValid = false;
            string userInputStringToValidate;
            Console.WriteLine(@"Hi There!
Please enter a positive number containing {0} digits", i_ValidUserInputLength);
            do {
                userInputStringToValidate = Console.ReadLine();
                isUserInputValid = validateUserInput(userInputStringToValidate, i_ValidUserInputLength);
                if (!isUserInputValid) {
                    Console.WriteLine("The input is invalid. Read the instructions again and try again");
                }

            } while (!isUserInputValid);

            return userInputStringToValidate;
        }

        private static bool validateUserInput(string i_StrToValidate, int i_ValidUserInputLength) {

            bool returnIsInputValid = false;
            
            if (i_StrToValidate.Length == i_ValidUserInputLength) {
                if (A17_Ex01_4.Program.checkIfStrContainsOnlyNumbers(i_StrToValidate)) {
                    returnIsInputValid = true;
                }
            }

            return returnIsInputValid;
        }


        private static int findTheLargetDigitInString(string i_ValidUserInputString) {
            int biggestDigitInInput = i_ValidUserInputString[0] - '0';
            for (int i = 1; i < i_ValidUserInputString.Length; i++) {
                biggestDigitInInput = Math.Max(biggestDigitInInput, i_ValidUserInputString[i] - '0');
            }

            return biggestDigitInInput;
        }

        private static int findTheSmallestDigitInString(string i_ValidUserInputString) {
            int smallestDigitInInput = i_ValidUserInputString[0] - '0';
            for (int i = 1; i < i_ValidUserInputString.Length; i++) {
                smallestDigitInInput = Math.Min(smallestDigitInInput, i_ValidUserInputString[i] - '0');
            }

            return smallestDigitInInput;
        }



        private static int checkAmoutOfDigitisGreaterThanUnitsDigit(string i_ValidUserInputString) {

            int numOfDigitsGreaterThanUnitsDigit = 0;
            int unitsDigit = i_ValidUserInputString[0] - '0';

            for (int i = 1; i < i_ValidUserInputString.Length; i++) {
                if (i_ValidUserInputString[i] - '0' > unitsDigit) {
                    numOfDigitsGreaterThanUnitsDigit++;
                }
            }

            return numOfDigitsGreaterThanUnitsDigit;
        }

        private static int checkAmoutOfDigitisLessThanUnitsDigit(string i_ValidUserInputString) {
            int numOfDigitsLessThanUnitsDigit = 0;
            int unitsDigit = i_ValidUserInputString[0] - '0';

            for (int i = 1; i < i_ValidUserInputString.Length; i++) {
                if (i_ValidUserInputString[i] - '0' < unitsDigit) {
                    numOfDigitsLessThanUnitsDigit++;
                }
            }

            return numOfDigitsLessThanUnitsDigit;
        }

        private static void displayResults(int i_LargestDigit, int i_SmallestDigit, int i_NumOfDigitsGreaterThanUnitsDigit, int i_NumOfDigitsLessThanUnitsDigit) {

            string introMsg = string.Format(
@"
The Results are: 
===================
");
            Console.WriteLine(introMsg);

            string detailMsg = string.Format(
@"The largest digit in your number is {0} 
The smallest digit in your number is {1} 
The number of digits that are bigger than the units digit is {2} 
The number of digits that are smaller than the units digit is {3}", i_LargestDigit, i_SmallestDigit, i_NumOfDigitsGreaterThanUnitsDigit, i_NumOfDigitsLessThanUnitsDigit);

            Console.WriteLine(detailMsg);

        }


    }
}
