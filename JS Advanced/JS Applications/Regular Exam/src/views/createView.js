import { html } from "../../node_modules/lit-html/lit-html.js";
import { createPet } from "../api/petService.js";

const createTemplate = (createHandler) => {
    return html`
     <section id="createPage">
            <form class="createForm" @submit=${createHandler}>
                <img src="./images/cat-create.jpg">
                <div>
                    <h2>Create PetPal</h2>
                    <div class="name">
                        <label for="name">Name:</label>
                        <input name="name" id="name" type="text" placeholder="Max">
                    </div>
                    <div class="breed">
                        <label for="breed">Breed:</label>
                        <input name="breed" id="breed" type="text" placeholder="Shiba Inu">
                    </div>
                    <div class="Age">
                        <label for="age">Age:</label>
                        <input name="age" id="age" type="text" placeholder="2 years">
                    </div>
                    <div class="weight">
                        <label for="weight">Weight:</label>
                        <input name="weight" id="weight" type="text" placeholder="5kg">
                    </div>
                    <div class="image">
                        <label for="image">Image:</label>
                        <input name="image" id="image" type="text" placeholder="./image/dog.jpeg">
                    </div>
                    <button class="btn" type="submit">Create Pet</button>
                </div>
            </form>
        </section>`;
}

export const createView = (ctx) => {
    ctx.render(createTemplate(createHandler.bind(null, ctx)));
}

async function createHandler(ctx, e) {
    e.preventDefault();

    const fieldsDataObject = Object.fromEntries(new FormData(e.currentTarget));

    if (Object.values(fieldsDataObject).some(field => !field)) {
        return alert('Fill in all input boxes');
    }

    await createPet(fieldsDataObject);

    ctx.page.redirect('/');
}