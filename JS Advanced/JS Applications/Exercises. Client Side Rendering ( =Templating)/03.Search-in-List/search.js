import { render } from "../node_modules/lit-html/lit-html.js";
import { towns } from "./towns.js";
import { townsTemplate } from "./townsTemplate.js";

const townsDivElement = document.getElementById('towns');
const matchesCountElement = document.getElementById('result');
const searchButtonElement = document.querySelector('button');
const searchTextElement = document.getElementById('searchText');

updateTowns();

searchButtonElement.addEventListener('click', search);

function search(e) {
    e.preventDefault();

    let searchText = searchTextElement.value;

    updateTowns(searchText);
    updateMatchesCount(searchText);
}

function updateTowns(searchText = '') {
    const filledTemplate = townsTemplate(towns, searchText);

    render(filledTemplate, townsDivElement);
}

function updateMatchesCount(searchText) {
    let matches = towns.filter(town => searchTownsForText(town, searchText)).length;

    matchesCountElement.textContent = matches ? `${matches} matches found` : '';
}

export function searchTownsForText(town, searchText) {
    return searchText && town.toLowerCase().includes(searchText.toLowerCase());
}