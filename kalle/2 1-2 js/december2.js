function solve() {
    var input = document.getElementById("input").value;
    var position = 5;
    var codes = input.split("\n");
    var keyPad = [[]];
    var code = "";
    for (var i = 0; i < codes.length; i++) {
        for (var j = 0; j < codes[i].length; j++) {
            position += codes[i][j] === "L" && position - 1 % 3 !== 0 ? -1 : codes[i][j] === "R" && 1 + position % 3 !== 1 ? 1 : 0;
            position += codes[i][j] === "D" && position + 3 <= 9 ? 3 : codes[i][j] === "U" && position - 3 > 0 ? -3 : 0;
        }
        code += position;
    }
    document.getElementById("solution").innerHTML = code;
}