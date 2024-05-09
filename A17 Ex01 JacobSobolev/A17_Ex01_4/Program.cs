using System;


namespace A17_Ex01_4 {
    public class Program {

        private enum eUserInputType{
            OnlyNumbers,
            OnlyLetters,
            InValid
        }

        public static void Main() {
            stringAnalysis();
        }


        private static void stringAnalysis() {

            string validUserInputString;
            int validUserInputLength = 6;
            eUserInputType userInputType;

            bool isUserInputPalindrome = false;
            double decimalAverage = -1;
            int numOfUpperCaseLetters = -1;


            validUserInputString = getInputFromUserAndValidate(validUserInputLength, out userInputType);
            isUserInputPalindrome = checkIfStrIsPalindrome(validUserInputString);
            if (userInputType == eUserInputType.OnlyLetters) {
                numOfUpperCaseLetters = checkNumOfUpperCaseLetters(validUserInputString);
            }
            else  {
                decimalAverage = calculateDecimalAverage(validUserInputString);
            }

            displayResults(isUserInputPalindrome, userInputType, decimalAverage, numOfUpperCaseLetters);


        }


        private static string getInputFromUserAndValidate(int i_ValidUserInputLength, out eUserInputType o_UserInputType) {
            bool isUserInputValid = false;
            string userInputStringToValidate;
            Console.WriteLine(@"Hi There!
Please enter a string of {0} characters (numbers only or letters only)", i_ValidUserInputLength);
            do {
                userInputStringToValidate = Console.ReadLine();
                isUserInputValid = validateUserInput(userInputStringToValidate, i_ValidUserInputLength, out o_UserInputType);
                if (!isUserInputValid) {
                    Console.WriteLine("The input is invalid. Read the instructions again and try again");
                }

            } while (!isUserInputValid);

            return userInputStringToValidate;
        }

        private static bool validateUserInput(string i_StrToValidate, int i_ValidUserInputLength, out eUserInputType o_UserInputType) {

            bool returnIsInputValid = false;
            o_UserInputType = eUserInputType.InValid;
            if (i_StrToValidate.Length == i_ValidUserInputLength) {
                if (checkIfStrContainsOnlyLetters(i_StrToValidate)) {
                    o_UserInputType = eUserInputType.OnlyLetters;
                    returnIsInputValid = true;
                }
                else if (checkIfStrContainsOnlyNumbers(i_StrToValidate)) {
                    o_UserInputType = eUserInputType.OnlyNumbers;
                    returnIsInputValid = true;
                }
            }

            return returnIsInputValid;
        }

        public static bool checkIfStrContainsOnlyNumbers(string i_ValidUserInputString) {
            bool returnIsOnlyNumbers = true;
            for (int i = 0; i < i_ValidUserInputString.Length && returnIsOnlyNumbers; i++) {
                if (!char.IsDigit(i_ValidUserInputString, i)) {
                    returnIsOnlyNumbers = false;
                }
            }

            return returnIsOnlyNumbers;
        }

        private static bool checkIfStrContainsOnlyLetters(string i_ValidUserInputString) {
            bool returnIsOnlyLetters = true;
            for (int i = 0; i < i_ValidUserInputString.Length && returnIsOnlyLetters; i++) {
                if (!char.IsLetter(i_ValidUserInputString, i)) {
                    returnIsOnlyLetters = false;
                }
            }

            return returnIsOnlyLetters;
        }

        private static bool checkIfStrIsPalindrome(string i_ValidUserInputString) {
            bool isPalindrome = true;
            int offsetInStringToCheck = 0;
            int userInputStringLength = i_ValidUserInputString.Length;
            if (userInputStringLength % 2 == 0) {
                offsetInStringToCheck = 1;
            }
            for (int i = 0; i < userInputStringLength  / 2 + offsetInStringToCheck; i++) {
                if (i_ValidUserInputString[i] != i_ValidUserInputString[userInputStringLength - 1 - i]) {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }

        private static double calculateDecimalAverage(string i_ValidUserInputString) {
            int sumOfNumbers = 0;
            for (int i = 0; i < i_ValidUserInputString.Length; i++) {
                sumOfNumbers += i_ValidUserInputString[i] - '0';
            }

            return sumOfNumbers / (double)i_ValidUserInputString.Length;
        }

        private static int checkNumOfUpperCaseLetters(string i_ValidUserInputString) {
            int returnNumOfUpperCaseLetters = 0;
            for (int i = 0; i < i_ValidUserInputString.Length; i++) {
                if (char.IsUpper(i_ValidUserInputString, i)) {
                    returnNumOfUpperCaseLetters++;
                }
            }

            return returnNumOfUpperCaseLetters;
        }

        private static void displayResults(bool  i_IsUserInputPalindrome, eUserInputType i_UserInputType, double i_DecimalAverage, int i_NumOfUpperCaseLetters) {

            string introMsg = string.Format(
@"
The Results are: 
===================
");
            Console.WriteLine(introMsg);

            Console.Write("1.The input string is ");
            if (!i_IsUserInputPalindrome) {
                Console.Write("not ");
            }
            Console.WriteLine("a palindrome");

            string typeStringMsg;
            if (i_UserInputType == eUserInputType.OnlyLetters) {
                typeStringMsg = string.Format(@"2.The String contains Letters Only
The number of upper case letters in the string is {0}", i_NumOfUpperCaseLetters);
            }
            else  {
                typeStringMsg = string.Format(@"2.The String contains Digits Only
The average of numbers in the string is: {0}", i_DecimalAverage);
            }

            Console.WriteLine(typeStringMsg);

            
        }

    }
}
