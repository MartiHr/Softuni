const assert = require('chai').assert;
const flowerShop = require('./flowerShop');

describe("Tests …", function () {

    describe("calcPriceOfFlowers", function () {
        it("Accepts one string and two numbers", function () {
            assert.throw(() => flowerShop.calcPriceOfFlowers(undefined, 6, 6), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers('a', undefined, 6), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers('a', 6, undefined), 'Invalid input!');
        });

        it("Calculates fliowers price", function () {
            let result = flowerShop.calcPriceOfFlowers('a', 5, 6);
            assert.equal(result, `You need $30.00 to buy a!`)
        });
    });

    describe("checkFlowersAvailable", function () {
        it("Checks for available flowers", function () {
            let result = flowerShop.checkFlowersAvailable('a', ['a', 'b', 'c']);
            assert.equal(result, `The a are available!`);            
        });
        
        it("Checks for unavailable flowers", function () {
            let result = flowerShop.checkFlowersAvailable('a', ['b', 'd', 'c']);
            assert.equal(result, `The a are sold! You need to purchase more!`);         
        });
    });

    describe("sellFlowers", function () {
        it("Checks for invalid input", function () {
            assert.throw(() => flowerShop.sellFlowers(undefined, 5), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers(['a'], undefined), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers(['a'], -1), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers(['a'], -1), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers(['a'], 1), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers(['a'], 5), 'Invalid input!');
        });
        
        it("Sells flowers", function () {
            let result1 = flowerShop.sellFlowers(['a', 'b', 'c'], 0);
            let result2 = flowerShop.sellFlowers(['a', 'b', 'c'], 2);
            assert.equal(result1, 'b / c')
            assert.equal(result2, 'a / b')
        });
    });
});