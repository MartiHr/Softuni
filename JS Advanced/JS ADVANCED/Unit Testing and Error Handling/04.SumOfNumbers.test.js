const assert = require('chai').assert;
const sum = require('./04.SumOfNumbers');

describe('sumOfNumbers', () => {
    it('Should return a positive sum of a given array of numbers', () => {
        let numberArr = [1, 2, 3];

        let expectedResult = 6;
        let actualResult = sum(numberArr);

        assert.equal(expectedResult, actualResult);
    });

    it('Should return a negative sum of a given array of numbers', () => {
        let numberArr = [1, 2, -6];

        let expectedResult = -3;
        let actualResult = sum(numberArr);

        assert.equal(expectedResult, actualResult);
    });

    it('Should return a negative sum of a given array of zeroes', () => {
        let numberArr = [0, 0, 0];

        let expectedResult = 0;
        let actualResult = sum(numberArr);

        assert.equal(expectedResult, actualResult);
    });
});