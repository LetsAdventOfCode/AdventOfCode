
function solve() {
    var input = document.getElementById("input").value;

    var int = 0;
    var password = "";
    var secondPassword = [];
    while (true) {
        var hash = md5(input + int)
        if (hash.toString(16).startsWith("00000")) {
            password += hash[5];
        }
        int++
        if(password.length >= 8)
            break;
    }
    document.getElementById("solution").innerHTML = password;
}