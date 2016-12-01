var x = 0;
var y = 0;
var direction = 0;
var visited = [[]];
var intersection;
var intersections = [];
function solve() {
    var input = document.getElementById("input").value;
    var instructions = parseInput(input);
    x = 0;
    y = 0;
    visited[x][y] = 1;
    drawBoard();
    
    for (var i = 0; i < instructions.length; i++) {

        move(instructions[i].substring(0, 1), instructions[i].substring(1));
    }

    paintIntersection(intersection.x, intersection.y, '#ffff00');
    for (var j = 0; j < intersections.length; j++) {
        paintIntersection(intersections[j].x, intersections[j].y, '#0000ff');
    }
    document.getElementById("location").innerHTML = "x: " + x + " y: " + y;
    document.getElementById("intersectionLocation").innerHTML = "x: " + intersection.x + " y: " + intersection.y;
    document.getElementById("distanceToEnd").innerHTML = Math.abs(x) + Math.abs(y);
    document.getElementById("distanceToIntersection").innerHTML = Math.abs(intersection.x) + Math.abs(intersection.y);
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

            if (!intersection) {
                intersection = { x: x, y: y };
            } else {
                intersections.push({ x: x, y: y });
            }
        }
    }
    return intersection;
}

var amount = 1.5;
var gridWidth = 2;
var canvasCenterX = 500 + gridWidth / 2;
var canvasCenterY = 500 + gridWidth / 2;
function paint(startx, starty, direction) {
    var c = document.getElementById("canvas");
    var ctx = c.getContext("2d");

    startx *= gridWidth;
    starty *= gridWidth;

    var moveToX = (direction % 2 === 1) ? (((direction < 2) ? 1 : -1) * gridWidth) + startx : startx;
    var moveToY = (direction % 2 === 0) ? ((((direction < 2) ? 1 : -1) * gridWidth) + starty) : starty;
    ctx.beginPath();
    ctx.moveTo(startx + canvasCenterX, starty * -1 + canvasCenterY);
    ctx.lineTo(moveToX + canvasCenterX, moveToY * -1 + canvasCenterY);
    ctx.strokeStyle = '#ff0000';
    ctx.lineWidth = 2;
    ctx.stroke();
}

function paintIntersection(x, y, color) {
    var c = document.getElementById("canvas");
    var ctx = c.getContext("2d");
    ctx.beginPath();
    var stepX = x * gridWidth + canvasCenterX;
    var stepY = y * gridWidth * -1 + canvasCenterY;
    ctx.moveTo(stepX - gridWidth / 2, stepY - gridWidth / 2);
    ctx.lineTo(stepX + gridWidth / 2, stepY + gridWidth / 2);
    ctx.moveTo(stepX - gridWidth / 2, stepY + gridWidth / 2)
    ctx.lineTo(stepX + gridWidth / 2, stepY - gridWidth / 2);
    ctx.strokeStyle = color;
    ctx.stroke();
}

function drawBoard() {
    var bw = 1000;
    var bh = 1000;
    //padding around grid
    var p = 0;
    //size of canvas
    var cw = bw + (p * 2) + 1;
    var ch = bh + (p * 2) + 1;
    var c = document.getElementById("canvas");
    var context = c.getContext("2d");
    context.beginPath();
    for (var x = 0; x <= bw; x += gridWidth) {
        context.moveTo(0.5 + x + p, p);
        context.lineTo(0.5 + x + p, bh + p);
    }


    for (var x = 0; x <= bh; x += gridWidth) {
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