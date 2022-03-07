async function solution() {

    try {
        const articlesData = await getListData();
        
        const mainElement = document.getElementById('main');

        for (const article of articlesData) {
            let articleElement = await createArticle(article);
    
            mainElement.append(articleElement);
        }
    } catch (error) {
        alert('Error')
    }
  

    async function createArticle(article) {
        let articleElement = document.createElement('div');
        articleElement.classList.add('accordion')
       
        articleElement.innerHTML = ` 
            <div class="head">
                <span>${article.title}</span>
                <button class="button" id="${article._id}">More</button>
            </div>
            <div class="extra">
                <p></p>
            </div>`;

        const buttonElement = articleElement.querySelector('button');
        const divExtraElement = articleElement.querySelector('div[class="extra"]');

        buttonElement.addEventListener('click', async (e) => {
            if (buttonElement.textContent == 'More') {
                buttonElement.textContent = 'Less'

                const articleData = await getArticleById(article._id);
                divExtraElement.firstChild.textContent = articleData.content;
                
                divExtraElement.style.display = 'block';
            } else {
                buttonElement.textContent = 'More'
                divExtraElement.style.display = 'none';
            }
        });

        return articleElement;
    }

    async function getArticleById(id) {
        const articleURL = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;
        const res = await fetch(articleURL);

        if (res.status != 200) {
            throw new Error();
        }

        return await res.json();
    }

    async function getListData() {
        const listURL = `http://localhost:3030/jsonstore/advanced/articles/list`;
        const res = await fetch(listURL);

        if (res.status != 200) {
            throw new Error();
        }

        const data = Object.values(await res.json());

        return data;
    }
}

solution();