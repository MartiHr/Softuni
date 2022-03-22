import { render } from "../node_modules/lit-html/lit-html.js"

import { getData, postData } from "./fetch.js";
import { optionsTemplate } from "./optionsTemplate.js";

const selectElement = document.getElementById('menu');
const addButtonElement = document.querySelector('input[type="submit"]')
const inputTextElement = document.getElementById('itemText');

updateOptions();

addButtonElement.addEventListener('click', addItem);

async function addItem(e) {
    e.preventDefault();

    if (inputTextElement.value) {
        let dataObject = {
            'text': inputTextElement.value
        }

        await postData(dataObject);
        inputTextElement.value = '';
        updateOptions();
    }
}

async function updateOptions() {
    let data = await getData();
    let template = optionsTemplate(data);

    render(template, selectElement);
}