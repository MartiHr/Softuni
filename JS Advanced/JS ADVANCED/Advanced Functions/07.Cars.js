function solve(arr){
    const utilityObj = processor();
    for (const input of arr) {
        const cmdArgs = input.split(' ');
        const command = cmdArgs[0];
        const name = cmdArgs[1];

        switch(command) {

            case "create":

                let car;
                if (cmdArgs[2]) {
                    const nameToInheritFrom = cmdArgs[3];
                    utilityObj.createAndInherit(name, nameToInheritFrom);
                    
                } else {

                    utilityObj.create(name);

                }

                break;
            case "set":
                const key = cmdArgs[2];
                const value = cmdArgs[3];
                utilityObj.set(name, key, value);
                break;
            case "print":
                utilityObj.printResult(name);
                break;
        }
    }

    function processor(){
        let objectOfCars = {};

        return {
            create,
            createAndInherit,
            set,
            printResult
        }
        function create(name) {

            objectOfCars[name] = {};
    
        }
    
        function createAndInherit(name, nameToInherit) {
    
            create(name);
            let carObj = objectOfCars[name];
            carObj = Object.setPrototypeOf(carObj,objectOfCars[nameToInherit]);
    
        }
    
        function set(name, key, val) {
    
            objectOfCars[name][key] = val;
    
        }
    
        function printResult(name) {
    
            let print = '';
            const carToPrint = objectOfCars[name];
            for (const car in carToPrint) {
                
                print += `${car}:${carToPrint[car]},`;
    
            }
            console.log(print.slice(0, -1));
        }
    }
}