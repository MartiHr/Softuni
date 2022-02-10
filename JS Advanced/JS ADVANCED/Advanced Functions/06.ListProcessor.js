function solve(commandArr) {

    function processor() {

        let result = [];

        return {
            add(str) {
                result.push(str);
            },
            remove(str) {
                while (result.includes(str)) {

                    let index = result.indexOf(str);

                    result.splice(index, 1);

                }
            },
            print() {
                console.log(result.join(','));
            },
        };
    }

    const listProcessor = processor();

    commandArr.map((x) => x.split(' ')).forEach(([command, value]) => listProcessor[command](value));
}

//solve(['add hello', 'add again', 'remove hello', 'add again', 'print'])