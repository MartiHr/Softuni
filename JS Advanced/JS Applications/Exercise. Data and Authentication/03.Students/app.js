function attachEvents() {
    const baseUrl = `http://localhost:3030/jsonstore/collections/students`;

    const tbodyElement = document.querySelector('tbody');
    const submitButtonElement = document.getElementById('submit');

    const [firstNameElement, lastNameElement, facultyNumberElement, gradeElement] =
        document.querySelectorAll('input');

    try {
        displayStudents();
        submitButtonElement.addEventListener('click', onSumbmitButtonClick);

    } catch (error) {
        alert('Error')
    }

    async function onSumbmitButtonClick(e) {
        e.preventDefault();

        if (firstNameElement.value && lastNameElement.value
            && facultyNumberElement.value && gradeElement.value) {
            let data = {
                firstName: firstNameElement.value,
                lastName: lastNameElement.value,
                facultyNumber: facultyNumberElement.value,
                grade: 4.99,
            }

            const res = await fetch(baseUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data),
            });

            if (res.status != 200) {
                alert('Error')
            }

            firstNameElement.value = '';
            lastNameElement.value = '';
            facultyNumberElement.value = '';
            gradeElement.value = '';

            displayStudents();
        } else {
            alert('Error');
        }
    }

    async function displayStudents() {
        tbodyElement.innerHTML = '';
        
        let students = await fetchStudents(baseUrl);

        for (const student of students) {
            let studentRowElement = createStudentRowElement(student);
            tbodyElement.append(studentRowElement);
        }
    }

    function createStudentRowElement(student) {
        let trElement = document.createElement('tr');

        let firstNameTd = createElementWithText('td', student.firstName);
        trElement.append(firstNameTd);

        let lastNameTd = createElementWithText('td', student.lastName);
        trElement.append(lastNameTd);

        let facultyNumberTd = createElementWithText('td', student.facultyNumber);
        trElement.append(facultyNumberTd);

        let gradeTd = createElementWithText('td', student.grade);
        trElement.append(gradeTd);

        return trElement;
    }

    function createElementWithText(type, text) {
        let element = document.createElement(type);
        element.textContent = text;

        return element;
    }

    async function fetchStudents(url) {
        let res = await fetch(url);

        if (res.status != 200) {
            throw new Error();
        }

        let data = await res.json();

        return Object.values(data);
    }
}

attachEvents();