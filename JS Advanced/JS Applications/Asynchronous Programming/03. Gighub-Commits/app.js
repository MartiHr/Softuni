function loadCommits() {
    let inputUserElement = document.getElementById('username'); 
    let inputRepoElement = document.getElementById('repo'); 
	let commitsElement = document.getElementById('commits');

    fetch(`https://api.github.com/repos/${inputUserElement.value}/${inputRepoElement.value}/commits`)
        .then((res) => {
            if (res.status == '404') {
                throw new Error(`${res.status} (Not Found)`);
            }

            return res.json();
        })
        .then((data) => {
            commitsElement.innerHTML = '';

            Object.values(data)
                .forEach(object => {
                    let liElement = document.createElement('li');
                    liElement.textContent = `${object.commit.author.name}: ${object.commit.message}`;
                    
                    commitsElement.append(liElement);
                });
        })
        .catch((error) => {
            commitsElement.innerHTML = '';

            let liElement = document.createElement('li');
            liElement.textContent = `Error: ${error.message}`

            commitsElement.append(liElement);
        });
}