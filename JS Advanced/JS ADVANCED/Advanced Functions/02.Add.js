function solution(number) {
    
    function add(a, b) {
        return a + b;
    }

    return add.bind(this, number);
}


let add = solution(5);
console.log(add(2));
console.log(add(3));