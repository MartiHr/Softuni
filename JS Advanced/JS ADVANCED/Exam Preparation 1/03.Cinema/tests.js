let assert = require('chai').assert;
const { REPL_MODE_SLOPPY } = require('repl');
let { Repository } = require("./solution.js");

describe("Test reporistory", function () {
    
    describe("Initialization", function () {
        it("Should add properties on initialization", function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let repo = new Repository(properties);

            assert.property(repo, 'props');
            assert.deepEqual(repo.props, properties);
        });

        it("Should have property data initialization", function () {
            let repo = new Repository();

            assert.property(repo, 'data');
            assert.isTrue(repo.data instanceof Map);
        });
    });

    describe("Get count", function () {
       
        it("Should get the positive number of stored entities", function () {
            let repo = new Repository();
           
            repo.data.set('a', 'b');

            assert.equal(repo.count, 1);
        });

        it("Should get the zero number of stored entities", function () {
            let repo = new Repository();

            assert.equal(repo.count, 0);
        });
    });

    describe("Add entity", function () {
        it("Adds entity to data correctly", function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            
            let repo = new Repository(properties);

            let entity = {
                name: "string",
                age: 5,
                birthday: new Date(1998, 0, 7)
            }

            assert.equal(repo.add(entity), 0);
            assert.equal(repo.add(entity), 1);
            assert.doesNotThrow(() => repo.add(entity));    
            assert.equal(repo.data.get(0), entity);
            assert.equal(repo.data.get(1), entity);
        });

        it("Validates wrong input", function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let repo = new Repository(properties);
            
            //Check missing property
            let entity1 = {
                name: "string",
                age: 5,
            }
            let entity2 = {
                name: "string",
                birthday: new Date(1998, 0, 7)
            }
            let entity3 = {
                age: 5,
                birthday: new Date(1998, 0, 7)
            }

            assert.throw(() => repo.add(entity1), `Property birthday is missing from the entity!`);
            assert.throw(() => repo.add(entity2), `Property age is missing from the entity!`);
            assert.throw(() => repo.add(entity3), `Property name is missing from the entity!`);

            //Check incorrect type

            let entity4 = {
                name: "string",
                age: 5,
                birthday: "object"
            };

            let entity5 = {
                name: "string",
                age: "wrong",
                birthday: new Date(1998, 0, 7)
            };

            let entity6 = {
                name: undefined,
                age: 5,
                birthday: new Date(1998, 0, 7)
            };

            assert.throw(() => repo.add(entity4), `Property birthday is not of correct type!`);
            assert.throw(() => repo.add(entity5), `Property age is not of correct type!`);
            assert.throw(() => repo.add(entity6), `Property name is not of correct type!`);
        });
    });

    describe("Get id", function () {
        it("Returns the correct entity", function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            repo.add(entity);
            assert.equal(repo.getId(0), entity);
        });

        it("Throws error on wrong entity", function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);

            assert.throw(() => repo.getId(0), `Entity with id: 0 does not exist!`);
        });
    });

    describe("Update id", function () {
        it("Replaces the entity with the given id with the new entity", function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            //Wrong behaviour
            assert.throw(() => repo.update(0, entity), "Entity with id: 0 does not exist!")

            //Correct behaviour
            repo.add(entity)

            let entity2 = {
                name: "Gosho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            
            let wrongEntity = {
                name: "Pesho",
                age: '22',
                birthday: new Date(1998, 0, 7)
            };
              
            let wrongEntity2 = {
                name: "Pesho",
                age: 22,
            };

            assert.throw(() => repo.update(0, wrongEntity), )
            assert.throw(() => repo.update(0, wrongEntity));
            assert.throw(() => repo.update(0, wrongEntity2));

            repo.update(0, entity2);
            assert.equal(repo.getId(0), entity2);
        });
    });

    describe("Delete id", function () {
        it("Deletes existing id", function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            
            let repo = new Repository(properties);
           
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            repo.add(entity);
            assert.doesNotThrow(() => repo.del(0));
            assert.equal(repo.count, 0);
        });

        it("Does not delete non-existent id", function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            
            let repo = new Repository(properties);
            assert.throw(() => repo.del(0), 'Entity with id: 0 does not exist!')
        });
    });
});