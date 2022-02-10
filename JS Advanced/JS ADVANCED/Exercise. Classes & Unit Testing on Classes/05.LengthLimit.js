class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        if (this.innerLength - length < 0) {
            this.innerLength = 0
        } else {
            this.innerLength -= length;
        }
    }

    toString(){
        if (this.innerString.length >= this.innerLength) {
            return (this.innerString.slice(0, this.innerLength) + '...');
        }

        if (this.innerString.length == 0) {
            return '...';
        }

        return this.innerString;
    }
}