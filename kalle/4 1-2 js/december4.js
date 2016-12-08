function solve() {
    var input = document.getElementById("input").value;

    var rooms = input.split("\n");
    var sectorIdSum = 0;
    var northPoleRoom = 0;
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
        if (isRealRoom(letterCount.concat(), rooms[i].substring(checksumIndex + 1, checksumIndex + 6))) {
            sectorIdSum += parseInt(sectorId);
        }

        if (isNorthPoleObjectsRoom(rooms[i].substring(0, checksumIndex).replace("-" + sectorId, ""), sectorId)) {
            northPoleRoom += parseInt(sectorId);
        }
    }

    document.getElementById("sectorIdSum").innerHTML = sectorIdSum;
    document.getElementById("northPoleRoom").innerHTML = northPoleRoom;
}


function isRealRoom(letterCount, checksum) {

    for (var i = 0; i < checksum.length; i++) {
        var value = letterCount.reduce(function (a, b) {
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

function isNorthPoleObjectsRoom(room, sectorId) {
    var decipheredRoom = "";
    for (var i = 0; i < room.length; i++) {
        if (room[i] === '-')
            decipheredRoom += " ";
        else
            decipheredRoom += String.fromCharCode(((room[i].charCodeAt(0) - 97 + parseInt(sectorId)) % 26 + 97));
    }
    console.log(decipheredRoom);
    if (decipheredRoom == "northpole object storage")
        return true;
    return false;
}