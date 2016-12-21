function solve() {
	//Console code var n = 3017957; 2 * (n - Math.pow(2, Math.floor(Math.log2(n)))) + 1
    var n = document.getElementById("input").value;
    document.getElementById("solution").innerHTML = 2 * (n - Math.pow(2, Math.floor(Math.log2(n)))) + 1;
}
