using System;

namespace ConsoleApplication
{
    public class Letter
    {
        public int letter;
        public int occurances;
        public Letter(int letter)
        {
            this.letter = letter;
            this.occurances = 0;
        }

        public static bool operator < (Letter l1, Letter l2) 
        {
            return (l1.occurances < l2.occurances) || (l1.occurances == l2.occurances && l1.letter > l2.letter);
        }

        public static bool operator > (Letter l1, Letter l2) 
        {
            return (l1.occurances > l2.occurances) || (l1.occurances == l2.occurances && l1.letter < l2.letter);
        }

        public static bool operator == (Letter l1, Letter l2) 
        {
            return (l1.occurances == l2.occurances) && (l1.letter == l2.letter);
        }

        public static bool operator != (Letter l1, Letter l2) 
        {
            return (l1.occurances != l2.occurances) || (l1.letter != l2.letter);
        }

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Input input = new Input();


            string[] signals = input.input2.Split('/');
            Letter[][] word = new Letter[signals[0].Length][];
            for(int j = 0; j<signals[0].Length; j++)
            {
                word[j] = new Letter[26];
                for (int i = 0; i < word[j].Length; i++)
                {
                     word[j][i] = new Letter(i);
                }
            }

            for (int i = 0; i < signals.Length; i++)
            {
                for(int j = 0; j<signals[0].Length; j++)
                {
                    int index = char.ToUpper(signals[i][j]) - 65;
                    word[j][index].occurances++;
                }
            }

            for(int j = 0; j<signals[0].Length; j++)
            {
                Array.Sort<Letter>( word[j],delegate(Letter l1, Letter l2)
                {
                    if(l1 > l2) {
                        return -1;
                    } else if(l1 < l2) {
                        return 1;
                    }
                    return 0;
                });
                Console.WriteLine("Letters");
                for(int k = 0; k<word[j].Length; k++) {
                    if(word[j][k].occurances>0) {
                        Console.WriteLine(":" + (char) (word[j][k].letter+65) );
                    }
                }
            }
        }
    }
}
