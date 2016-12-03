using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Triangle
    {
        int side_index = 0;
        int big_side = 0;
        List<int> sides = new List<int>();
        public void Side(int lenght)
        {
            if(this.side_index == 0) {
                this.big_side = lenght;
            } else  {
                var tmp =  lenght;
                if(this.big_side < lenght) {
                    tmp = this.big_side;
                    this.big_side = lenght;
                }
                this.sides.Add(tmp);
            }
            this.side_index++;
            if (this.side_index == 3) {
                if(this.sides[0]+this.sides[1] > this.big_side) {
                    Program.katching();
                }
                this.side_index = 0;
                this.big_side = 0;
                this.sides.Clear();
            } 
        }
    }

    public class Program
    {
        static int possible = 0;
        public static void katching()
        {
            possible++;
        }
        Input input = new Input();
        public static void Main(string[] args)
        {
            Program p = new Program();
            string[] instructions = p.input.triangles.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            var triangle_index = 0;
            var triangle_max = 3;
            var side_index = 0;
            Triangle[] batch = new Triangle[triangle_max];
            for(var i = 0; i<instructions.Length; i++) {
                int instruction = Int32.Parse(instructions[i]);
                if(side_index == 0 && triangle_index==0)
                {
                    for(int j=0; j<triangle_max; j++)
                    {
                        batch[j] = new Triangle();
                    }
                }
                batch[triangle_index].Side(instruction);
                triangle_index++;
                if(triangle_index == triangle_max) 
                {
                    triangle_index = 0;
                    side_index++;
                }
                if(side_index == 3) 
                {
                    side_index=0;
                }
            }

            Console.WriteLine("Hello World!" + possible);
        }
    }
}
