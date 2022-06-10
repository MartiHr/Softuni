import { render } from "../../node_modules/lit-html/lit-html.js"

const contentElement = document.getElementById('content');

export const renderMiddleware = (ctx, next) => {
    ctx.render = (template) => render(template, contentElement);
    
    next();
}