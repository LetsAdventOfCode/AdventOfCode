function solve() {
    var input = document.getElementById("input").value;
    var ips = input.split("\n");
    var tlsIps = [];
    for (var i = 0; i < ips.length; i++) {
        var parsedInput = ips[i].split("[");
        var hypernets = [];
        var candidates = [];
        candidates.push(parsedInput[0]);
        for (var j = 1; j < parsedInput.length; j++) {
            var a = parsedInput[j].split("]");
            hypernets.push(a[0]);
            candidates.push(a[1]);
        }
        var hypernetAbba = false;
        for (var j = 0; j < hypernets.length; j++) {
            if (hasAbba(hypernets[j])) {
                hypernetAbba = true;
                break;
            }
        }
        if (hypernetAbba) {
            continue;
        }
        for (var j = 0; j < candidates.length; j++) {
            if (hasAbba(candidates[j])) {
                tlsIps.push(ips[i])
                break;
            }
        }
    }

    document.getElementById("solution").innerHTML = tlsIps.length;
}

function hasAbba(candidate) {
    for (var i = 0; i < candidate.length - 3; i++) {
        var p = candidate.substring(i, i + 4);
        if (p[0] !== p[1] && isPalindrom(p)) {
            return true;
        }
    }
    return false;
}

function isPalindrom(s) {
    if (s === "")
        return true;
    if (s.length === 1)
        return true;
    return s[0] === s[s.length - 1] && isPalindrom(s.substring(1, s.length - 1));
}