function figureCircleAndRectangle() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        get area(){
            return 0;
        }

        changeUnits(unit) {
            this.units = unit;
        }

        toString() {
            return `Figures units: ${this.units}`;
        }
    }

    class Circle extends Figure {
        constructor(radius) {
            super();

            this.radius = radius;
        }

        get area(){
            let result = Math.PI * (this.radius ** 2);

            if (this.units == 'mm') {
                result = result / 100;                
            } else if(this.units == 'm') {
                this.radius /= (100 * 100); 
            }

            return result;
        }

        toString() {
            let radius = this.radius;
            
            if (this.units == 'mm') {
                radius = this.radius * 10;
                
            } else if(this.units == 'm'){
                radius = this.radius / 100;
            } 

            return `Figures units: ${this.units} Area: ${this.area} - radius: ${radius}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);

            this.width = width;
            this.height = height;
        }

        get area(){
            let result = this.width * this.height;

            if (this.units == 'mm') {
                result = result * 100;                
            } else if(this.units == 'm') {
                this.radius /= (100 * 100); 
            }

            return result;
        }
        
        toString() {
            let width = this.width;
            let height = this.height;

            if (this.units == 'mm') {
                width = this.width * 10;
                height = this.height * 10;
             
            } else if(this.units == 'm'){
                width = this.width / 100;
                height = this.height / 100;
            } 

            return `Figures units: ${this.units} Area: ${this.area} - width: ${width}, height: ${height}`;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}