using System;

namespace ConsoleApplication
{
    public class Program
    {
        char[,] pad;
        int x,y;
        public void quiz2(string[] inputs) 
        {
            this.pad = new char[5,5] {
                {' ',' ','1',' ',' '},
                {' ','2','3','4',' '},
                {'5','6','7','8','9'},
                {' ','A','B','C',' '},
                {' ',' ','D',' ',' '}
            };
            this.x = 0;
            this.y = 2;
            Console.WriteLine("Start " + this.pad[this.y,this.x]);

            foreach (var input in inputs) 
            {
                foreach (var m in input) 
                {
                    if(m == 'L') 
                    {
                        move(-1,0);
                    } else if(m == 'R') 
                    {
                        move(1,0);
                    } else if(m == 'U') 
                    {
                        move(0,-1);
                    } else
                    {
                        move(0,1);
                    }
                }
                Console.WriteLine("Key " + this.pad[this.y,this.x]);
            }
        }
        public void move(int x, int y) 
        {
            if( this.x+x >= 0 && this.x+x < 5 &&
                this.y+y >= 0 && this.y+y < 5 ) 
            {
                if(this.pad[this.y+y,this.x+x] != ' ') {
                    this.y+=y;
                    this.x+=x;
                }
            }
        }
        public static void quiz1(string[] inputs) 
        {
            bool up=false,down=false,left=false,right=false;

            foreach (var input in inputs) 
            {
                foreach (var m in input) 
                {
                    if(m == 'L') 
                    {
                        move(ref left, ref right);
                    } else if(m == 'R') 
                    {
                        move(ref right, ref left);
                    } else if(m == 'U') 
                    {
                        move(ref up, ref down);
                    } else
                    {
                        move(ref down, ref up);
                    }
                }
                Console.WriteLine("Key");
                Console.WriteLine("Left " + left);
                Console.WriteLine("Right " + right);
                Console.WriteLine("Up " + up);
                Console.WriteLine("Down " + down);
            }
        }

        public static void move(ref bool same, ref bool opposite) 
        {
            same = same || !opposite;
            opposite = false;
        }
        
        public static void Main(string[] args)
        {
            string[] inputs = new string[5] {"LRULLRLDUUUDUDDDRLUDRDLDDLUUDLDDLRDRLDRLLURRULURLDRLDUDURLURRULLDDDUDDRRRDLRRDDLDURDULLRDLLLDRDLLDULDUDLLDLDRUDLLDLDDRRRDRLUDRDDLUDRRDUDUDLLDDUUDLRDUDRRUDUDRULRULUDRUUDLDLULLRLDLDDRULLRLLLULUULDURURLUUULDURLDDDURRUUDURDDDULDLURLRDRURDRUDRLLDLDRUURLLLRDRURUDLRLUDULLDDURLRURDLRDUUURRLULRRLDDULUUURLRRRLLLLLURDDRUULUDRRRUDDLLULRRUULDRDDULRLDDDRRUULUDRLRUDURUUULDLDULUUDURLLLRRDDRDLURDDDLDDDLRDRLDDURLRLLRUDRRLLDDDDDURDURRDDULDULLRULDRUURDRRDUDDUDDDDRRDULDUURDRUDRLDULRULURLLRRDRDRDLUUDRRLRLDULDDLUUUUUURRLRRRULLDDDRLRDRRRRRRRDUUDLLUDURUDDLURRUDL"
            , "UDUUURRLRLLDDRRDRRRLDDDLURURLLUDDRLUUDRRRDURRLLRURDLLRRDUUDDDDRDRURRLLLLURDLRRRULLLDLLLUDDLDRRRDLDUUDDRDUDDUURDDLULULDURDURDRUULURURRURDUURUDRRUDRLLLLRRDLLDRDDRLLURDDDUDUDUDRUURDDRUURDLRUUDDRDUURUDDLLUURDLUDRUUDRRDLLUUURDULUULDUUDLLULUUDLUDRUUDUUURLDDDRLRURDDULLRDRULULUDLUUDDDUUDLDUUDRULLDUURDDRUDURULDRDDLRUULRRRDLDLRDULRDDRLLRRLURDLDRUDLRLUDLRLDLDURRUULRLUURDULDRRULLRULRDLLDLDUDRUDDUDLDDURDDDRDLUDRULRUULLRURLDDDRDLRRDRULURULDULRDLDULDURDRDRDRDURDRLUURLRDDLDDRLDDRURLLLURURDULDUDDLLUURDUUUDRUDDRDLDRLRLDURRULDULUUDDLRULDLRRRRDLLDRUUDRLLDLUDUULRDRDLRUUDLRRDDLUULDUULRUDRURLDDDURLRRULURR"
            , "LDURLLLRLLLUURLLULDLRLLDLURULRULRDUDLDDUDRLRRDLULLDDULUUULDRLDURURLURLDLRUDULLLULDUURLLRDLUULRULLLULRDRULUDLUUULDDURLUDDUDDRDLDRDRUDLUURDDLULDUULURLUULRDRDLURUDRUDLDRLUUUUULUDUDRRURUDRULDLDRDRLRURUUDRDLULLUDLLRUUDUUDUDLLRRRLDUDDDRDUDLDLLULRDURULLLUDLLRUDDUUDRLDUULLDLUUDUULURURLLULDUULLDLUDUURLURDLUULRRLLRUDRDLLLRRRLDDLUULUURLLDRDLUUULLDUDLLLLURDULLRUDUUULLDLRLDRLLULDUDUDRULLRRLULURUURLRLURRLRRRDDRLUDULURUDRRDLUDDRRDRUDRUDLDDRLRDRRLDDRLLDDDULDLRLDURRRRRULRULLUUULUUUDRRDRDRLLURRRRUULUDDUDDDLDURDRLDLLLLLRDUDLRDRUULU"
            , "URURRUUULLLLUURDULULLDLLULRUURRDRRLUULRDDRUDRRDUURDUDRUDDRUULURULDRLDRDDDLDLRLUDDRURULRLRLLLDLRRUDLLLLRLULDLUUDUUDRDLRRULLRDRLRLUUDDRRLLDDRULLLRLLURDLRRRRRLLDDRRDLDULDULLDLULLURURRLULRLRLLLLURDDRDDDUUDRRRDUUDDLRDLDRRLLRURUDUUUDLDUULLLRLURULRULRDRLLLDLDLRDRDLLLRUURDDUDDLULRULDLRULUURLLLRRLLLLLLRUURRLULRUUUDLDUDLLRRDDRUUUURRRDRRDULRDUUDULRRRDUUUUURRDUURRRRLDUDDRURULDDURDDRDLLLRDDURUDLLRURLRRRUDDLULULDUULURLUULRDLRDUDDRUULLLRURLDLRRLUDLULDRLUDDDRURUULLDLRLLLDULUDDRLRULURLRDRRDDLDLURUDDUUURRDDLUDDRDUULRRDLDRLLLULLRULRURULRLULULRDUD"
            , "RUDLLUDRRDRRLRURRULRLRDUDLRRLRDDUDRDLRRLLRURRDDLRLLRRURULRUULDUDUULDULDLRLRDLRDLRUURLDRLUDRRDDDRDRRRDDLLLRRLULLRRDDUDULRDRDUURLDLRULULUDLLDRUDUURRUDLLRDRLRRUUUDLDUDRRULLDURRDUDDLRURDLDRLULDDURRLULLRDDDRLURLULDLRUDLURDURRUDULDUUDLLLDDDUUURRRDLLDURRDLULRULULLRDURULLURDRLLRUUDDRRUDRDRRRURUUDLDDRLDRURULDDLLULULURDLDLDULLRLRDLLUUDDUDUDDDDRURLUDUDDDRRUDDLUDULLRDLDLURDDUURDLRLUUDRRULLRDLDDDLDULDUDRDUUULULDULUDLULRLRUULLDURLDULDRDLLDULLLULRLRD"};

            string[] inputs2 = new string[4] 
            {"ULL"
            ,"RRDDD"
            ,"LURDL"
            ,"UUUUD"};

            quiz1(inputs);

            Program p = new Program();
            p.quiz2(inputs);
        }
    }
}
