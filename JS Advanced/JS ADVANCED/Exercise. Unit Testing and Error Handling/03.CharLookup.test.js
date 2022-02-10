const assert = require('chai').assert;
const lookupChar = require('./03.CharLookup');

describe('Lookup for a char', () => {
    
    it('Gets correct char at index', () => {
        assert.equal(lookupChar('abc', 1), 'b');
    });

    it('Gets correct char at index 0', () => {
        assert.equal(lookupChar('abc', 0), 'a');
    });

    it('Gets correct char at index which is the length of the string', () => {
        assert.equal(lookupChar('abc', 2), 'c');
    });

    it('Wrong string type error', () => {
        assert.equal(lookupChar(null, 0), undefined);
        assert.equal(lookupChar({}, 0), undefined);
        assert.equal(lookupChar([], 0), undefined);
        assert.equal(lookupChar(undefined, 0), undefined);
        assert.equal(lookupChar(5, 0), undefined);
    });

    it('Wrong index type error', () => {
        assert.equal(lookupChar('abc', 1.5), undefined);
        assert.equal(lookupChar('abc', null), undefined);
        assert.equal(lookupChar('abc', undefined), undefined);
        assert.equal(lookupChar('abc', {}), undefined);
        assert.equal(lookupChar('abc', []), undefined);    
        assert.equal(lookupChar('abc', 'cba'), undefined);    
    });

    it('Has too small index', () => {
        assert.equal(lookupChar('abc', -5), 'Incorrect index');
    });

    it('Has too big index', () => {
        assert.equal(lookupChar('abc', 10), 'Incorrect index');
    });
});