using System;

namespace ConsoleApplication {

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
        static Input input = new Input();
        static int id_sum = 0;
        public static char decipher(char c, int steps)
        {
            int index = char.ToUpper(c) - 65;
            index = index + steps;
            index = index%26;
            return (char) (index+65);
        }

        public static void Main(string[] args)
        {
            Letter[] letters = new Letter[26];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = new Letter(i);
            }

            string[] rooms = Program.input.codes.Split('/');

            for (int i = 0; i < rooms.Length; i++)
            {
                int id = 0;
                string[] dashes = rooms[i].Split('-');
                for (int j = 0; j < dashes.Length-1; j++)
                {
                    for (int k = 0; k < dashes[j].Length; k++)
                    {
                        int index = char.ToUpper(dashes[j][k]) - 65;
                        letters[index].occurances++;
                    }
                }

                Array.Sort<Letter>( letters,delegate(Letter l1, Letter l2)
                {
                    if(l1 > l2) {
                        return -1;
                    } else if(l1 < l2) {
                        return 1;
                    }
                    return 0;
                });
                /*
                for (int j = 0; j < letters.Length; j++)
                {
                    char char_letter = (char) (letters[j].letter+65);
                    Console.WriteLine(letters[j].occurances + " " + char_letter);
                } 
                */               
                string[] last = dashes[dashes.Length-1].Split('[');
                string checksum = "";
                checksum += (char) (letters[0].letter+65);
                checksum += (char) (letters[1].letter+65);
                checksum += (char) (letters[2].letter+65);
                checksum += (char) (letters[3].letter+65);
                checksum += (char) (letters[4].letter+65);

                if(last[1].Substring(0,5) == checksum.ToLower()) {
                    //Console.WriteLine("Room: "+ rooms[i]);
                    string clear = "";
                    var room_id = Int32.Parse(last[0]);
                    for (int j = 0; j < dashes.Length-1; j++)
                    {
                        for (int k = 0; k < dashes[j].Length; k++)
                        {
                            clear = clear+decipher(dashes[j][k], room_id);
                        }
                        clear = clear+" ";
                    }
                    if(clear.IndexOf("MILITARY GRADE RAMPAGING BUNNY OPERATIONS") >= 0) {
                        Console.WriteLine("clear: "+ clear);
                        Console.WriteLine("ID: "+ room_id);
                    }
                    id = room_id;
                }
                id_sum = id_sum + id;

                letters = new Letter[26];
                for (int j = 0; j < letters.Length; j++)
                {
                    letters[j] = new Letter(j);
                }
            }

            Console.WriteLine("Hello World!"+ id_sum);
        }
    }
}
