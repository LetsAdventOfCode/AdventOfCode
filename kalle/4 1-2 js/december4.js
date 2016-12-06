
function solve() {
    var input = document.getElementById("input").value;

    var rooms = input.split("\n");
    var sectorIdSum = 0;
    var checksumIndex = 0;
    for (var i = 0; i < rooms.length; i++) {
        var letterCount = [];
        var sectorId = "";
        var checksumIndex = 0;
        for (var j = 0; j < rooms[i].length; j++) {
            if (rooms[i][j] === "-")
                continue;
            if (rooms[i][j].match(/\d+/)) {
                sectorId += rooms[i][j];
                continue;;
            }
            if (rooms[i][j] === "[") {
                checksumIndex = j;
                break;
            }
            if (!letterCount[rooms[i][j].charCodeAt(0)])
                letterCount[rooms[i][j].charCodeAt(0)] = 0;
            letterCount[rooms[i][j].charCodeAt(0)]++;

        }
        if (isRealRoom(letterCount, rooms[i].substring(checksumIndex + 1, checksumIndex + 6))) {
            sectorIdSum += parseInt(sectorId);
        }
    }
  
    document.getElementById("solution").innerHTML = sectorIdSum;
}


function isRealRoom(letterCount, checksum) {

    for (var i = 0; i < checksum.length; i++) {
        var value = letterCount.reduce(function(a, b) {
            return a > b ? a : b;
        });

        var index = letterCount.findIndex(function (element) { return element === value; });

        letterCount[index] = 0;

        if (String.fromCharCode(index) !== checksum[i]) {
            return false;
        }
    }
    return true;
}