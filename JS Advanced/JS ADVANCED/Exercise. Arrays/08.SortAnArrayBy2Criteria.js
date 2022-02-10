function sort(stringArr) {
    stringArr.sort((a, b) => a.length - b.length || a.localeCompare(b));

    console.log(stringArr.join('\n'));
}

sort([`alpha`,
    `beta`,
    `gamma`])