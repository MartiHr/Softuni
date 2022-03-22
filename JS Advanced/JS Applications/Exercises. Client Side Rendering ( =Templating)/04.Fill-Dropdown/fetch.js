export function getData() {
    return fetch('http://localhost:3030/jsonstore/advanced/dropdown')
        .then(res => {
            if (res.status != 200) {
                throw new Error();
            }

            return res.json();
        })
        .then(data => {
            return Object.values(data);
        })
        .catch(error => alert('Error'));
}

export function postData(object) {
    return fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(object)
    })
        .then(res => {
            if (res.status != 200) {
                throw new Error();
            }

            return res.json();
        })
        .then(data => {
            return Object.values(data);
        })
        .catch(error => alert('Error'));
}