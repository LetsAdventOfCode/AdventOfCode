list = ['L1', 'L3', 'L5', 'L3', 'R1', 'L4', 'L5', 'R1', 'R3', 'L5', 'R1', 'L3', 'L2', 'L3', 'R2', 'R2', 'L3', 'L3', 'R1', 'L2', 'R1', 'L3', 'L2', 'R4', 'R2', 'L5', 'R4', 'L5', 'R4', 'L2', 'R3', 'L2', 'R4', 'R1', 'L5', 'L4', 'R1', 'L2', 'R3', 'R1', 'R2', 'L4', 'R1', 'L2', 'R3', 'L2', 'L3', 'R5', 'L192', 'R4', 'L5', 'R4', 'L1', 'R4', 'L4', 'R2', 'L5', 'R45', 'L2', 'L5', 'R4', 'R5', 'L3', 'R5', 'R77', 'R2', 'R5', 'L5', 'R1', 'R4', 'L4', 'L4', 'R2', 'L4', 'L1', 'R191', 'R1', 'L1', 'L2', 'L2', 'L4', 'L3', 'R1', 'L3', 'R1', 'R5', 'R3', 'L1', 'L4', 'L2', 'L3', 'L1', 'L1', 'R5', 'L4', 'R1', 'L3', 'R1', 'L2', 'R1', 'R4', 'R5', 'L4', 'L2', 'R4', 'R5', 'L1', 'L2', 'R3', 'L4', 'R2', 'R2', 'R3', 'L2', 'L3', 'L5', 'R3', 'R1', 'L4', 'L3', 'R4', 'R2', 'R2', 'R2', 'R1', 'L4', 'R4', 'R1', 'R2', 'R1', 'L2', 'L2', 'R4', 'L1', 'L2', 'R3', 'L3', 'L5', 'L4', 'R4', 'L3', 'L1', 'L5', 'L3', 'L5', 'R5', 'L5', 'L4', 'L2', 'R1', 'L2', 'L4', 'L2', 'L4', 'L1', 'R4', 'R4', 'R5', 'R1', 'L4', 'R2', 'L4', 'L2', 'L4', 'R2', 'L4', 'L1', 'L2', 'R1', 'R4', 'R3', 'R2', 'R2', 'R5', 'L1', 'L2']

defmodule AdventOfCode do
  def sum_list([[direction|len] | tail], x, y, heading, visited) do
  
	tstr = to_string len
	length = String.to_integer(tstr,10)
	
	heading = 
	case{[direction]} do
	{'L'} ->
		rem((heading + 3), 4)
	{'R'} ->
		rem((heading + 1), 4)
	end

	{retval, x, y, visited} = check_intersection(x,y,heading,length,visited)

	if(retval) do
		sum_list([], x, y, heading, visited)
	else
		sum_list(tail, x, y, heading, visited)
	end
  end

  def sum_list([], x, y, _heading, _visited) do
    abs(x) + abs(y)
  end
  
  def check_intersection(x, y, _heading, distance, visited) when distance == 0 do
		{false,x,y,visited}
  end

  def check_intersection(x, y, heading, distance, visited) do
		
	if is_in_visited_list(visited, x,y) do
		{true,x,y,visited}
	else
		visited = visited ++ [{x,y}]

		{x,y} = case{heading} do
		{0} ->
			{x + 1,y}
		{1} ->
			{x,y + 1}
		{2} ->
			{x - 1,y}
		{3} ->
			{x,y - 1}
		end

		distance = distance - 1	
		check_intersection(x, y, heading, distance, visited)
	end
  end
  
  def is_in_visited_list([{x,y}|tail], x1, y1) do
	  if(x == x1 && y == y1) do
		true
	  else
		is_in_visited_list(tail, x1, y1)
	  end
  end

  def is_in_visited_list([], _x1, _y1) do
	false
  end
  
end

IO.inspect AdventOfCode.sum_list(list, 0, 0, 0, [])

