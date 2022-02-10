const assert = require('chai').assert;
const rgbToHexColor = require('./06.RGBToHex');

describe('Turn rgb values to hex color', () => {
    it('Gets hex color from correct rgb values', () => {
        assert.equal(rgbToHexColor(1, 1, 1), '#010101');
        assert.equal(rgbToHexColor(100, 100, 100), '#646464');
    });

    it('Gets hex color from correct rgb values (edge cases)', () => {
        assert.equal(rgbToHexColor(0, 0, 0), '#000000');
        assert.equal(rgbToHexColor(255, 255, 255), '#FFFFFF');
    });

    it('Does not get hex color from out of range rgb values', () => {
        assert.equal(rgbToHexColor(-1, 1, 1), undefined);
        assert.equal(rgbToHexColor(1, -1, 1), undefined);
        assert.equal(rgbToHexColor(1, 1, -1), undefined);

        assert.equal(rgbToHexColor(300, 1, 1), undefined);
        assert.equal(rgbToHexColor(1, 300, 1), undefined);
        assert.equal(rgbToHexColor(1, 1, 300), undefined);
    });

    it('Does not get hex color from NaN rgb values', () => {
        assert.equal(rgbToHexColor('text', 1, 1), undefined);
        assert.equal(rgbToHexColor(1, 'text', 1), undefined);
        assert.equal(rgbToHexColor(1, 1, 'text'), undefined);

        assert.equal(rgbToHexColor(null, 1, 1), undefined);
        assert.equal(rgbToHexColor(1, null, 1), undefined);
        assert.equal(rgbToHexColor(1, 1, null), undefined);
    });

});