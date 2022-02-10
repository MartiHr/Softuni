function getArticleGenerator(input) {
    let articles = input;

    return function showArticle() {

        let divElement = document.getElementById('content');

        if (articles.length > 0) {
            let articleElement = document.createElement('article');
            articleElement.textContent = articles.shift();
            divElement.appendChild(articleElement)
        }
    }
}