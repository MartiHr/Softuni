class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.capacity < 1) {
            throw Error("Not enough space in the collection.");
        }

        let book = {
            bookName,
            bookAuthor,
            payed: false,
        }

        this.books.push(book);
        this.capacity--;

        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }

    payBook(bookName) {
        let book = this.books.find(x => x.bookName == bookName);

        if (!book) {
            throw Error(`${bookName} is not in the collection.`);
        }

        if (book.payed) {
            throw Error(`${bookName} has already been paid.`)
        }

        book.payed = true;
        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName) {
        let book = this.books.find(x => x.bookName == bookName);

        if (!book) {
            throw Error(`The book, you're looking for, is not found.`);
        }

        if (!book.payed) {
            throw Error (bookName + ` need to be paid before removing from the collection.`);
        }

        this.books.filter(x => x == book);
        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor) {
        let result = '';

        if (!bookAuthor) {
            result = `The book collection has ${this.capacity} empty spots left.`;
            this.books
                .sort((a, b) => a.bookName.localeCompare(b.bookName))
                .forEach(x => result += `\n${x.bookName} == ${x.bookAuthor} - ${x.payed ? 'Has Paid' : 'Not Paid'}.`)
        } else {
            let booksOfAuthor = this.books.filter(x => x.bookAuthor == bookAuthor);

            if (booksOfAuthor.length < 1) {
                throw Error(`${bookAuthor} is not in the collection.`);
            }

            booksOfAuthor
                .sort((a, b) => a.bookName.localeCompare(b.bookName))
                .forEach(x => result += `${x.bookName} == ${x.bookAuthor} - ${x.payed ? 'Has Paid' : 'Not Paid'}.\n`);

            result.trimEnd();
        }

        return result.trimEnd();
    }
}

const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics());
