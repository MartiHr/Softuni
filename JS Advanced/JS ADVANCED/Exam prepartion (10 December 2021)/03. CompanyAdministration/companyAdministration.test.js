const assert = require('chai').assert;
const companyAdministration = require('./companyAdministration');

describe("Company administration", function () {

    describe("hiringEmployee", function () {
        it("Checks if not programmers", function () {
            assert.throw(() => companyAdministration.hiringEmployee('Gosho', 'Gaymer', 5), `We are not looking for workers for this position.`);
        });

        it("Hires a programmer with 3 or more years of experience", function () {
            let result = companyAdministration.hiringEmployee('Gosho', 'Programmer', 3);
            let result2 = companyAdministration.hiringEmployee('Gosho', 'Programmer', 5);
            assert.equal(result, `Gosho was successfully hired for the position Programmer.`)
            assert.equal(result2, `Gosho was successfully hired for the position Programmer.`)
        });

        it("Does not hire a programmer with less than 3 years of experience", function () {
            let result = companyAdministration.hiringEmployee('Gosho', 'Programmer', 2);
            assert.equal(result, `Gosho is not approved for this position.`);
        });
    });

    describe("calculateSalary", function () {
        it("Check for invalid input", function () {
            assert.throw(() => companyAdministration.calculateSalary('NaN'), 'Invalid hours');
            assert.throw(() => companyAdministration.calculateSalary({}), 'Invalid hours');
            assert.throw(() => companyAdministration.calculateSalary(-5), 'Invalid hours');
        });

        it("Calculates for 1 and 160 hour", function () {
            let result = companyAdministration.calculateSalary(1);
            let result2 = companyAdministration.calculateSalary(160);

            assert.equal(result, 15);
            assert.equal(result2, 2400);
        });

        it("Calculates for more than 160", function () {
            let result = companyAdministration.calculateSalary(161);
            let result2 = companyAdministration.calculateSalary(200);

            assert.equal(result, 3415);
            assert.equal(result2, 4000);
        });
    });

    describe("firedEmployee", function () {
        it("Checks for invalid input", function () {
            assert.throw(() => companyAdministration.firedEmployee('', 5), 'Invalid input');
            assert.throw(() => companyAdministration.firedEmployee('', '5'), 'Invalid input');
            assert.throw(() => companyAdministration.firedEmployee({}, 5), 'Invalid input');
            assert.throw(() => companyAdministration.firedEmployee([], '5'), 'Invalid input');
            assert.throw(() => companyAdministration.firedEmployee([], -1), 'Invalid input');
            assert.throw(() => companyAdministration.firedEmployee([], 0), 'Invalid input');
            assert.throw(() => companyAdministration.firedEmployee(['a'], 1), 'Invalid input');
            assert.throw(() => companyAdministration.firedEmployee(['a', 5], undefined), 'Invalid input');
        });

        it("Removes elements correctly", function () {
            let result = companyAdministration.firedEmployee(['a', 'b', 'c'], 1);
            let result2 = companyAdministration.firedEmployee(['a', 'b'], 1);
            assert.equal(result, 'a, c');
            assert.equal(result2, 'a');
        });
    });
});