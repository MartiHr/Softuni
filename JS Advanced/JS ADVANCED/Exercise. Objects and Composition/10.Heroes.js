function heroes() {
    
    let heroCreator = {
        mage(name){
            let mage = {
                name,
                health: 100,
                mana: 100,
                cast(spell){
                    this.mana--;
                    console.log(`${this.name} cast ${spell}`);
                },
            }

            return mage;
        },
        fighter(name){
            let figher = {
                name,
                health: 100,
                stamina: 100,
                fight(){
                    this.stamina--;
                    console.log(`${this.name} slashes at the foe!`);
                },
            }

            return figher;
        },
    }

    return heroCreator;
}

// let create =heroes();
// const scorcher = create.mage('Scorcher');
// scorcher.cast('fireball')
// scorcher.cast('thunder')
// scorcher.cast('light')
// const scorcher2 = create.fighter('Scorcher 2');
// scorcher2.fight()
// console.log(scorcher2.stamina);
// console.log(scorcher.mana);