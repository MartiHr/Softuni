import { render } from "../node_modules/lit-html/lit-html.js"

import { catCardsTemplate } from "./catCardsTemplate.js";
import { cats } from "./catSeeder.js";

const sectionElement = document.getElementById('allCats');

let cardsTemplate = catCardsTemplate(cats);

render(cardsTemplate, sectionElement);