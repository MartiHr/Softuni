function checkForMagical(matrix) {

    let baseSumOfCells = matrix[0].reduce((a, b) => a + b);

    for (let i = 0; i < matrix.length; i++) {
        
        let rowSum = 0;
        let colSum = 0;

        for (let j = 0; j < matrix.length; j++) {
            rowSum += matrix[i][j];
            colSum += matrix[j][i];
        }

        if (rowSum !== baseSumOfCells || colSum !== baseSumOfCells) {
            return false;
        }
    }

    return true;
}