const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

const messengerUrl = 'http://localhost:5500/01.Messenger/';

describe('End-to-End tests', async function () {
    this.timeout(6000);

    let browser, page;

    before(async () => {
        browser = await chromium.launch();
        //  Run in headless mode
        //  { headless: false, slowMo: 1000 }
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

    it('Loads loads all comments', async () => {
        await page.goto(messengerUrl);

        await page.click('text=Refresh');

        const messages = await page.$eval("#messages", el => el.value.split('\n'));

        assert.equal(messages[0], 'Spami: Hello, are you there?');
        assert.equal(messages[1], 'Garry: Yep, whats up :?');
        assert.equal(messages[2], 'Spami: How are you? Long time no see? :)');
        assert.equal(messages[3], 'George: Hello, guys! :))');
        assert.equal(messages[4], 'Spami: Hello, George nice to see you! :)))');
    });  

    it('Sends messages', async () => {
        await page.goto(messengerUrl);

        await page.fill('#author', 'Gosho');
        await page.fill('#content', 'Hello there!');

        await page.click('text=Send');
        await page.click('text=Refresh');

        const messages = await page.$eval("#messages", el => el.value.split('\n'));

        assert.equal(messages[0], 'Spami: Hello, are you there?');
        assert.equal(messages[1], 'Garry: Yep, whats up :?');
        assert.equal(messages[2], 'Spami: How are you? Long time no see? :)');
        assert.equal(messages[3], 'George: Hello, guys! :))');
        assert.equal(messages[4], 'Spami: Hello, George nice to see you! :)))');
        assert.equal(messages[5], 'Gosho: Hello there!');
    });  
});