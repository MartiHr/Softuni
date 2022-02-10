function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};

function solve(area, vol, input) {

    let coordinateObjects = JSON.parse(input);
    
    let result = [];

    for (const coordinateObject of coordinateObjects) {
        let object = {
            area: area.call(coordinateObject),
            volume: vol.call(coordinateObject), 
        };

        result.push(object);
    }

    return result;
}

console.log(solve(area, vol, 
`[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
]`));