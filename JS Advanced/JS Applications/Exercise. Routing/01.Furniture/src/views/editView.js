import { getItemById, updateItemById } from '../api/data.js';
import { html } from '../library.js'

export const editTemplate = (onSubmit, errorMsg, errors, item) => {
    return html` 
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Edit Furniture</h1>
            <p>Please fill all fields.</p>
        </div>
    </div>
    ${errorMsg ? html`<div class="form-group error">${errorMsg}</div>` : null}
    <form @submit=${onSubmit}>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-make">Make</label>
                    <input class="form-control${errors ? (!errors.make ? ' is-valid' : ' is-invalid') : ''}" id="new-make"
                        type="text" name="make" .value=${item.make}>
                </div>
                <div class="form-group has-success">
                    <label class="form-control-label" for="new-model">Model</label>
                    <input class="form-control${errors ? (!errors.model ? ' is-valid' : ' is-invalid') : ''}" id="new-model"
                        type="text" name="model" .value=${item.model}>
                </div>
                <div class="form-group has-danger">
                    <label class="form-control-label" for="new-year">Year</label>
                    <input class="form-control${errors ? (!errors.year ? ' is-valid' : ' is-invalid') : ''}" id="new-year"
                        type="number" name="year" .value=${item.year}>
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-description">Description</label>
                    <input class="form-control${errors ? (!errors.description ? ' is-valid' : ' is-invalid') : ''}"
                        id="new-description" type="text" name="description" .value=${item.description}>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-price">Price</label>
                    <input class="form-control${errors ? (!errors.price ? ' is-valid' : ' is-invalid') : ''}" id="new-price"
                        type="number" name="price" .value=${item.price}>
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-image">Image</label>
                    <input class="form-control${errors ? (!errors.image ? ' is-valid' : ' is-invalid') : ''}" id="new-image"
                        type="text" name="img" .value=${item.img}>
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-material">Material (optional)</label>
                    <input class="form-control" id="new-material" type="text" name="material" .value=${item.material}>
                </div>
                <input type="submit" class="btn btn-primary" value="Edit" />
            </div>
        </div>
    </form>`;
}

export function editView(ctx) {
    update('', null);

    async function update(errorMsg, errors) {
        let item = await getItemById(ctx.params.id);
        ctx.render(editTemplate(onSubmit, errorMsg, errors, item));
    }

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);

        let data = {
            make: formData.get('make'),
            model: formData.get('model'),
            year: Number(formData.get('year')),
            description: formData.get('description'),
            price: Number(formData.get('price')),
            img: formData.get('img'),
            material: formData.get('material'),
        }

        let errMsg = '';
        let errors = {
            make: false,
            model: false,
            year: false,
            description: false,
            price: false,
            img: false,
            material: false,
        };

        try {
            let missingFields = false;
            for (const key in data) {
                if (!data[key] && key != 'material') {
                    missingFields = true;
                    errors[key] = true;
                }
            }
            if (missingFields) {
                if (!errMsg) {
                    errMsg = 'Fill in all input boxes';
                }
            }

            if (data.make.length < 4) {
                errors.make = true;
                if (!errMsg) {
                    errMsg = 'Make must be at least 4 characters long.';
                }
            }

            if (data.model.length < 4) {
                errors.model = true;
                if (!errMsg) {
                    errMsg = 'Model must be at least 4 characters long.';
                }
            }

            if (data.year <= 1950 || data.year >= 2050) {
                errors.year = true;
                if (!errMsg) {
                    errMsg = 'Year must be between 1950 and 2050.';
                }
            }

            if (data.description <= 10) {
                errors.description = true;
                if (!errMsg) {
                    errMsg = 'Description must be more than 10 characters long.';
                }
            }

            if (data.price <= 0) {
                errors.price = true;
                if (!errMsg) {
                    errMsg = 'Price must be a positive number.';
                }
            }

            if (errMsg) {
                throw {
                    message: errMsg,
                    errors
                };
            }

            update();

            const result = await updateItemById(ctx.params.id, data);
            ctx.updateUserNav();
            ctx.page.redirect(`/details/${result._id}`);
        } catch (err) {
            update(err.message, err.errors);
        }
    }
}
