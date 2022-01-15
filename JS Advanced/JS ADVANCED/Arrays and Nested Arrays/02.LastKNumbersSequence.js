function numberSequence(n, k) {
    
    let arr = [1];

    for (let i = 1; i < n; i++) {
        
        let value = 0;

        for (let j = i - 1; j > i - 1 - k; j--) {
           
            if (j < 0) {
                continue;
            }
            
            value += arr[j];
        }

        arr[i] = value;
    }

    return arr;
}