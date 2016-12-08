function solve() {
    var input = document.getElementById("input").value;

    var int = 0;
    var firstPassword = "";
    var secondPassword = [];
    var secondPasswordCount = 0;
    while (true) {
        var hash = md5(input + int)
        if (hash.toString(16).startsWith("00000")) {
            if (firstPassword.length < 8)
                firstPassword += hash[5];
            if (hash[5] >= 0 && hash[5] < 8 && !secondPassword[hash[5]]) {
                secondPassword[hash[5]] = hash[6];
                secondPasswordCount++;
            }
                
        }
        int++
        if (firstPassword.length >= 8 && secondPassword.filter(function(value) { return value !== undefined }).length >= 8)
            break;
    }
    document.getElementById("firstPassword").innerHTML = firstPassword;
    document.getElementById("secondPassword").innerHTML = secondPassword.join("");
}