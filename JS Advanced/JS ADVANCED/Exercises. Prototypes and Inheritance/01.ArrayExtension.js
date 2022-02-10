(function solve(params) {
    Array.prototype.last = function () {
        return this[this.length - 1];
    }

    Array.prototype.skip = function (n) {
        return this.slice(n, this.length - n + 1);
    }

    Array.prototype.take = function (n) {
        return this.slice(0, this.length - n + 1);
    }

    Array.prototype.sum = function () {
        return this.reduce((a, b) => a + b, 0);
    }

    Array.prototype.average = function () {
        return (this.reduce((a, b) => a + b, 0) / this.length);
    }
}
)();

var testArray = [1, 2, 3];

console.log(testArray.skip(1)[1]);