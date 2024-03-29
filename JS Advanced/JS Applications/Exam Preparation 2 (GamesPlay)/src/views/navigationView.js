import { html } from "../../node_modules/lit-html/lit-html.js";

export const navigationView = (ctx) => {
    return html`  
     <!-- Navigation -->
    <h1><a class="home" href="/">GamesPlay</a></h1>
    <nav>
        <a href="/catalog">All games</a>

        ${ctx.user
            ? html` 
                <div id="user">
                    <a href="/create">Create Game</a>
                    <a href="/logout">Logout</a>
                </div>`
            : html `
                <div id="guest">
                    <a href="/login">Login</a>
                    <a href="/register">Register</a>
                </div>`
        }
    </nav>`
}