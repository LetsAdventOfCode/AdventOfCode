using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December2
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up the password hint
            List<string> passwordHints = new List<string>();
            passwordHints.Add("DUURRDRRURUUUDLRUDDLLLURULRRLDULDRDUULULLUUUDRDUDDURRULDRDDDUDDURLDLLDDRRURRUUUDDRUDDLLDDDURLRDDDULRDUDDRDRLRDUULDLDRDLUDDDLRDRLDLUUUDLRDLRUUUDDLUURRLLLUUUUDDLDRRDRDRLDRLUUDUDLDRUDDUDLLUUURUUDLULRDRULURURDLDLLDLLDUDLDRDULLDUDDURRDDLLRLLLLDLDRLDDUULRDRURUDRRRDDDUULRULDDLRLLLLRLLLLRLURRRLRLRDLULRRLDRULDRRLRURDDLDDRLRDLDRLULLRRUDUURRULLLRLRLRRUDLRDDLLRRUDUDUURRRDRDLDRUDLDRDLUUULDLRLLDRULRULLRLRDRRLRLULLRURUULRLLRRRDRLULUDDUUULDULDUDDDUDLRLLRDRDLUDLRLRRDDDURUUUDULDLDDLDRDDDLURLDRLDURUDRURDDDDDDULLDLDLU");
            passwordHints.Add("LURLRUURDDLDDDLDDLULRLUUUDRDUUDDUDLDLDDLLUDURDRDRULULLRLDDUDRRDRUDLRLDDDURDUURLUURRLLDRURDRLDURUDLRLLDDLLRDRRLURLRRUULLLDRLULURULRRDLLLDLDLRDRRURUUUDUDRUULDLUDLURLRDRRLDRUDRUDURLDLDDRUULDURDUURLLUDRUUUUUURRLRULUDRDUDRLLDUDUDUULURUURURULLUUURDRLDDRLUURDLRULDRRRRLRULRDLURRUULURDRRLDLRUURUDRRRDRURRLDDURLUDLDRRLDRLLLLRDUDLULUDRLLLDULUDUULLULLRLURURURDRRDRUURDULRDDLRULLLLLLDLLURLRLLRDLLRLUDLRUDDRLLLDDUDRLDLRLDUDU");
            passwordHints.Add("RRDDLDLRRUULRDLLURLRURDLUURLLLUUDDULLDRURDUDRLRDRDDUUUULDLUDDLRDULDDRDDDDDLRRDDDRUULDLUDUDRRLUUDDRUDLUUDUDLUDURDURDLLLLDUUUUURUUURDURUUUUDDURULLDDLDLDLULUDRULULULLLDRLRRLLDLURULRDLULRLDRRLDDLULDDRDDRURLDLUULULRDRDRDRRLLLURLLDUUUDRRUUURDLLLRUUDDDULRDRRUUDDUUUDLRRURUDDLUDDDUDLRUDRRDLLLURRRURDRLLULDUULLURRULDLURRUURURRLRDULRLULUDUULRRULLLDDDDURLRRRDUDULLRRDURUURUUULUDLDULLUURDRDRRDURDLUDLULRULRLLURULDRUURRRRDUDULLLLLRRLRUDDUDLLURLRDDLLDLLLDDUDDDDRDURRL");
            passwordHints.Add("LLRURUDUULRURRUDURRDLUUUDDDDURUUDLLDLRULRUUDUURRLRRUDLLUDLDURURRDDLLRUDDUDLDUUDDLUUULUUURRURDDLUDDLULRRRUURLDLURDULULRULRLDUDLLLLDLLLLRLDLRLDLUULLDDLDRRRURDDRRDURUURLRLRDUDLLURRLDUULDRURDRRURDDDDUUUDDRDLLDDUDURDLUUDRLRDUDLLDDDDDRRDRDUULDDLLDLRUDULLRRLLDUDRRLRURRRRLRDUDDRRDDUUUDLULLRRRDDRUUUDUUURUULUDURUDLDRDRLDLRLLRLRDRDRULRURLDDULRURLRLDUURLDDLUDRLRUDDURLUDLLULDLDDULDUDDDUDRLRDRUUURDUULLDULUUULLLDLRULDULUDLRRURDLULUDUDLDDRDRUUULDLRURLRUURDLULUDLULLRD");
            passwordHints.Add("UURUDRRDDLRRRLULLDDDRRLDUDLRRULUUDULLDUDURRDLDRRRDLRDUUUDRDRRLLDULRLUDUUULRULULRUDURDRDDLDRULULULLDURULDRUDDDURLLDUDUUUULRUULURDDDUUUURDLDUUURUDDLDRDLLUDDDDULRDLRUDRLRUDDURDLDRLLLLRLULRDDUDLLDRURDDUDRRLRRDLDDUDRRLDLUURLRLLRRRDRLRLLLLLLURULUURRDDRRLRLRUURDLULRUUDRRRLRLRULLLLUDRULLRDDRDDLDLDRRRURLURDDURRLUDDULRRDULRURRRURLUURDDDUDLDUURRRLUDUULULURLRDDRULDLRLLUULRLLRLUUURUUDUURULRRRUULUULRULDDURLDRRULLRDURRDDDLLUDLDRRRRUULDDD");

            string passcode = "";
            char lastDigit = '5';

            List<Character> keyPadButtons = new List<Character>();
            string possibleEntries = "123456789ABCD";
            foreach (var possibleCharacter in possibleEntries)
            {
                Character thisEntry = new Character(possibleCharacter);
            }

            // for each line, run a function determining the button to press. Return button to press to user
            foreach (var hint in passwordHints)
            {

                // for each letter perform a move on the grid in that direction Up, Down, Left or Right
                foreach (var direction in hint)
                {
                    lastDigit = GetNextDigitForHardPasscode(direction, lastDigit);
                }
                // add the number to a string for final result
                passcode = passcode + lastDigit.ToString();
            }
            
            // print the final result
            Console.WriteLine("The password is: " + passcode);
            Console.ReadKey();
        }

        public class Character
        {
            public Character(char newChar)
            {
                this.character = newChar;
                this.mayMoveLeft = true;
                this.mayMoveRight = true;
                this.mayMoveUp = true;
                this.mayMoveDown = true;
                if (newChar == 'A')
                {
                    mayMoveLeft = false;
                    mayMoveDown = false;
                }
                if (newChar == 'C')
                {
                    mayMoveRight = false;
                    mayMoveDown = false;
                }
                if (newChar == 'D')
                {
                    mayMoveLeft = false;
                    mayMoveRight = false;
                    mayMoveDown = false;
                }
                if (newChar == '1')
                {
                    mayMoveLeft = false;
                    mayMoveRight = false;
                    mayMoveUp = false;
                }
                if (newChar == '2')
                {
                    mayMoveLeft = false;
                    mayMoveUp = false;
                }
                if (newChar == '4')
                {
                    mayMoveRight = false;
                    mayMoveUp = false;
                }
                if (newChar == '5')
                {
                    mayMoveLeft = false;
                    mayMoveUp = false;
                    mayMoveDown = false;
                }
                if (newChar == '9')
                {
                    mayMoveRight = false;
                    mayMoveUp = false;
                    mayMoveDown = false;
                }

            }
            public char character { get; set; }
            public bool mayMoveLeft { get; }
            public bool mayMoveRight { get; }
            public bool mayMoveUp { get; }
            public bool mayMoveDown { get; }
            public Coordinates coordinates { get; set; }

        }
        
        public class Coordinates
        {
            public Coordinates(int newX, int newY)
            {
                this.x = newX;
                this.y = newY;
            }
            public int x { get; set; }
            public int y { get; set; }
        }

        public static Coordinates CheckCooridnatesFromCharacter(char character)
        {
            Coordinates tempCoordinates = new Coordinates (0,0);

            switch (character)
            {
                case 'A':
                    tempCoordinates.x = 2;
                    tempCoordinates.y = 2;
                    break;
                case 'B':
                    tempCoordinates.x = 3;
                    tempCoordinates.y = 2;
                    break;
                case 'C':
                    tempCoordinates.x = 4;
                    tempCoordinates.y = 2;
                    break;
                case 'D':
                    tempCoordinates.x = 3;
                    tempCoordinates.y = 1;
                    break;
                case '1':
                    tempCoordinates.x = 3;
                    tempCoordinates.y = 5;
                    break;
                case '2':
                    tempCoordinates.x = 2;
                    tempCoordinates.y = 4;
                    break;
                case '3':
                    tempCoordinates.x = 3;
                    tempCoordinates.y = 4;
                    break;
                case '4':
                    tempCoordinates.x = 4;
                    tempCoordinates.y = 4;
                    break;
                case '5':
                    tempCoordinates.x = 1;
                    tempCoordinates.y = 3;
                    break;
                case '6':
                    tempCoordinates.x = 2;
                    tempCoordinates.y = 3;
                    break;
                case '7':
                    tempCoordinates.x = 3;
                    tempCoordinates.y = 3;
                    break;
                case '8':
                    tempCoordinates.x = 4;
                    tempCoordinates.y = 3;
                    break;
                case '9':
                    tempCoordinates.x = 5;
                    tempCoordinates.y = 3;
                    break;
                default:
                    break;
            }

            return tempCoordinates;
        }

        public static char CheckCharacterFromCoorindates(Coordinates coordinates)
        {
            if (coordinates.x == 1)
            {
                return '5';
            }
            if (coordinates.x == 2)
            {
                if (coordinates.y == 2)
                {
                    return 'A';
                }
                if (coordinates.y == 3)
                {
                    return '6';
                }
                if (coordinates.y == 4)
                {
                    return '2';
                }
            }
            if (coordinates.x == 3)
            {
                if (coordinates.y == 1)
                {
                    return 'D';
                }
                if (coordinates.y == 2)
                {
                    return 'B';
                }
                if (coordinates.y == 3)
                {
                    return '7';
                }
                if (coordinates.y == 4)
                {
                    return '3';
                }
                if (coordinates.y == 5)
                {
                    return '1';
                }
            }
            if (coordinates.x == 4)
            {
                if (coordinates.y == 2)
                {
                    return 'C';
                }
                if (coordinates.y == 3)
                {
                    return '8';
                }
                if (coordinates.y == 4)
                {
                    return '4';
                }
            }
            if (coordinates.x == 5)
            {
                return '9';
            }
            return ' ';
        }

        // based on a gridsystem when it moves "off" it does not move
        public static char GetNextDigitForHardPasscode(char direction, char character)
        {
            // set up - need to get the character class for the character in order to check if they are allowed to move in the direction
            Character tempCharacter = new Character(character);

            // need to get the coordinates for the character in order to traverse in the new direction
            Coordinates tempCoordinates = new Coordinates(0,0);
            tempCoordinates = CheckCooridnatesFromCharacter(character);
            
            // for each direction specified check if we are allowed to move in that direction
            // then update the coordinates and get the new character, returning that character
            switch (direction)
            {
                case 'U':
                    if (tempCharacter.mayMoveUp)
                    {
                        tempCoordinates.y = tempCoordinates.y + 1;
                        return CheckCharacterFromCoorindates(tempCoordinates);
                    }
                    break;
                case 'D':
                    if (tempCharacter.mayMoveDown)
                    {
                        tempCoordinates.y = tempCoordinates.y - 1;
                        return CheckCharacterFromCoorindates(tempCoordinates);
                    }
                    break;
                case 'L':
                    if (tempCharacter.mayMoveLeft)
                    {
                        tempCoordinates.x = tempCoordinates.x - 1;
                        return CheckCharacterFromCoorindates(tempCoordinates);
                    }
                    break;
                case 'R':
                    if (tempCharacter.mayMoveRight)
                    {
                        tempCoordinates.x = tempCoordinates.x + 1;
                        return CheckCharacterFromCoorindates(tempCoordinates);
                    }
                    break;

                default:
                    break;
            }
            return character;
        }

        // function that takes in a character of wither U, D, L or R. And an int with a number from 1 to 9 for the current location.
        public static int GetDigitFromPasscodeHint(char direction, int currentLocation)
        {

            // if the movement would take the location outside the 3x3-grid do nothing instead.
            switch (direction)
            {
                case 'U':
                    // ignore up for 1, 2 & 3
                    if (currentLocation == 1 || currentLocation == 2 || currentLocation == 3)
                    {
                        return currentLocation;
                    }
                    else
                    {
                        // if not ignored, up = decrement by 3
                        return currentLocation - 3;
                    }
                case 'D':
                    // Ignore down for 7, 8 & 9
                    if (currentLocation == 7 || currentLocation == 8 || currentLocation == 9)
                    {
                        return currentLocation;
                    }
                    else
                    {
                        // if not ignored, down = incement by 3
                        return currentLocation + 3;
                    }
                case 'L':
                    // Ignore left for 1, 4 & 7
                    if (currentLocation == 1 || currentLocation == 4 || currentLocation == 7)
                    {
                        return currentLocation;
                    }
                    else
                    {
                        // if not ignored, left = decrement by 1
                        return currentLocation - 1;
                    }
                case 'R':
                    // Ignore right for 3, 6, 9
                    if (currentLocation == 3 || currentLocation == 6 || currentLocation == 9)
                    {
                        return currentLocation;
                    }
                    else
                    {
                        // if not ignored, right = increment by 1
                        return currentLocation + 1;
                    }
                default:
                    return currentLocation;
            }
        }


    }
}
