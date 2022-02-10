function create(words) {
   
    let mainDivElement = document.getElementById('content');

    for (let i = 0; i < words.length; i++) {
        
        let divElement = document.createElement('div');
        
        let pElement = document.createElement('p');
        pElement.style.display = 'none';
        pElement.textContent = words[i];
        divElement.appendChild(pElement);

        divElement.addEventListener('click', (e) => {
            e.target.firstChild.style.display = 'block';
        })

        mainDivElement.appendChild(divElement);
    }
}