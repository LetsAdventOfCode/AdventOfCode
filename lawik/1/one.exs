defmodule One do
    def go(current_position, current_heading, turn, blocks) do
        current_heading = turn(current_heading, turn)
        current_position = steps(current_position, current_heading, blocks)
        {current_position, current_heading}
    end

    def steps(current_position, current_heading, blocks) do
        IO.inspect(current_position)
        case {current_heading} do
            {0} ->
                [Enum.at(current_position, 0)+blocks, Enum.at(current_position, 1)]
            {1} ->
                [Enum.at(current_position, 0), Enum.at(current_position, 1)+blocks]
            {2} ->
                [Enum.at(current_position, 0)-blocks, Enum.at(current_position, 1)]
            {3} ->
                [Enum.at(current_position, 0), Enum.at(current_position, 1)-blocks]
        end
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

    def interpret([head | tail], current_position, current_heading) do
        IO.puts("===============================")
        IO.inspect(head)
        [turn_string | blocks_string] = String.codepoints(head)
        turn = case {turn_string} do
            {"R"} -> :right
            {"L"} -> :left
        end

        blocks = String.to_integer(Enum.join(blocks_string))

        # IO.inspect(turn)
        # IO.inspect(blocks)
        {current_position, current_heading} = go(current_position, current_heading, turn, blocks)
        interpret(tail, current_position, current_heading)
    end

    def interpret([], current_position, _current_heading) do
        current_position
    end
end

{:ok, input} = File.read("input.txt")
input = String.trim(input)
inputs = String.split(input, ", ")

starting_point = [0,0]
current_position = [0,0]
current_heading = 0

end_position = One.interpret(inputs, current_position, current_heading)
IO.inspect(end_position)
x_away = 0+Enum.at(end_position, 0)
y_away = 0+Enum.at(end_position, 1)

IO.puts("x away:")
IO.inspect(x_away)
IO.puts("y away:")
IO.inspect(y_away)
