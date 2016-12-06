using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] movement = new string[] { "R5", "L2", "L1", "R1", "R3", "R3", "L3", "R3", "R4", "L2", "R4", "L4", "R4", "R3", "L2", "L1", "L1", "R2", "R4", "R4", "L4", "R3", "L2", "R1", "L4", "R1", "R3", "L5", "L4", "L5", "R3", "L3", "L1", "L1", "R4", "R2", "R2", "L1", "L4", "R191", "R5", "L2", "R46", "R3", "L1", "R74", "L2", "R2", "R187", "R3", "R4", "R1", "L4", "L4", "L2", "R4", "L5", "R4", "R3", "L2", "L1", "R3", "R3", "R3", "R1", "R1", "L4", "R4", "R1", "R5", "R2", "R1", "R3", "L4", "L2", "L2", "R1", "L3", "R1", "R3", "L5", "L3", "R5", "R3", "R4", "L1", "R3", "R2", "R1", "R2", "L4", "L1", "L1", "R3", "L3", "R4", "L2", "L4", "L5", "L5", "L4", "R2", "R5", "L4", "R4", "L2", "R3", "L4", "L3", "L5", "R5", "L4", "L2", "R3", "R5", "R5", "L1", "L4", "R3", "L1", "R2", "L5", "L1", "R4", "L1", "R5", "R1", "L4", "L4", "L4", "R4", "R3", "L5", "R1", "L3", "R4", "R3", "L2", "L1", "R1", "R2", "R2", "R2", "L1", "L1", "L2", "L5", "L3", "L1" };

            Location position = new Location(0,0);
            string currentDirection = "north"; // "north", "south", "east", "west"

            // manage storage of the different locations visited
            List<Location> visitedLocations = new List<Location>();
            Location location = new Location(0, 0);
            visitedLocations.Add(location);
            bool hasBeenVisitedTwice = false;
            
            
            foreach (var step in movement)
            {
                int distance = Int32.Parse(step.Substring(1));
                switch (step.Substring(0, 1))
                {
                    case "R":
                        currentDirection = ChangeDirection(currentDirection, "R");         
                        break;
                    case "L":
                        currentDirection = ChangeDirection(currentDirection, "L");
                        break;
                    default:
                        Console.WriteLine("Misstep");
                        break;
                }
                position = MoveInDirection(distance, currentDirection, position);
                
                if (!hasBeenVisitedTwice)
                {
                    hasBeenVisitedTwice = UniqueLocation(position, visitedLocations);
                    if (hasBeenVisitedTwice)
                    {
                        Console.WriteLine("Location visited twice = " + position.x + "," + position.y);
                    }
                    else
                    {
                        visitedLocations.Add(position);
                    }
                }

            }

            int[] coordinates = new int[] { position.x, position.y };
            int totaltDistance = AddAbsoluteVales(coordinates);
            Console.WriteLine("Distance away = " + totaltDistance);
            Console.ReadKey();
        }

        // 2-dimensional location
        public class Location
        {
            public Location(int newX, int newY)
            {
                this.x = newX;
                this.y = newY;
            }
            public int x { set; get; }
            public int y { set; get; }
        }

        public static bool UniqueLocation(Location currentPosition, List<Location> visitedLocations)
        {
            foreach (var coordinate in visitedLocations)
            {
                if (coordinate.x == currentPosition.x && coordinate.y == currentPosition.y)
                {
                    return true;
                }
            }
            return false;
        }

        // calculates the absolute sum of values from an array of integers.
        public static int AddAbsoluteVales(int[] values)
        {
            var totalValue = 0;
            foreach (var value in values)
            {
                try
                {
                    totalValue = totalValue + Math.Abs(value);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Unable to calculate the absolute value of {0}.", value);
                }
            }

            return totalValue;
        }
            
        public static Location MoveInDirection(int distance, string currentDirection, Location currentPosition)
        {
            // add steps to that direction
            Location newPosition = new Location(currentPosition.x, currentPosition.y);
            switch (currentDirection)
            {
                case "north":
                    newPosition.x = currentPosition.x + distance;
                    break;
                case "south":
                    newPosition.x = currentPosition.x - distance;
                    break;
                case "east":
                    newPosition.y = currentPosition.y + distance;
                    break;
                case "west":
                    newPosition.y = currentPosition.y - distance;
                    break;
                default:
                    break;
            }
            return newPosition;
        }
         
        public static string ChangeDirection(string currentDirection, string turn)
        {
            
            switch (currentDirection) {
                case "north":
                    return turn == "L" ? "west" : "east";
                case "south":
                    return turn == "L" ? "east" : "west";
                case "east":
                    return turn == "L" ? "north" : "south";
                case "west":
                    return turn == "L" ? "south" : "north";
                default:
                    break;
            }
            Console.WriteLine("No new direction");
            return currentDirection;
        }

    }
}

