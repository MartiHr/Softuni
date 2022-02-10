function search() {

    let townElements = Array.from(document.querySelectorAll('#towns li'));
    let searchTextElement = document.getElementById('searchText');

    let searchText = searchTextElement.value;

    let matches = 0;

    for (const townElement of townElements) {
        if (townElement.textContent.includes(searchText) && searchText !== '') {
            townElement.style.fontWeight = 'bold';
            townElement.style.textDecoration = 'underline';
            matches++;
        } else {
            townElement.style.fontWeight = 'normal';
            townElement.style.textDecoration = 'none';
        }
    }

    let countElement = document.getElementById('result');
    countElement.textContent = `${matches} matches found`
}
