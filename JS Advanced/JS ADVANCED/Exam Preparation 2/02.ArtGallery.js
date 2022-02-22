class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = { 'picture': 200, 'photo': 50, 'item': 250 };
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(articleModel, articleName, quantity) {
        if (!this.possibleArticles[articleModel.toLowerCase()]) {
            throw Error('This article model is not included in this gallery!');
        }

        let article = this.listOfArticles.find(x => x.articleName === articleName)
        if (article) {
            article.quantity += quantity;
            return;
        }

        this.listOfArticles.push({ articleModel: articleModel.toLowerCase(), articleName, quantity });
        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`
    }

    inviteGuest(guestName, personality) {
        let guest = this.guests.find(x => x.guestName === guestName)

        if (guest) {
            throw Error(`${guestName} has already been invited.`)
        }

        let newGuest = {
            guestName,
            points: personality == 'Vip' ? 500 : personality == 'Middle' ? 250 : 50,
            purchaseArticle: 0
        };

        this.guests.push(newGuest);

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName) {
        let article = this.listOfArticles.find(x => x.articleName === articleName)

        if (!article || article.articleModel !== articleModel) {
            throw Error('This article is not found.');
        }

        if (article.quantity === 0) {
            return `The ${articleName} is not available.`;
        }

        let guest = this.guests.find(x => x.guestName === guestName);

        if (!guest) {
            return `This guest is not invited.`;
        }

        let requiredPoints = this.possibleArticles[article.articleModel];

        if (guest.points < requiredPoints) {
            return `You need to more points to purchase the article.`;
        } else {
            guest.points -= requiredPoints;
            article.quantity--;
            guest.purchaseArticle++;
        }

        return `${guestName} successfully purchased the article worth ${requiredPoints} points.`;
    }

    showGalleryInfo(criteria) {
        let result = '';

        if (criteria == 'article') {
            result = 'Articles information:'
            this.listOfArticles.forEach(x => result += `\n${x.articleModel} - ${x.articleName} - ${x.quantity}`);
        } else if (criteria == 'guest') {
            result = 'Guests information:'
            this.guests.forEach(x => result += `\n${x.guestName} - ${x.purchaseArticle}`);
        }

        return result;
    }
}