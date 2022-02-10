const assert = require('chai').assert;
const isOddOrEven = require('./02.EvenOrOdd');

describe('Check is length is odd or even', () => {
    it('Gets even length', () => {
        assert.equal(isOddOrEven('1234'), 'even');
    });

    it('Gets even odd', () => {
        assert.equal(isOddOrEven('123'), 'odd');
    });

    it('Returns undefined if null is passed', () => {
        assert.equal(isOddOrEven(null), undefined);
    });

    it('Returns undefined if undefined is passed', () => {
        assert.equal(isOddOrEven(undefined), undefined);
    });

    it('Returns undefined if empty object is passed', () => {
        assert.equal(isOddOrEven({}), undefined);
    });

    it('Returns undefined if number is passed', () => {
        assert.equal(isOddOrEven(5), undefined);
    });

    it('Returns undefined if arr is passed', () => {
        assert.equal(isOddOrEven([]), undefined);
    });
});