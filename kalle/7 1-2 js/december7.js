function solve() {
    var input = document.getElementById("input").value;
    var ips = input.split("\n");
    var tlsIps = [];
    var sslIps = [];
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
        for (var j = 0; j < candidates.length; j++) {
            if (!hypernetAbba) {
                if (hasAbba(candidates[j])) {
                    tlsIps.push(ips[i]);
                    hypernetAbba = true;
                }
            }
            
            var abas = getAbas(candidates[j]);
            if (abas.length > 0) {
                if (hasBab(hypernets, abas)) {
                    console.log(ips[i]);
                    sslIps.push(ips[i]);
                    break;
                }
            }
        }
    }

    document.getElementById("solution").innerHTML = tlsIps.length;
    document.getElementById("ssl").innerHTML = sslIps.length;
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

function getAbas(candidate) {
    var palindromes = [];
    for (var i = 0; i < candidate.length - 2; i++) {
        var p = candidate.substring(i, i + 3);
        if (p[0] !== p[1] && isPalindrom(p)) {
            
            palindromes.push(p);
        }
    }
    return palindromes;
}

function hasBab(hypernets, abas) {
    for (var i = 0; i < abas.length; i++) {
        var bab = abas[i][1] + abas[i][0] + abas[i][1];
        for (var j = 0; j < hypernets.length; j++) {
            if (hypernets[j].indexOf(bab) >= 0) {
                console.log(abas[i] + " hypernet: " + j + " index" + hypernets[j].indexOf(bab));
                return true;
            }
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