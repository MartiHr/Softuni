import { html } from "../../node_modules/lit-html/lit-html.js"
import { getUserData } from "../util.js";

const navigationTemplate = (isAuthenticated) => {
    return html` 
    <nav>
    <img src="./images/headphones.png">
    <a href="/">Home</a>
        <ul>
            <!--All user-->
            <li><a href="/catalog">Catalog</a></li>
            <li><a href="/search">Search</a></li>
            ${!isAuthenticated
                ? html` 
                    <!--Only guest-->
                    <li><a href="/login">Login</a></li>
                    <li><a href="/register">Register</a></li>`
                : html `
                    <!--Only user-->
                    <li><a href="/create">Create Album</a></li>
                    <li><a href="/logout">Logout</a></li>
                `
            }
        </ul>
    </nav>`
}

export const navigationView = (ctx) => {
    const isAuthenticated = Boolean(getUserData());
    return navigationTemplate(isAuthenticated);
} 