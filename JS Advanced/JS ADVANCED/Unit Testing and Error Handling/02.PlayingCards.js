function cardFactory(face, suit) {

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
        toString(){
            return `${face}${suits[suit]}`;
        }
    }

    return cardObject;
}

// console.log(cardFactory('2', 'C').toString());