class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = { 'child': 150, 'student': 300, 'collegian': 500 };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        if (!this.priceForTheCamp[condition]) {
            throw Error('Unsuccessful registration at the camp.')
        }

        if (this.listOfParticipants.some(x => x.name == name)) {
            return (`The ${name} is already registered at the camp.`)
        }

        if (money < this.priceForTheCamp[condition]) {
            return (`The money is not enough to pay the stay at the camp.`)
        }

        let participant = {
            name,
            condition,
            power: 100,
            wins: 0,
        }
        this.listOfParticipants.push(participant);

        return `The ${name} was successfully registered.`
    }

    unregisterParticipant(name) {
        let participant = this.listOfParticipants.find(x => x.name === name);

        if (!participant) {
            throw Error(`The ${name} is not registered in the camp.`)
        }

        this.listOfParticipants = this.listOfParticipants.filter(x => x != participant);

        return `The ${name} removed successfully.`
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        if (typeOfGame === 'WaterBalloonFights') {
            let player1 = this.listOfParticipants.find(x => x.name == participant1);
            let player2 = this.listOfParticipants.find(x => x.name == participant2);

            if (!player1 || !player2) {
                throw Error(`Invalid entered name/s.`);
            }

            if (player1.condition !== player2.condition) {
                throw Error(`Choose players with equal condition.`);
            }

            if (player1.power > player2.power) {
                player1.wins++;
                return `The ${participant1} is winner in the game ${typeOfGame}.`
            } else if (player2.power > player1.power) {
                player2.wins++;
                return `The ${participant2} is winner in the game ${typeOfGame}.`
            } else {
                return `There is no winner.`;
            }

        } else if (typeOfGame === 'Battleship') {
            let player1 = this.listOfParticipants.find(x => x.name == participant1);

            if (!player1) {
                throw Error(`Invalid entered name/s.`);
            }

            player1.power += 20;
            return `The ${participant1} successfully completed the game ${typeOfGame}.`
        }
    }

    toString(){
        let result = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`;
        this.listOfParticipants
            .sort((a, b) => b.wins - a.wins)
            .forEach(x => result += `\n${x.name} - ${x.condition} - ${x.power} - ${x.wins}`);
        
        return result;
    }
}