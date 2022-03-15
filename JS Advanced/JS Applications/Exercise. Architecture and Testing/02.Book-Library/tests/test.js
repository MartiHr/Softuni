const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

const bookLibraryUrl = 'http://localhost:5500/02.Book-Library/';

const mockData = {
    "d953e5fb-a585-4d6b-92d3-ee90697398a0": {
        "author": "J.K.Rowling",
        "title": "Harry Potter and the Philosopher's Stone"
    },
    "d953e5fb-a585-4d6b-92d3-ee90697398a1": {
        "author": "Svetlin Nakov",
        "title": "C# Fundamentals"
    }
};

describe('End-to-End tests', async function () {
    this.timeout(6000);

    let browser, page;

    before(async () => {
        browser = await chromium.launch({ headless: false, slowMo: 1000 });
        //  Run in headless mode
        //  
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        page = await browser.newPage();
    });

    afterEach(async () => {
        page.close();
    });

    it('Loads loads all books', async () => {
        await page.route('**/jsonstore/collections/books', (route, request) => {
            route.fulfill({
                body: JSON.stringify(mockData),
                status: 200,
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application-json'
                }
            });
        });

        await page.goto(bookLibraryUrl);

        await page.click('text=Load all books');
        const rowsData = await page.$$eval('tbody tr', rows => rows.map(r => r.textContent));

        assert.include(rowsData[0], 'Harry Potter');
        assert.include(rowsData[0], 'Rowling');
        assert.include(rowsData[1], 'C# Fundamentals');
        assert.include(rowsData[1], 'Nakov');
    });

    it('Creates books', async () => {
        await page.goto(bookLibraryUrl);

        await page.fill('input[name=title]', 'Gaymer');
        await page.fill('input[name=author]', 'Gaben');

        const [request] = await Promise.all([
            page.waitForRequest((request) => request.method() == 'POST'),
            page.click('text=Submit')
        ]);
        
        const data = JSON.parse(request.postData());
        assert.equal(data.title, 'Gaymer');
        assert.equal(data.author, 'Gaben');
    });

    it('edit book', async () => {
        await page.goto(bookLibraryUrl);

        await page.click('#loadBooks');

        await page.click('button.editBtn');

        await page.fill('#editForm > input[type=text]:nth-child(4)', 'Harry Potter and the Philosopher\'s Stone edited');
        await page.fill('#editForm > input[type=text]:nth-child(6)', 'J.K.Rowling edited');

        await page.click('#editForm > button')

        await page.click('#loadBooks');

        const books = await page.$$eval('tbody > tr > td', r => r.map(td => td.textContent));

        assert.include(books, 'Harry Potter and the Philosopher\'s Stone edited');
    });

    it('Deletes books', async () => {
        await page.goto(bookLibraryUrl);

        await page.click('#loadBooks');
        
        page.on('dialog', async dialog => {
            await dialog.accept();
        });

        await page.click('button.deleteBtn');

        await page.click('#loadBooks');

        const books = await page.$$eval('tbody > tr > td', r => r.map(td => td.textContent));

        assert.equal(books[0], 'C# Fundamentals');
        assert.equal(books[1], 'Svetlin Nakov');
    });
});