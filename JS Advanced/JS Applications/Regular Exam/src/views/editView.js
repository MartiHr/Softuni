import { html } from "../../node_modules/lit-html/lit-html.js";
import { getPet, updatePet } from "../api/petService.js";

const editTemplate = (pet, editHandler) => {
    return html`
    <section id="editPage">
        <form class="editForm" @submit=${editHandler}>
            <img src="../../images/editpage-dog.jpg">
            <div>
                <h2>Edit PetPal</h2>
                <div class="name">
                    <label for="name">Name:</label>
                    <input name="name" id="name" type="text" value="${pet.name}">
                </div>
                <div class="breed">
                    <label for="breed">Breed:</label>
                    <input name="breed" id="breed" type="text" value="${pet.breed}">
                </div>
                <div class="Age">
                    <label for="age">Age:</label>
                    <input name="age" id="age" type="text" value="${pet.age}">
                </div>
                <div class="weight">
                    <label for="weight">Weight:</label>
                    <input name="weight" id="weight" type="text" value="${pet.weight}">
                </div>
                <div class="image">
                    <label for="image">Image:</label>
                    <input name="image" id="image" type="text" value="${pet.image}">
                </div>
                <button class="btn" type="submit">Edit Pet</button>
            </div>
        </form>
    </section>`;
}

export const editView = async (ctx) => {
    const pet = await getPet(ctx.params.id);

    ctx.render(editTemplate(pet, editHandler.bind(null, ctx)));
}

async function editHandler(ctx, e) {
    e.preventDefault();

    const fieldsDataObject = Object.fromEntries(new FormData(e.currentTarget));

    if (Object.values(fieldsDataObject).some(field => !field)) {
        return alert('Fill in all input boxes');
    }

    await updatePet(ctx.params.id, fieldsDataObject);

    ctx.page.redirect(`/details/${ctx.params.id}`);
}