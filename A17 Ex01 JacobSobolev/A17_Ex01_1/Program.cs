using System;
using System.Text;

namespace A17_Ex01_1 {

    class Program {

        public static void Main() {
            binarySeries();
        }

        private static void binarySeries() {
            int numOfUserInputs = 3;
            int digitLength = 3;
            string[] validUserInputStrArray = new string[numOfUserInputs];
            string[] convertedInputsToBinaryStrArray = new string[numOfUserInputs];
            double AverageBitsNumber;
            int mumOfAscendingDigitSeries;
            int numOfDescendingDigitSeries;
            double averageOfDecimalNumbers;

            getInputFromUserAndValidate(validUserInputStrArray, digitLength, numOfUserInputs);
            convertUserInputToBinary(validUserInputStrArray, convertedInputsToBinaryStrArray);
            AverageBitsNumber = calculateAverageBitsNumber(convertedInputsToBinaryStrArray);
            checkAscendingAndDescendingDigitSSeries(validUserInputStrArray, out mumOfAscendingDigitSeries, out numOfDescendingDigitSeries);
            averageOfDecimalNumbers = calculateAverageOfDecimalNumbers(validUserInputStrArray);

            displayResults(validUserInputStrArray, convertedInputsToBinaryStrArray, AverageBitsNumber, mumOfAscendingDigitSeries, numOfDescendingDigitSeries, averageOfDecimalNumbers);
        }


        private static void getInputFromUserAndValidate(string[] i_ValidUserInputStr, int i_DigitLength, int i_NumOfUserInputs) {
            string userInputToValidate;
            bool userInputValid = false;

            string introMsg = string.Format(
@"Hi there! 
Please enter {0} positive numbers containing {1} digits no more no less:",i_NumOfUserInputs, i_DigitLength);

            Console.WriteLine(introMsg);

            for (int i = 0; i < i_NumOfUserInputs; ) {
                userInputToValidate = Console.ReadLine();
                userInputValid = validateUserInput(userInputToValidate, i_DigitLength);

                if (userInputValid) {
                    i_ValidUserInputStr[i] = userInputToValidate;
                    i++;
                }
                else {
                    Console.WriteLine("The input is invalid. Read the instructions again and try again");
                }

            }
        }

        private static bool validateUserInput(string i_StrToValidate, int i_DigitLength) {
            bool returnIsInputValid = false;
            bool successfulNumParse = false;
            int validNumber = 0;
            if ( i_StrToValidate.Length == i_DigitLength) {
                successfulNumParse = int.TryParse(i_StrToValidate, out validNumber);
                if (successfulNumParse && validNumber > 0) {
                    returnIsInputValid = true;
                }

            }

            return returnIsInputValid;
        }

        private static void convertUserInputToBinary(string[] i_ValidUserInputStrArray, string[] i_ConvertedInputsToBinaryStrArray) {
            int convertedInputToNum;
            StringBuilder binaryStrBuilder = new StringBuilder();
            for (int i = 0; i < i_ConvertedInputsToBinaryStrArray.Length; i++) {
                convertedInputToNum = int.Parse(i_ValidUserInputStrArray[i]);
                
                while (convertedInputToNum > 0) {
                    if (convertedInputToNum % 2 == 0) {
                        binaryStrBuilder.Insert(0, "0");
                    }
                    else {
                        binaryStrBuilder.Insert(0, "1");
                    }

                    convertedInputToNum /= 2;
                }
                i_ConvertedInputsToBinaryStrArray[i] = binaryStrBuilder.ToString();
                binaryStrBuilder.Remove(0, binaryStrBuilder.Length);
                
            }
        }

        private static double calculateAverageBitsNumber(string[] i_ConvertedInputsToBinaryStrArray) {
            int sumOfBits = 0;

            for (int i = 0; i < i_ConvertedInputsToBinaryStrArray.Length; i++) {
                sumOfBits += i_ConvertedInputsToBinaryStrArray[i].Length;
            }

            return sumOfBits / (double)i_ConvertedInputsToBinaryStrArray.Length;
        }

        private static void checkAscendingAndDescendingDigitSSeries(string[] i_ValidUserInputStrArray, out int o_NumOfAscendingDigitSeries, out int o_NumOfDescendingDigitSeries) {
            bool equalDigits = false;
            int numOfAscendingDigits = 0;
            int numOfDescendingDigits = 0;

            o_NumOfAscendingDigitSeries = 0;
            o_NumOfDescendingDigitSeries = 0;
            
            for (int i = 0; i < i_ValidUserInputStrArray.Length ; i++) {
                for (int j = 0; j < i_ValidUserInputStrArray[i].Length - 1 && !equalDigits ; j++) {
                    if ((i_ValidUserInputStrArray[i][j] - '0') < (i_ValidUserInputStrArray[i][j + 1] - '0')) {
                        numOfAscendingDigits++;
                    }
                    else if ((i_ValidUserInputStrArray[i][j] - '0') > (i_ValidUserInputStrArray[i][j + 1] - '0')) {
                        numOfDescendingDigits++;
                    }
                    else {
                        equalDigits = true;
                    }
                }

                if (numOfAscendingDigits == i_ValidUserInputStrArray[i].Length - 1) {
                    o_NumOfAscendingDigitSeries++;
                }
                else if (numOfDescendingDigits == i_ValidUserInputStrArray[i].Length - 1) {
                    o_NumOfDescendingDigitSeries++;
                }

                numOfAscendingDigits = 0;
                numOfDescendingDigits = 0;
                equalDigits = false;
            }


        }

        private static double calculateAverageOfDecimalNumbers(string[] i_ValidUserInputStrArray) {
            int sumOfNumbers = 0;
            for (int i = 0; i < i_ValidUserInputStrArray.Length; i++) {
                sumOfNumbers += int.Parse(i_ValidUserInputStrArray[i]);
            }
            return (double)sumOfNumbers / i_ValidUserInputStrArray.Length;
        }

        private static void displayResults(string[] i_ValidUserInputStrArray, string[] i_ConvertedInputsToBinaryStrArray, double i_AverageBitsNumber, int i_NumOfAscendingDigitSeries, int i_NumOfDescendingDigitSeries, double i_AverageOfDecimalNumbers) {
            string introMsg = string.Format(
@"The Results are: 
===================

1.The Binary representation of the input is: ");
            Console.WriteLine(introMsg);

            for (int i = 0; i < i_ValidUserInputStrArray.Length; i++) {
                Console.WriteLine("{0} = {1} ", i_ValidUserInputStrArray[i], i_ConvertedInputsToBinaryStrArray[i]);
            }

            string resultMsg = string.Format(
@"2.The average number of bits in the binary representation is {0} 
3.The amount of numbers that have ascending digits series is {1}
4.The amount of numbers that have descending digit series is {2}
5.The average of the decimal representation is {3}", i_AverageBitsNumber, i_NumOfAscendingDigitSeries, i_NumOfDescendingDigitSeries, i_AverageOfDecimalNumbers);

            Console.WriteLine(resultMsg);
        }
    }
}
