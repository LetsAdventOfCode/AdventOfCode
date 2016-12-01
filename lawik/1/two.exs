defmodule One do
    def go(current_position, current_heading, turn, blocks, passed_positions) do
        current_heading = turn(current_heading, turn)
        {current_position, passed_positions} = steps(current_position, current_heading, blocks, passed_positions)
        {current_position, current_heading, passed_positions}
    end

    def steps(current_position, current_heading, blocks, passed_positions) do
        step(current_position, current_heading, blocks, passed_positions)
    end

    def step(current_position, current_heading, blocks, passed_positions) when blocks > 0 do
        current_position = case {current_heading} do
            {0} ->
                [Enum.at(current_position, 0)+1, Enum.at(current_position, 1)]
            {1} ->
                [Enum.at(current_position, 0), Enum.at(current_position, 1)+1]
            {2} ->
                [Enum.at(current_position, 0)-1, Enum.at(current_position, 1)]
            {3} ->
                [Enum.at(current_position, 0), Enum.at(current_position, 1)-1]
        end

        if is_revisit(current_position, passed_positions) do
            IO.puts("Found revisit:")
            IO.inspect(current_position)
        end

        passed_positions = passed_positions ++ [current_position]
        step(current_position, current_heading, blocks-1, passed_positions)
    end

    def step(current_position, _current_heading, 0, passed_positions) do
        {current_position, passed_positions}
    end

    def is_revisit(position, [head | tail]) do
        if Enum.at(position, 0) == Enum.at(head, 0) and Enum.at(position, 1) == Enum.at(head, 1) do
            true
        else
            is_revisit(position, tail)
        end
    end

    def is_revisit(_position, []) do
        false
    end

    def turn(current_heading, :left) do
        current_heading = current_heading - 1
        if current_heading < 0 do
            3
        else
            current_heading
        end
    end

    def turn(current_heading, :right) do
        current_heading = current_heading + 1
        if current_heading > 3 do
            0
        else
            current_heading
        end
    end

    def interpret([head | tail], current_position, current_heading, passed_positions) do
        # IO.puts("===============================")
        # IO.inspect(head)
        [turn_string | blocks_string] = String.codepoints(head)
        turn = case {turn_string} do
            {"R"} -> :right
            {"L"} -> :left
        end

        blocks = String.to_integer(Enum.join(blocks_string))

        # IO.inspect(turn)
        # IO.inspect(blocks)
        {current_position, current_heading, passed_positions} = go(current_position, current_heading, turn, blocks, passed_positions)
        interpret(tail, current_position, current_heading, passed_positions)
    end

    def interpret([], current_position, _current_heading, _passed_positions) do
        current_position
    end
end

{:ok, input} = File.read("input.txt")
input = String.trim(input)
inputs = String.split(input, ", ")

starting_point = [0,0]
current_position = [0,0]
current_heading = 0
passed_positions = [starting_point]

end_position = One.interpret(inputs, current_position, current_heading, passed_positions)
IO.inspect(end_position)
x_away = 0+Enum.at(end_position, 0)
y_away = 0+Enum.at(end_position, 1)

IO.puts("x away:")
IO.inspect(x_away)
IO.puts("y away:")
IO.inspect(y_away)
