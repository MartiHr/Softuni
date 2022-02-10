function printDeckOfCards(cards) {

    function createCard(face, suit) {
        
        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let suits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663',
        }

        if (!validFaces.includes(face)) {
            throw Error('Error');
        }

        if (face != face.toUpperCase() || suit != suit.toUpperCase()) {
            throw Error('Error');
        }

        let cardObject = {
            face,
            suit,
            toString() {
                return `${face}${suits[suit]}`;
            }
        }

        return cardObject;
    }

    try {
        let result = cards.map(x => {
            let card = {};
    
            try {
                if (x.length == 3) {
                    card = createCard('10', x[2]);
                } else {
                    card = createCard(x[0], x[1]);
                }
            } catch (error) {
                throw Error(`Invalid card: ${x}`)
            }
    
            return card;
        }).join(', ');
    
        console.log(result);
    } catch (error) {
        console.log(error.message);
    }
}

// printDeckOfCards(['AS', '10D', 'KH', '2C']);
// printDeckOfCards(['5S', '3D', 'QD', '1C']);
