using System;
using System.Text;
using System.Security.Cryptography;

namespace ConsoleApplication
{
    public class Program
    {
        public static void step1() {
            int digitsFound = 0;
            MD5 md5Hash = MD5.Create();
            int i = 0;
            string password = "";
            while(digitsFound<8) {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes("cxdnnyjw"+i));
                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int j = 0; j < data.Length; j++)
                {
                    sBuilder.Append(data[j].ToString("x2"));
                }

                // Return the hexadecimal string.
                string hash = sBuilder.ToString();
                if(hash.IndexOf("00000") == 0) 
                {
                    Console.WriteLine("Found "+ hash);
                    digitsFound++;
                    password = password+hash[5];
                }
                i++;
            }
            Console.WriteLine("Password "+ password);
        }

        public static void step2() {
            int digitsFound = 0;
            MD5 md5Hash = MD5.Create();
            int i = 0;
            char[] password = new char[8];
            bool[] found = new bool[8];
            for (int j = 0; j < password.Length; j++)
            {
                password[j] = ' ';
                found[j] = false;
            }

            while(digitsFound<8) {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes("cxdnnyjw"+i));
                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int j = 0; j < data.Length; j++)
                {
                    sBuilder.Append(data[j].ToString("x2"));
                }

                // Return the hexadecimal string.
                string hash = sBuilder.ToString();
                if(hash.IndexOf("00000") == 0) 
                {
                    if(hash[5] >= '0' && hash[5]<'8' && !found[hash[5]-48])
                    {
                        Console.WriteLine("Found "+ hash);
                        digitsFound++;
                        password[hash[5]-48] = hash[6];
                        found[hash[5]-48] = true;
                        Console.WriteLine("Password "+ new string(password));
                    }
                }
                i++;
            }
            string word = new string(password);
            Console.WriteLine("Password "+ word);
        }
        
        public static void Main(string[] args)
        {
            step2();
        }
    }
}
