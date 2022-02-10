const assert = require('chai').assert;
const createCalculator = require('./07.AddSubtract');

describe('Calculator', () => {
    
    it('Returns proper object', () => {
        calculator = createCalculator();
        
        assert.equal(typeof(calculator), 'object');
        assert.equal(typeof(calculator.add), 'function');
        assert.equal(typeof(calculator.subtract), 'function');
        assert.equal(typeof(calculator.get), 'function');
    });

    it('Sum cannot be modified', () => {
        calculator = createCalculator();
        
        calculator.value += 5;

        assert.notEqual(calculator.value, 5)
    });

    it('Can add correctly', () => {
        calculator = createCalculator();
        
        calculator.add(5);
        calculator.add('5');
        
        assert.equal(calculator.get(), 10);
    });

    it('Can subtract correctly', () => {
        calculator = createCalculator();
        
        calculator.subtract(5);
        calculator.subtract('5');
        
        assert.equal(calculator.get(), -10);
    });
})