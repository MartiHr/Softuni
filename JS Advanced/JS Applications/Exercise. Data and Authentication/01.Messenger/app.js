function attachEvents() {
    const textAreaElement = document.getElementById('messages');
    const [nameInputElement, messageInputElement, sendButtonElememt, refreshButtonElement]
        = document.querySelectorAll('input');

    const url = 'http://localhost:3030/jsonstore/messenger';


    sendButtonElememt.addEventListener('click', (e) => {
        if (nameInputElement.value && messageInputElement.value) {

            let data = {
                author: nameInputElement.value,
                content: messageInputElement.value,
            };

            fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data),
            })
            .then(res => {
                if (res.status != 200) {
                    throw new Error();
                }

                return res.json();
            })
            .catch(error => alert('Error'));
        } else {
            alert('Error');
        }

        nameInputElement.value = '';
        messageInputElement.value = '';
    });

    refreshButtonElement.addEventListener('click', (e) => {
        fetch(url)
        .then(res => {
            if (res.status != 200) {
                throw new Error();
            }

            return res.json();
        })
        .then(data => {
            textAreaElement.textContent = Object.values(data)
                .map(x => `${x.author}: ${x.content}`)
                .join('\n');
        })
        .catch(error => alert('Error'));
    });

}

attachEvents();