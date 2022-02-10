const assert = require('chai').assert;
const expect = require('chai').expect;
const mathEnforcer = require('./04.MathEnforcer');

describe('Test mathEnforcer object', () => {
   
    describe('addFive', () => {

        // Correct input
        it('Can add five to zero correctly', () => {
            assert.equal(mathEnforcer.addFive(0), 5);
        });

        it('Can add five to five correctly', () => {
            assert.equal(mathEnforcer.addFive(5), 10);
        });

        it('Can add five to minus five correctly', () => {
            assert.equal(mathEnforcer.addFive(-5), 0);
        });

        it('Can add five to 5.5 correctly', () => {
            assert.equal(mathEnforcer.addFive(5.5), 10.5);
        });

        it("Should return correct result for floating point parameter", () => {
            assert.closeTo(mathEnforcer.addFive(3.14), 8.14, 0.01);
        });

        // Incorrect input

        it('Does not add five to string', () => {
            assert.equal(mathEnforcer.addFive(''), undefined);
        });

        it('Does not add five to null', () => {
            assert.equal(mathEnforcer.addFive(null), undefined);
        });

        it('Does not add five to {}', () => {
            assert.equal(mathEnforcer.addFive({}), undefined);
        });

        it('Does not add five to []', () => {
            assert.equal(mathEnforcer.addFive([]), undefined);
        });

        it('Does not add five to undefined', () => {
            assert.equal(mathEnforcer.addFive(undefined), undefined);
        });
    });

    describe('subtractTen', () => {

        // Correct input
        it('Can subtract 10 from 15', () => {
            assert.equal(mathEnforcer.subtractTen(15), 5);
        });

        it('Can subtract 10 from 20', () => {
            assert.equal(mathEnforcer.subtractTen(20), 10);
        });

        it('Can subtract 10 from 20.5', () => {
            assert.equal(mathEnforcer.subtractTen(20.5), 10.5);
        });

        it('Can subtract 10 from 0', () => {
            assert.equal(mathEnforcer.subtractTen(-5), -15);
        });

        it('Can subract 10 from 5.5 correctly', () => {
            assert.equal(mathEnforcer.subtractTen(5.5), -4.5);
        });

        // Incorrect input

        it('Does not subtract 10 from string', () => {
            assert.equal(mathEnforcer.subtractTen(''), undefined);
        });

        it('Does not subtract 10 from null', () => {
            assert.equal(mathEnforcer.subtractTen(null), undefined);
        });

        it('Does not subtract 10 from {}', () => {
            assert.equal(mathEnforcer.subtractTen({}), undefined);
        });

        it('Does not subtract 10 from []', () => {
            assert.equal(mathEnforcer.subtractTen([]), undefined);
        });

        it('Does not subtract 10 from undefined', () => {
            assert.equal(mathEnforcer.subtractTen(undefined), undefined);
        });

        it("Should return correct result for floating point parameter", () => {
            assert.closeTo(mathEnforcer.subtractTen(3.14), -6.86, 0.01);
        });
    });

    describe('sum', () => {

        // Correct input

        it('Sums 5 and 10', () => {
            assert.equal(mathEnforcer.sum(5, 10), 15);
        });

        it('Sums 5.5 and 10', () => {
            assert.equal(mathEnforcer.sum(5.5, 10), 15.5);
        });

        it('Sums -5 and 10', () => {
            assert.equal(mathEnforcer.sum(-5, 10), 5);
        });

        it('Sums 5 and -10', () => {
            assert.equal(mathEnforcer.sum(5, -10), -5);
        });

        it('Sums -5 and -10', () => {
            assert.equal(mathEnforcer.sum(-5, -10), -15);
        });

        it('Sums 5.5 and 10', () => {
            assert.equal(mathEnforcer.sum(5.5, 10), 15.5);
        });

        it('Sums 10 and 5.5', () => {
            assert.equal(mathEnforcer.sum(10, 5.5), 15.5);
        });

        // Incorrect input

        it('Does not sum "" and 10', () => {
            assert.equal(mathEnforcer.sum('', 10), undefined);
        });

        it('Does not sum 10 and ""', () => {
            assert.equal(mathEnforcer.sum(10, ''), undefined);
        });

        it('Does not sum null and 10', () => {
            assert.equal(mathEnforcer.sum(null, 10), undefined);
        });

        it('Does not sum 10 and null', () => {
            assert.equal(mathEnforcer.sum(10, null), undefined);
        });

        it('Does not sum undefined and undefined', () => {
            assert.equal(mathEnforcer.sum(undefined, undefined), undefined);
        });
    });
});