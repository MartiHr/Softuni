class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {
        for (const vegetable of vegetables) {

            let [type, quantity, price] = vegetable.split(' ');
            quantity = Number(quantity);
            price = Number(price);

            let vegetableObject = this.availableProducts.find(x => x.type == type);

            if (!vegetableObject) {
                vegetableObject = { type, quantity: 0, price: 0 };
                this.availableProducts.push(vegetableObject);
            }

            vegetableObject.quantity += quantity;
            let currentPrice = vegetableObject.price;
            vegetableObject.price = Math.max(currentPrice, price);
        }

        let result = 'Successfully added ';
        result += this.availableProducts.map(x => x.type).join(', ');

        return result;
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0;

        for (const selectedProduct of selectedProducts) {
            let [type, quantity] = selectedProduct.split(' ');

            let product = this.availableProducts.find(x => x.type == type);

            if (!product) {
                throw Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            if (quantity > product.quantity) {
                throw Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            let price = quantity * product.price;
            totalPrice += price;
            product.quantity -= quantity;
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
    }

    rottingVegetable(type, quantity) {
        let product = this.availableProducts.find(x => x.type == type);

        if (!product) {
            throw `${type} is not available in the store.`;
        }

        if (quantity > product.quantity) {
            product.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        }

        product.quantity -= quantity;
        return `Some quantity of the ${type} has been removed.`;
    }

    revision() {
        let result = "Available vegetables:";
        this.availableProducts
            .sort((a, b) => a.price - b.price)
            .forEach(x => result += `\n${x.type}-${x.quantity}-$${x.price}`);
        result += `\nThe owner of the store is ${this.owner}, and the location is ${this.location}.`;
        
        return result;
    }
}