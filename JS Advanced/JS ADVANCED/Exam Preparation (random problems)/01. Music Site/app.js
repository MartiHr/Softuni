window.addEventListener('load', solve);

function solve() {
    let addButtonElement = document.getElementById('add-btn');

    addButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let [genreElement, nameOfSongElement, authorElement, dateElement]
            = document.querySelectorAll('input');

        if (!genreElement.value || !nameOfSongElement.value || !authorElement.value || !dateElement.value) {
            return;
        }

        let mainDivElement = document.querySelector('div[class="all-hits-container"]');

        let divElement = document.createElement('div');
        divElement.classList.add('hits-info');

        let imgElement = document.createElement('img');
        imgElement.src = "./static/img/img.png";
        divElement.appendChild(imgElement);

        let h2GenreElement = document.createElement('h2');
        h2GenreElement.textContent = `Genre: ${genreElement.value}`;
        divElement.appendChild(h2GenreElement);

        let h2NameElement = document.createElement('h2');
        h2NameElement.textContent = `Name: ${nameOfSongElement.value}`;
        divElement.appendChild(h2NameElement);

        let h2AuthorElement = document.createElement('h2');
        h2AuthorElement.textContent = `Author: ${authorElement.value}`;
        divElement.appendChild(h2AuthorElement);

        let h3DateElement = document.createElement('h3');
        h3DateElement.textContent = `Date: ${dateElement.value}`;
        divElement.appendChild(h3DateElement);

        let saveButtonElement = document.createElement('button');
        saveButtonElement.classList.add('save-btn');
        saveButtonElement.textContent = 'Save song';
        divElement.appendChild(saveButtonElement);
        
        let likeButtonElement = document.createElement('button');
        likeButtonElement.classList.add('like-btn');
        likeButtonElement.textContent = 'Like song';
        divElement.appendChild(likeButtonElement);

        let deleteButtonElement = document.createElement('button');
        deleteButtonElement.classList.add('delete-btn');
        deleteButtonElement.textContent = 'Delete';
        divElement.appendChild(deleteButtonElement);

        mainDivElement.appendChild(divElement);

        genreElement.value = '';
        nameOfSongElement.value = '';
        authorElement.value = '';
        dateElement.value = '';

        likeButtonElement.addEventListener('click', (e) => {
            let totalLikesElement = document.querySelector('div[class="likes"] p');
            let newTotalLikes = Number(totalLikesElement.textContent.replace('Total Likes: ', '')) + 1;
            totalLikesElement.textContent = `Total Likes: ${newTotalLikes}`;
            e.target.disabled = true;
        });

        saveButtonElement.addEventListener('click', () => {
            let savedSongsElement = document.querySelector('div [class="saved-container"]');
            mainDivElement.removeChild(divElement);
            
            divElement.removeChild(likeButtonElement);
            divElement.removeChild(saveButtonElement);

            savedSongsElement.appendChild(divElement);
        });

        deleteButtonElement.addEventListener('click', (e) => {
            e.target.parentNode.parentNode.removeChild(e.target.parentNode);
        });
    });
}