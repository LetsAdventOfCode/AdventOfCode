var d = 0; // north, east, south, west
var x = 0, y = 0, ix = undefined, iy;

var c = {};

var input = 'R2, L3, R2, R4, L2, L1, R2, R4, R1, L4, L5, R5, R5, R2, R2, R1, L2, L3, L2, L1, R3, L5, R187, R1, R4, L1, R5, L3, L4, R50, L4, R2, R70, L3, L2, R4, R3, R194, L3, L4, L4, L3, L4, R4, R5, L1, L5, L4, R1, L2, R4, L5, L3, R4, L5, L5, R5, R3, R5, L2, L4, R4, L1, R3, R1, L1, L2, R2, R2, L3, R3, R2, R5, R2, R5, L3, R2, L5, R1, R2, R2, L4, L5, L1, L4, R4, R3, R1, R2, L1, L2, R4, R5, L2, R3, L4, L5, L5, L4, R4, L2, R1, R1, L2, L3, L2, R2, L4, R3, R2, L1, L3, L2, L4, L4, R2, L3, L3, R2, L4, L3, R4, R3, L2, L1, L4, R4, R2, L4, L4, L5, L1, R2, L5, L2, L3, R2, L2';

var inst = input.toUpperCase().split(', ');

for (var i = 0; i < inst.length; i++) {
  d = (d + (inst[i][0] == 'R' ? 1 : 3)) % 4;
  for (var r = 0; r < parseInt(inst[i].substring(1)); r++) {
    c[y+'-'+x] = 1;
    d % 2 ? x += d - 2 : y += d - 1;
    if (c[y+'-'+x] == 1 && ix === undefined) { ix = x; iy = y; }
  }
}

console.log(y, x);
console.log(iy, ix);
var a = (x < 0 ? -x : x) + (y < 0 ? -y : y);
var ia = (ix < 0 ? -ix : ix) + (iy < 0 ? -iy : iy);
console.log(a, ia);
