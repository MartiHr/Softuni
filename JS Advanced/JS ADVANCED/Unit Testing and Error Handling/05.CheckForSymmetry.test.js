const assert = require('chai').assert;
const isSymmetric = require('./05.CheckForSymmetry');

describe('Check whether array is symmetric', () => {

    it('Takes array as argument', () => {
        let input1 = 1;
        let input2 = {};
        let input3 = 'someText';
        let input4 = null;
        let input5 = [true, false, true, false, false];
        let input6 = false;
        let input7 = undefined;
        let input8 = [true, 'text'];

        assert.isFalse(isSymmetric(input1));
        assert.isFalse(isSymmetric(input2));
        assert.isFalse(isSymmetric(input3));
        assert.isFalse(isSymmetric(input4));
        assert.isFalse(isSymmetric(input5));
        assert.isFalse(isSymmetric(input6));
        assert.isFalse(isSymmetric(input7));
        assert.isFalse(isSymmetric(input8));
    });

    // odd count - mixed types
    it('Should check if mixed symmetric arr is symmetric)', () => {
        let arr = ["pesho", new Date(2016, 8, 15), false, new Date(2016, 8, 15), "pesho"];

        assert.isTrue(isSymmetric(arr));
    });

    it('Should check if empty arr is symmetric', () => {
        let arr = [];

        assert.isTrue(isSymmetric(arr));
    });

    it('Should check if mixed symmetric arr is symmetric', () => {
        let arr = [1, 'text', 1];

        assert.isTrue(isSymmetric(arr));
    });

    it('Should check if one-character symmetric arr is symmetric', () => {
        let arr = [1];

        assert.isTrue(isSymmetric(arr));
    });

    it('Should check if odd symmetric arr is symmetric', () => {
        let arr = [1, 2, 1];

        assert.isTrue(isSymmetric(arr));
    });

    it('Should check if even symmetric arr is symmetric', () => {
        let arr = [1, 2, 2, 1];

        assert.isTrue(isSymmetric(arr));
    });

    it('Should check if odd non-symmetric arr is not symmetric', () => {
        let arr = [1, 2, 3];

        assert.isFalse(isSymmetric(arr));
    });

    it('Should check if even non-symmetric arr is not symmetric', () => {
        let arr = [1, 2, 3, 4];

        assert.isFalse(isSymmetric(arr));
    });
});