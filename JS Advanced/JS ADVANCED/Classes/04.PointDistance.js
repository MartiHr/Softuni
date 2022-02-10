class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(firstPoint, secondPoint){
        let horizontalDistance = Math.abs(firstPoint.x - secondPoint.x);
        let verticalDistance = Math.abs(firstPoint.y - secondPoint.y);

        return Math.sqrt((horizontalDistance ** 2) + (verticalDistance ** 2));
    }
}