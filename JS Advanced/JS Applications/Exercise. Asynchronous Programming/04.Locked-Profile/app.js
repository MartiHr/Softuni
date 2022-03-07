function lockedProfile() {

    const mainElement = document.getElementById('main');

    try {
        createProfileCards();
    } catch (error) {
        alert('Error');
    }

    async function createProfileCards() {
        const url = 'http://localhost:3030/jsonstore/advanced/profiles';
        const res = await fetch(url);

        if (res.status != '200') {
            throw Error();
        }

        const data = Object.values(await res.json());


        let number = 1;
        for (const cardObject of data) {
            let cardElement = createProfileCardElement(cardObject.username, cardObject.email, cardObject.age, number++);

            let showMoreButton = cardElement.querySelector('button');

            showMoreButton.addEventListener('click', (e) => {

                let unlockElement = cardElement.querySelectorAll('input')[1];

                if (e.target.textContent == 'Show more') {
                    if (unlockElement.checked) {
                        let divElement = cardElement.querySelector('div');
                        divElement.classList.remove('hiddenInfo');
                        e.target.textContent = 'Show less'
                    }

                } else {
                    if (unlockElement.checked) {
                        let divElement = cardElement.querySelector('div');
                        divElement.classList.add('hiddenInfo');
                        e.target.textContent = 'Show more'
                    }
                }

                
            });

            mainElement.append(cardElement);
        }
    }



    function createProfileCardElement(username, email, age, profileNumber) {
        let divElement = document.createElement('div');
        divElement.classList.add('profile');
        divElement.innerHTML =
            `<img src="./iconProfile2.png" class="userIcon" />
        <label>Lock</label>
        <input type="radio" name="user${profileNumber}Locked" value="lock" checked>
        <label>Unlock</label>
        <input type="radio" name="user${profileNumber}Locked" value="unlock"><br>
        <hr>
        <label>Username</label>
        <input type="text" name="user${profileNumber}Username" value="${username}" disabled readonly />
        <div class="hiddenInfo">
            <hr>
            <label>Email:</label>
            <input type="email" name="user${profileNumber}Email" value="${email}" disabled readonly />
            <label>Age:</label>
            <input type="email" name="user${profileNumber}Age" value="${age}" disabled readonly />
        </div>

        <button>Show more</button>`;

        return divElement;
    }
}