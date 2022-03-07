const divGuestElement = document.getElementById('guest');
const divUserElement = document.getElementById('user');
const catchesElement = document.getElementById('catches');
const loadButtonElement = document.querySelector('button[class="load"]');

const addCatchFieldsetElement = document.querySelector('form[id="addForm"] fieldset');
const addButtonElement = addCatchFieldsetElement.querySelector('button');

const spanElement = document.querySelector('span');

if (localStorage.getItem('email')) {
    divUserElement.style.display = 'inline';
    divGuestElement.style.display = 'none';
    spanElement.textContent = localStorage.getItem('email');

    addButtonElement.disabled = false;
} else {
    divGuestElement.style.display = 'inline';
    divUserElement.style.display = 'none';
    spanElement.textContent = 'guest';

    addButtonElement.disabled = true;
}

const logoutButtonElement = document.getElementById('logout');

logoutButtonElement.addEventListener('click', (e) => {
    localStorage.clear()
    window.location.href = 'index.html';
});

loadButtonElement.addEventListener('click', loadCathes);
addButtonElement.addEventListener('click', addCatch)

function addCatch(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/data/catches';

    const [anglerElement, weightElement, speciesElement,
        locationElement, baitElement, captureTimeElement] = addCatchFieldsetElement.querySelectorAll('input');

    if (!e.target.disabled) {
        if (anglerElement.value && weightElement.value
            && speciesElement.value
            && locationElement.value
            && baitElement.value && captureTimeElement.value) {

            let data = {
                "angler": anglerElement.value,
                "weight": weightElement.value,
                "species": speciesElement.value,
                "location": locationElement.value,
                "bait": baitElement.value,
                "captureTime": captureTimeElement.value,
                "email": localStorage.getItem('email'),
            }

            fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': localStorage.getItem('accessToken'),
                },
                body: JSON.stringify(data),
            })
                .catch(error => alert('Error'))

            anglerElement.value = '';
            weightElement.value = '';
            speciesElement.value = '';
            locationElement.value = '';
            baitElement.value = '';
            captureTimeElement.value = '';

            alert('Successfully added catch');
        } else {
            alert('Fill in all input boxes.')
        }
    }

}

function loadCathes() {
    const baseUrl = 'http://localhost:3030/data/catches';

    fetch(baseUrl)
        .then(res => {
            if (res.status != 200) {
                throw new Error();
            }

            return res.json();
        })
        .then(data => {
            catchesElement.innerHTML = '';

            Object.values(data)
                .forEach(_catch => {
                    let catchElement = document.createElement('div');
                    catchElement.classList.add('catch');
                    catchElement.innerHTML =
                        `<label>Angler</label>
                        <input type="text" class="angler" value="${_catch.angler}" disabled>
                        <label>Weight</label>
                        <input type="text" class="weight" value="${_catch.weight}" disabled>
                        <label>Species</label>
                        <input type="text" class="species" value="${_catch.species}" disabled>
                        <label>Location</label>
                        <input type="text" class="location" value="${_catch.location}" disabled>
                        <label>Bait</label>
                        <input type="text" class="bait" value="${_catch.bait}" disabled>
                        <label>Capture Time</label>
                        <input type="number" class="captureTime" value="${_catch.captureTime}" disabled>
                        <button class="update" data-id="${_catch._id}" disabled>Update</button>
                        <button class="delete" data-id="${_catch._id}" disabled>Delete</button>`

                    const [anglerElement, weightElement, speciesElement,
                        locationElement, baitElement, captureTimeElement] = catchElement.querySelectorAll('input');
                    const updateButtonElement = catchElement.querySelector('button[class="update"]');
                    const deleteButtonElement = catchElement.querySelector('button[class="delete"]');

                    let storedEmail = localStorage.getItem('email');

                    if (_catch.email == storedEmail && _catch.email) {
                        anglerElement.disabled = false;
                        weightElement.disabled = false;
                        speciesElement.disabled = false;
                        locationElement.disabled = false;
                        baitElement.disabled = false;
                        captureTimeElement.disabled = false;
                        updateButtonElement.disabled = false;
                        deleteButtonElement.disabled = false;
                    }

                    updateButtonElement.addEventListener('click', (e) => {
                        const updateUrl = `${baseUrl}/${e.target.getAttribute('data-id')}`;
                       
                        let data = {
                            "angler": anglerElement.value,
                            "weight": weightElement.value,
                            "species": speciesElement.value,
                            "location": locationElement.value,
                            "bait": baitElement.value,
                            "captureTime": captureTimeElement.value,
                            "email": localStorage.getItem('email'),
                        }

                        fetch(updateUrl, {
                            method: 'PUT',
                            headers: {
                                'Content-Type': 'application/json',
                                'X-Authorization': localStorage.getItem('accessToken'),
                            },
                            body: JSON.stringify(data),
                        })  
                        .then(res => {
                            if (res.status != 200) {
                                throw new Error();
                            }

                            alert('Updated catch');
                        })
                        .catch(error => 'Error');
                    })

                    deleteButtonElement.addEventListener('click', (e) => {
                        const deleteUrl = `${baseUrl}/${e.target.getAttribute('data-id')}`;
           
                        fetch(deleteUrl, {
                            method: 'DELETE',
                            headers: {
                                'X-Authorization': localStorage.getItem('accessToken'),
                            },
                        })  
                        .then(res => {
                            if (res.status != 200) {
                                throw new Error();
                            }

                            catchesElement.removeChild(catchElement);
                            alert('Removed catch');
                        })
                        .catch(error => 'Error');
                    });

                    catchesElement.append(catchElement);
                });
        })
        .catch(error => console.log('Error'));
}