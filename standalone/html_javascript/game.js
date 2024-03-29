const _canvas = document.getElementById("canvas");
const _ctx = _canvas.getContext("2d");
const _defaultWidth = window.innerWidth;
const _defaultHeight = window.innerHeight;
const _countX = 32;
const _countY = 32;
const _chipWidth = _defaultWidth / _countX;
const _chipHeight = _defaultHeight / _countY;
const _rabbitImageFile = "rabbit.png";
const _rabbitImage = new Image();
let _generation = 0;
_rabbitImage.src = _rabbitImageFile;

_ctx.canvas.width  = _defaultWidth;
_ctx.canvas.height = _defaultHeight;

let _data = new Array(_countY);
for(let i = 0; i < _data.length; i++) {
    _data[i] = new Array(_countX);
}

function drawBackground() {
    const gradient = _ctx.createLinearGradient(0, 0, _defaultWidth, _defaultHeight);
    gradient.addColorStop(0, "green");
    gradient.addColorStop(1, "seagreen");
    _ctx.fillStyle = gradient;
    _ctx.fillRect(0, 0, _defaultWidth, _defaultHeight);
}

function drawRabbit(x, y) {
    _ctx.drawImage(_rabbitImage, x * _chipWidth, y * _chipHeight, _chipWidth, _chipHeight);
}

function resize() {
    const canvasRatio = 1080 / 1920;
    const windowRatio = window.innerHeight / window.innerWidth;
    let width;
    let height;

    if (windowRatio < canvasRatio) {
        height = window.innerHeight;
        width = height / canvasRatio;
    } else {
        width = window.innerWidth;
        height = width * canvasRatio;
    }

    _canvas.style.width = (width * 0.9) + 'px';
    _canvas.style.height = (height * 0.9) + 'px';
};

function draw() {
    drawBackground();
    for (let y = 0; y < _countY; y++) {
        for (let x = 0; x < _countX; x++) {
            if (_data[y][x] === 1){
                drawRabbit(x, y);
            }
        }
    }    
}

function calcNextGeneration() {

    let buffer = new Array(_countY);
    for(let i = 0; i < buffer.length; i++) {
        buffer[i] = new Array(_countX);
    }

    for (let y = 0; y < _countY; y++) {
        for (let x = 0; x < _countX; x++) {
            let count = 0;
            count += x > 0 && y > 0 ? _data[y - 1][x - 1] : 0;
            count += x < _countX - 1 && y > 0 ? _data[y - 1][x + 1] : 0;
            count += x > 0 && y < _countY - 1 ? _data[y + 1][x - 1] : 0;
            count += x < _countX - 1 && y < _countY - 1 ? _data[y + 1][x + 1] : 0;
            count += x > 0 ? _data[y][x - 1] : 0;
            count += x < _countX - 1 ? _data[y][x + 1] : 0;
            count += y > 0 ? _data[y - 1][x] : 0;
            count += y < _countY - 1 ? _data[y + 1][x] : 0;
            const next = count === 3 || (_data[y][x] === 1 && count === 2) ? 1 : 0;
            buffer[y][x] = next;
        }
    }
    _data = buffer;
}

function drawNextGeneration() {
    calcNextGeneration();
    draw();
    _generation++;
    document.getElementById("generation").innerText = "世代:" + _generation.toString();
}

function getRandomInt(max) {
    return Math.floor(Math.random() * max);
}


window.addEventListener('resize', resize, false);
drawBackground();
resize();


for (let y = 0; y < _countY; y++) {
    for (let x = 0; x < _countX; x++) {
        _data[y][x] = getRandomInt(6) === 0 ? 1 : 0;
    }
}

window.setInterval(drawNextGeneration, 1000);