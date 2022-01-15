function equalNeighbous(matrix) {
    
    let pairsCount = 0;

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            
            let currentValue = matrix[i][j];
            let bottomValue = null;

            if (i + 1 < matrix.length) {
                bottomValue = matrix[i + 1][j];
            }

            let rightValue = null;

            if (j + 1 < matrix[i].length) {
                rightValue =  matrix[i][j + 1];
            }
            
            if (currentValue === bottomValue) {
                pairsCount++;
            }
            
            if (currentValue === rightValue) {
                pairsCount++;
            }
        }
    }

    return pairsCount;
}