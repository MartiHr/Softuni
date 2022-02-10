function solution(params) {

    let result = '';

    return {
        append(string) {
            result += string;
        },  
        removeStart(n) {
            result = result.substring(n);
        },
        removeEnd(n) {
            result = result.substring(0, result.length - n);
        },
        print() {
            console.log(result);
        }
    };
}

let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();