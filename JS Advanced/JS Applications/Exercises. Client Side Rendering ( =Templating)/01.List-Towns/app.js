import { render } from '../node_modules/lit-html/lit-html.js';
import { townsTemplate } from './towns-template.js';

const loadTownsButtonElements = document.getElementById('btnLoadTowns');
const townsInputElement = document.getElementById('towns');
const rootElement = document.getElementById('root');

loadTownsButtonElements.addEventListener('click', (e) => {
    e.preventDefault();
    if (townsInputElement.value) {
        let townsData = townsInputElement.value.split(', ');
        updateTowns(townsData);
    }
});

function updateTowns(data) {
    render(townsTemplate(data), rootElement);
}