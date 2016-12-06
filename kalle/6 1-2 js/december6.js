
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
    var numberOfColumns = input.indexOf("\n") + 1;
    for (var i = 0; i < input.length; i++) {
        if (!columns[i % numberOfColumns])
            columns[i % numberOfColumns] = [];

        if (!columns[i % numberOfColumns][input[i].charCodeAt(0)])
            columns[i % numberOfColumns][input[i].charCodeAt(0)] = 1;
        else
            columns[i % numberOfColumns][input[i].charCodeAt(0)]++;
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

function mostCommonReduce(a, b) {
    return a > b ? a : b;
}

function leastCommonReduce(a, b) {
    return a < b ? a : b;
}