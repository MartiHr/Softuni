import { render } from "../../node_modules/lit-html/lit-html.js"

import { navigationView } from "../views/navigationView.js";

const headerElement = document.querySelector('header');

export const navigationMiddleware = (ctx, next) => {
    render(navigationView(ctx), headerElement);

    next();
} 

const contentElement = document.getElementById('content');

export const renderMiddleware = (ctx, next) => {
    ctx.render = (template) => render(template, contentElement);
    
    next();
}