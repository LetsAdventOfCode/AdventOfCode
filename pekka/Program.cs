using System;

namespace ConsoleApplication
{
  public struct Position  
  {  
    public int x, y, x_dir, y_dir, x_max, y_max, x_min, y_min;
    public char[,] grid;
    public int x_offset, y_offset;
    public Position(int x, int y, int x_dir, int y_dir) 
    {
      this.x = x;
      this.y = y;
      this.x_dir = x_dir;
      this.y_dir = y_dir;
      this.x_max = x;
      this.y_max = y;
      this.x_min = x;
      this.y_min = y;
      this.grid = null;
      this.x_offset = 0;
      this.y_offset = 0;
    }

    public void setGrid(int x, int y) 
    {
      Console.WriteLine("setGrid " + x + " : " + y);
      grid = new char[x+1,y+1];
      for (int i = 0; i <= x; i++) {
        for (int j = 0; j <= y; j++) {
          grid[i,j] = ' ';
        }
      }
    }
    public void markInstruction(string instruction) 
    {
      this.followInstruction(instruction, true);
    }
    public void followInstruction(string instruction, bool mark = false) 
    {
      // Turn
      if(instruction[0] == 'L') {
        int tmp = this.x_dir;
        this.x_dir = -this.y_dir;
        this.y_dir = tmp;
      } else {
        int tmp = this.y_dir;
        this.y_dir = -this.x_dir;
        this.x_dir = tmp;
      }
      int distance = Int32.Parse(instruction.Substring(1));
      if(mark) {
        for (int i = 0; i < distance; i++) {
          this.x += this.x_dir;
          this.y += this.y_dir;
          if(this.grid[this.x,this.y] == ' ') {
            this.grid[this.x,this.y] = 'X';
          } else {
            Console.WriteLine("FOUND" + this.distanceFromStart());
          }
        }
      } else {
        this.x = this.x + (this.x_dir*distance);
        this.y = this.y + (this.y_dir*distance);
      }

      if(this.x < this.x_min) this.x_min = this.x;
      if(this.y < this.y_min) this.y_min = this.y;
      if(this.x > this.x_max) this.x_max = this.x;
      if(this.y > this.y_max) this.y_max = this.y;
      
/*    Console.WriteLine("Move " + instruction);
      Console.WriteLine("Position " + this.x + " : " + this.y);

      Console.WriteLine("Max " + this.x_max + " : " + this.y_max);
      Console.WriteLine("Min " + this.x_min + " : " + this.y_min);
  */    
    }
    public int abs(int i) {
      if(i < 0) {
        return -i;
      } else {
        return i;
      }
    }

    public int distanceFromStart() {
      return this.abs(this.x+this.x_offset) + this.abs(this.y+this.y_offset);
    } 

  } 

  public class Program
  {
    public static Position dayOnePart1(string[] instructions, Position position) {
      foreach (var instruction in instructions)
      {
        string trimmed_instruction = instruction.Trim();
        position.followInstruction(trimmed_instruction);
      }
      
      Console.WriteLine("dayOnePart1 " + position.distanceFromStart());
      return position;
    }

    public static void dayOnePart2(string[] instructions, Position position, Position old_position) {
      position.setGrid(old_position.x_max - old_position.x_min, old_position.y_max - old_position.y_min);
      position.x_offset = old_position.x_min;
      position.y_offset = old_position.y_min;
      position.x = -old_position.x_min;
      position.y = -old_position.y_min;

      foreach (var instruction in instructions)
      {
        string trimmed_instruction = instruction.Trim();
        position.markInstruction(trimmed_instruction);
      }
      Console.WriteLine("dayOnePart2 " + position.distanceFromStart());
    }

    public static void Main(string[] args)
    {

      string input = "R4, R4, L1, R3, L5, R2, R5, R1, L4, R3, L5, R2, L3, L4, L3, R1, R5, R1, L3, L1, R3, L1, R2, R2, L2, R5, L3, L4, R4, R4, R2, L4, L1, R5, L1, L4, R4, L1, R1, L2, R5, L2, L3, R2, R1, L194, R2, L4, R49, R1, R3, L5, L4, L1, R4, R2, R1, L5, R3, L5, L4, R4, R4, L2, L3, R78, L5, R4, R191, R4, R3, R1, L2, R1, R3, L1, R3, R4, R2, L2, R1, R4, L5, R2, L2, L4, L2, R1, R2, L3, R5, R2, L3, L3, R3, L1, L1, R5, L4, L4, L2, R5, R1, R4, L3, L5, L4, R5, L4, R5, R4, L3, L2, L5, R4, R3, L3, R1, L5, R5, R1, L3, R2, L5, R5, L3, R1, R4, L5, R4, R2, R3, L4, L5, R3, R4, L5, L5, R4, L4, L4, R1, R5, R3, L1, L4, L3, L4, R1, L5, L1, R2, R2, R4, R4, L5, R4, R1, L1, L1, L3, L5, L2, R4, L3, L5, L4, L1, R3";

      string[] instructions = input.Split(',');

      Position position = new Position(0,0,0,1);
      position = dayOnePart1(instructions, position);

      Position position2 = new Position(0,0,0,1);
      dayOnePart2(instructions, position2, position);
    }
  }
}
