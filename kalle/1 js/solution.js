var x = 0;
var y = 0;
var direction = 0;
var visited = [[]];
function solve() {
    var input = document.getElementById("input").value;
    var instructions = parseInput(input);
    x = 0;
    y = 0;
    visited[x][y] = 1;
    drawBoard();
    var intersection;
    for (var i = 0; i < instructions.length; i++) {

        intersection = move(instructions[i].substring(0, 1), instructions[i].substring(1));
        if (intersection)
            break;
    }

    document.getElementById("location").innerHTML = "x: " + x + " y: " + y;
    document.getElementById("visits").innerHTML = visited[x][y];
    document.getElementById("answer").innerHTML = Math.abs(intersection.x) + Math.abs(intersection.y);
}

function move(turn, walk) {
    switch (turn) {
        case "L":
            direction = (direction + 3) % 4;
            break;
        case "R":
            direction = (direction + 1) % 4;
            break;
    }

    var distance = (direction < 2) ? parseInt(walk) : -parseInt(walk);
    var intersection;
    for (var i = 0; i < Math.abs(distance) ; i++) {
        var startx = x;
        var starty = y;
        x = (direction % 2 === 1) ? ((direction < 2) ? 1 : -1) + x : x;
        y = (direction % 2 === 0) ? ((direction < 2) ? 1 : -1) + y : y;

        if (!visited[x])
            visited[x] = [];
        if (!visited[x][y])
            visited[x][y] = 0;
        visited[x][y]++;

        paint(startx, starty, direction);

        if (visited[x][y] > 1) {
            paintIntersection(x, y);
            intersection = { x: x, y: y };
        }
    }
    return intersection;
}

var canvasx = 410;
var canvasy = 310;
var amount = 1.5;
var stepMultiplier = 20;
function paint(startx, starty, direction) {
    var c = document.getElementById("canvas");
    var ctx = c.getContext("2d");

    startx *= stepMultiplier;
    starty *= stepMultiplier;

    var moveToX = (direction % 2 === 1) ? (((direction < 2) ? 1 : -1) * stepMultiplier) + startx : startx;
    var moveToY = (direction % 2 === 0) ? ((((direction < 2) ? 1 : -1) * stepMultiplier) + starty) : starty;
    ctx.beginPath();
    ctx.moveTo(startx + canvasx, starty * -1 + canvasy);
    ctx.lineTo(moveToX + canvasx, moveToY * -1 + canvasy);
    ctx.strokeStyle = '#ff0000';
    ctx.lineWidth = 5;
    ctx.stroke();
}

function paintIntersection(x, y) {
    var c = document.getElementById("canvas");
    var ctx = c.getContext("2d");
    ctx.beginPath();
    var stepX = x * stepMultiplier + canvasx;
    var stepY = stepMultiplier * -1 + canvasy;
    ctx.moveTo(stepX, stepY);
    ctx.lineTo(stepX - 10, stepY - 10);
    ctx.strokeStyle = '#ffff00';
}

function drawBoard() {
    var bw = 800;
    var bh = 600;
    //padding around grid
    var p = 0;
    //size of canvas
    var cw = bw + (p * 2) + 1;
    var ch = bh + (p * 2) + 1;
    var c = document.getElementById("canvas");
    var context = c.getContext("2d");
    context.beginPath();
    for (var x = 0; x <= bw; x += 20) {
        context.moveTo(0.5 + x + p, p);
        context.lineTo(0.5 + x + p, bh + p);
    }


    for (var x = 0; x <= bh; x += 20) {
        context.moveTo(p, 0.5 + x + p);
        context.lineTo(bw + p, 0.5 + x + p);
    }

    context.strokeStyle = "black";
    context.stroke();
}

function parseInput(input) {
    return input.split(",").map(function (str) {
        return str.trim();
    });
}