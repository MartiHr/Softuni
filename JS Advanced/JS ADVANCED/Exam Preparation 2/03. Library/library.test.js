const assert = require('chai').assert;
const library = require("./library");

describe("Library", function () {

    describe("Calc price of book", function () {
        it("Catches wrong input types", function () {
            assert.throw(() => library.calcPriceOfBook(5, 5), 'Invalid input');
            assert.throw(() => library.calcPriceOfBook('5', '5'), 'Invalid input');
        });

        it("Correct behaviour for year > 1980", function () {
            let result = library.calcPriceOfBook('abc', 2000);
            assert.equal(result, `Price of abc is 20.00`)
        });

        it("Correct behaviour for year <= 1980", function () {
            let result = library.calcPriceOfBook('abc', 1980);
            assert.equal(result, `Price of abc is 10.00`)
        });
    });

    describe("Find book", function () {
        it("Check for a zero-length array", function () {
            assert.throw(() => library.findBook([], 'abc'), "No books currently available");
        });

        it("Checks for a book that is present", function () {
            let result = library.findBook(['abc', 'ahfghg', 'fdsf'], 'abc');
            assert.equal(result, 'We found the book you want.')
        });

        it("Checks for a book that is not present", function () {
            let result = library.findBook(['abc', 'ahfghg', 'fdsf'], 'Harry Potter');
            assert.equal(result, 'The book you are looking for is not here!')
        });
    });

    describe("Arrange the books", function () {
        it("Throws error for wrong input type", function () {
            assert.throw(() => library.arrangeTheBooks('a'), 'Invalid input');
            assert.throw(() => library.arrangeTheBooks(-1), 'Invalid input');
        });

        it("Arranges books when there is enough space", function () {
            let result = library.arrangeTheBooks(20);
            assert.equal(result, 'Great job, the books are arranged.');
        });

        it("Arranges books when there is exactly enough space", function () {
            let result = library.arrangeTheBooks(40);
            assert.equal(result, 'Great job, the books are arranged.');
        });

        it("Does not arrange books when there is not enough space", function () {
            let result = library.arrangeTheBooks(50);
            assert.equal(result, 'Insufficient space, more shelves need to be purchased.');
        });
    });
});