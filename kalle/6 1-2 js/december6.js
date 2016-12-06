
function solve() {
    var input = document.getElementById("input").value;
    var columns = analyzeFrequencies(input);
    var mostCommonMessage = getMessage(columns, mostCommonReduce);
    var leastCommonMessage = getMessage(columns, leastCommonReduce);

    document.getElementById("mostCommon").innerHTML = mostCommonMessage;
    document.getElementById("leastCommon").innerHTML = leastCommonMessage;
}

function analyzeFrequencies(input) {
    var columns = []
    var indexOfLinebreak = input.indexOf("\n") + 1;
    for (var i = 0; i < input.length; i++) {
        if (!columns[i % indexOfLinebreak])
            columns[i % indexOfLinebreak] = [];

        if (!columns[i % indexOfLinebreak][input[i].charCodeAt(0)])
            columns[i % indexOfLinebreak][input[i].charCodeAt(0)] = 1;
        else
            columns[i % indexOfLinebreak][input[i].charCodeAt(0)]++;
    }
    return columns;
}

function getMessage(columns, reduceFunction) {
    var message = "";
    for (var i = 0; i < columns.length; i++) {
        var value = columns[i].reduce(reduceFunction);
        var index = columns[i].findIndex(function (element) { return element === value; });
        message += String.fromCharCode(index);
    }
    return message;
}

function mostCommonReduce(a, b, i) {
    return a > b ? a : b;
}

function leastCommonReduce(a, b, i) {
    return a < b ? a : b;
}