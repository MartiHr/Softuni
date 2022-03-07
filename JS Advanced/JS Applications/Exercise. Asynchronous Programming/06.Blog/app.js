async function attachEvents() {
    try {
        const [loadButtonElement, viewButtonElement] = document.querySelectorAll('button');
        const selectElement = document.getElementById('posts');

        const postsData = await getPostsData();

        loadButtonElement.addEventListener('click', async (e) => {

            for (const post of postsData) {
                let optionElement = document.createElement('option');
                optionElement.value = post.id;
                optionElement.textContent = post.title;

                selectElement.append(optionElement);
            }
        });
      
        viewButtonElement.addEventListener('click', async (e) => {
            const postTitleElement = document.getElementById('post-title');
            const postDetailsElement = document.getElementById('post-body');
            const commentsElement = document.getElementById('post-comments');

            const commentsData = await getCommentsData();

            if (selectElement.value) {
                let post = postsData.find(x => x.id == selectElement.value);

                postTitleElement.textContent = post.title;
                postDetailsElement.textContent = post.body;
                postDetailsElement.style.paddingLeft = 0;
    
                let neededCommentIds = commentsData.filter(x => x.postId == selectElement.value).map(x => x.id);
    
                commentsElement.innerHTML = '';
                for (const commentId of neededCommentIds) {
                    const neededComment = await getCommentById(commentId);
    
                    let liElement = document.createElement('li');
                    liElement.textContent = neededComment.text;
    
                    commentsElement.append(liElement);
                }
            } 
        });

    } catch (error) {
        alert('Error');
    }

    async function getCommentById(id) {
        const url = `http://localhost:3030/jsonstore/blog/comments/${id}`;
        const res = await fetch(url);

        if (res.status != 200) {
            throw new Error();
        }

        const data = await res.json();

        return data;
    }

    async function getPostsData() {
        const url = `http://localhost:3030/jsonstore/blog/posts`;
        const res = await fetch(url);

        if (res.status != 200) {
            throw new Error();
        }

        const data = await res.json();

        return Object.values(data);
    }

    async function getCommentsData() {
        const url = `http://localhost:3030/jsonstore/blog/comments`;
        const res = await fetch(url);

        if (res.status != 200) {
            throw new Error();
        }

        const data = await res.json();

        return Object.values(data);
    }
}

attachEvents();