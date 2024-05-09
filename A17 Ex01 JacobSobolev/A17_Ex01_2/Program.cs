using System;
using System.Text;

namespace A17_Ex01_2 {

    public class Program {

        public static void Main() {
            createNovieSandClock();
        }

        private static void createNovieSandClock() {
            int numOfLines = 5;
            string sandClockNoviceStr = CreateSandClockStr(numOfLines);
            Console.WriteLine(sandClockNoviceStr);
        }


        public static string CreateSandClockStr(int i_NumOfLines) {
            StringBuilder sandClockStrBuilder = new StringBuilder();

            if (i_NumOfLines % 2 == 0) {
                i_NumOfLines--;
            }

            for (int i = 0; i <= i_NumOfLines / 2; i++) {
                sandClockStrBuilder.Append(' ', i);
                sandClockStrBuilder.Append('*', i_NumOfLines - (2 * i));
                sandClockStrBuilder.Append(Environment.NewLine);
            }

            for (int i = (i_NumOfLines / 2) - 1; i >= 0; i--) {
                sandClockStrBuilder.Append(' ', i);
                sandClockStrBuilder.Append('*', i_NumOfLines - (2 * i));
                sandClockStrBuilder.Append(Environment.NewLine);
            }

            return sandClockStrBuilder.ToString();
        }
    }
}

