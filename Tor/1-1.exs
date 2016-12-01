list = ['L1', 'L3', 'L5', 'L3', 'R1', 'L4', 'L5', 'R1', 'R3', 'L5', 'R1', 'L3', 'L2', 'L3', 'R2', 'R2', 'L3', 'L3', 'R1', 'L2', 'R1', 'L3', 'L2', 'R4', 'R2', 'L5', 'R4', 'L5', 'R4', 'L2', 'R3', 'L2', 'R4', 'R1', 'L5', 'L4', 'R1', 'L2', 'R3', 'R1', 'R2', 'L4', 'R1', 'L2', 'R3', 'L2', 'L3', 'R5', 'L192', 'R4', 'L5', 'R4', 'L1', 'R4', 'L4', 'R2', 'L5', 'R45', 'L2', 'L5', 'R4', 'R5', 'L3', 'R5', 'R77', 'R2', 'R5', 'L5', 'R1', 'R4', 'L4', 'L4', 'R2', 'L4', 'L1', 'R191', 'R1', 'L1', 'L2', 'L2', 'L4', 'L3', 'R1', 'L3', 'R1', 'R5', 'R3', 'L1', 'L4', 'L2', 'L3', 'L1', 'L1', 'R5', 'L4', 'R1', 'L3', 'R1', 'L2', 'R1', 'R4', 'R5', 'L4', 'L2', 'R4', 'R5', 'L1', 'L2', 'R3', 'L4', 'R2', 'R2', 'R3', 'L2', 'L3', 'L5', 'R3', 'R1', 'L4', 'L3', 'R4', 'R2', 'R2', 'R2', 'R1', 'L4', 'R4', 'R1', 'R2', 'R1', 'L2', 'L2', 'R4', 'L1', 'L2', 'R3', 'L3', 'L5', 'L4', 'R4', 'L3', 'L1', 'L5', 'L3', 'L5', 'R5', 'L5', 'L4', 'L2', 'R1', 'L2', 'L4', 'L2', 'L4', 'L1', 'R4', 'R4', 'R5', 'R1', 'L4', 'R2', 'L4', 'L2', 'L4', 'R2', 'L4', 'L1', 'L2', 'R1', 'R4', 'R3', 'R2', 'R2', 'R5', 'L1', 'L2']

defmodule AdventOfCode do
  def sum_list([[direction|len] | tail], x, y, heading) do

	tstr = to_string len
	length = String.to_integer( tstr, 10)
	
	heading = 
	case{direction} do
	{76} ->
		rem((heading + 3), 4)
	{82} ->
		rem((heading + 1), 4)
	end

	{x,y} = case{heading} do
	{0} ->
		{x + length,y}
	{1} ->
		{x,y + length}
	{2} ->
		{x - length,y}
	{3} ->
		{x,y - length}
	end
	
	
    sum_list(tail, x, y, heading)
  end

  def sum_list([], x, y, heading) do
    abs(x) + abs(y)
  end
end

IO.inspect AdventOfCode.sum_list(list, 0, 0, 0)

