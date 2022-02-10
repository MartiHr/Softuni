function rotateArray(stringArr, rotations) {
    for (let i = 0; i < rotations; i++) {
        stringArr.unshift(stringArr.pop())
    }

    console.log(stringArr.join(' '));
}