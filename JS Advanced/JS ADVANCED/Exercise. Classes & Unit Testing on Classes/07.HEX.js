class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    toString() {
        return '0x' + (this.value.toString(16).toUpperCase());
    }

    plus(number) {
        return new Hex(this.value + Number(number));
    }

    minus(number) {
        return new Hex(this.value - Number(number));
    }

    parse(string) {
        return parseInt(string, 16);
    }
}