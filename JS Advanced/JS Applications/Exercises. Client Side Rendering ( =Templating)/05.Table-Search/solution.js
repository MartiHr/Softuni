import { render } from "../node_modules/lit-html/lit-html.js"

import { studentsTemplate } from "./studentsTemplate.js";

solve();
function solve() {
    document.querySelector('#searchBtn').addEventListener('click', onClick);
    const tbodyElement = document.querySelector('tbody');

    update();

    async function onClick(e) {
        e.preventDefault();

        let searchFieldElement = document.getElementById('searchField');

        update(searchFieldElement.value);

        searchFieldElement.value = '';
    }

    async function update(text = '') {
        let students = await getStudents();
        let template = studentsTemplate(students, text);

        render(template, tbodyElement);
    }

    function getStudents() {
        return fetch('http://localhost:3030/jsonstore/advanced/table')
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
}