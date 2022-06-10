export function startGame(ctx, e) {
    
    let turn = sessionStorage.getItem('turn');

    let targetElement = e.target;

    if (e.target.tagName == 'TD') {
        targetElement = targetElement.firstChild;
    }

    if (!targetElement.classList.contains('fa-diamond')) {
        return;
    }

    let sizeX = Number(sessionStorage.getItem('sizeX'));
    let sizeY = Number(sessionStorage.getItem('sizeY'));

    let canPlace = checkIfCanPlace();

    for (let i = 0; i < sizeX; i++) {
        for (let j = 0; j < sizeY; j++) {
            let item = document.getElementById(`${i}-${j}`);

            if (item.classList.contains('fa-diamond')) {
                canPlace = true;
            }
        }
    }

    if (canPlace) {

        // if (turn =='playerTwo') {
        //     botClick(sizeX, sizeY);
        // }

        let [playerX, playerY] = targetElement.id.split('-');

        targetElement.classList.remove('fa-diamond');
        targetElement.classList.add('fa-chess-queen');

        if (turn == 'playerOne') {
            targetElement.classList.add('player-one');

        } else {
            targetElement.classList.add('player-two');
        }


        blockHandler(playerX, playerY);

        turnHandler(turn);

        //Check for possible next turn
        canPlace = checkIfCanPlace();

        if (!canPlace) {
            let table = document.querySelector('table');
            ctx.page.redirect('/game/end')
        }

        if (canPlace && sessionStorage.getItem('bot') == 'bot' && turn =='playerOne') {
            botClick(sizeX, sizeY);
        }
    }

    function botClick(sizeX, sizeY) {
        let hasPlaced = false;

        while (!hasPlaced) {
            let xPos = randomIntFromInterval(0, sizeX - 1);
            let yPos = randomIntFromInterval(0, sizeY - 1);

            let item = document.getElementById(`${xPos}-${yPos}`);

            if (item.classList.contains('fa-diamond')) {
                hasPlaced = true;
                item.click();
            }
        }
    }

    function randomIntFromInterval(min, max) { // min and max included 
        return Math.floor(Math.random() * (max - min + 1) + min)
    }

    function checkIfCanPlace() {
        let canPlace = false;

        for (let i = 0; i < sizeX; i++) {
            for (let j = 0; j < sizeY; j++) {
                let item = document.getElementById(`${i}-${j}`);

                if (item.classList.contains('fa-diamond')) {
                    canPlace = true;
                }
            }
        }

        return canPlace;
    }

    function turnHandler(turn) {

        const turnElement = document.getElementById('player-turn');

        if (turn == 'playerOne') {
            turnElement.textContent = `Player 2's turn!`;
            turnElement.style.backgroundColor = 'brown';
            sessionStorage.setItem('turn', 'playerTwo');

        } else {
            turnElement.style.backgroundColor = 'royalblue';
            turnElement.textContent = `Player 1's turn!`;
            sessionStorage.setItem('turn', 'playerOne');
        }
    }

    function blockHandler(playerX, playerY) {
        blockHorizontal(playerX);
        blockVertical(playerY);
        blockPrimaryDiagonal(playerX, playerY);
        blockSecondaryDiagonal(playerX, playerY);
    }

    function blockPrimaryDiagonal(playerX, playerY) {

        let deleteX = (playerX - playerY >= 0) ? playerX - playerY : 0;
        let deleteY = (playerY - playerX >= 0) ? playerY - playerX : 0;

        while (deleteX <= sessionStorage.getItem('sizeX') - 1 && deleteY <= sessionStorage.getItem('sizeY') - 1) {
            let item = document.getElementById(`${deleteX}-${deleteY}`);
            if (!item.classList.contains('fa-chess-queen')) {
                item.classList.remove('fa-diamond');
                item.classList.add('fa-circle-xmark');
            }

            deleteX++;
            deleteY++;
        }
    }

    function blockSecondaryDiagonal(playerX, playerY) {

        blockBottomLeft(playerX, playerY)
        blockTopRight(playerX, playerY)
    }

    function blockBottomLeft(playerX, playerY) {
        while (playerY > 0) {
            playerX++;
            playerY--;

            let item = document.getElementById(`${playerX}-${playerY}`);
            if (item && !item.classList.contains('fa-chess-queen')) {
                item.classList.remove('fa-diamond');
                item.classList.add('fa-circle-xmark');
            }
        }
    }

    function blockTopRight(playerX, playerY) {
        while (playerX > 0 || playerY <= sessionStorage.getItem('sizeY')) {
            playerX--;
            playerY++;

            let item = document.getElementById(`${playerX}-${playerY}`);
            if (item && !item.classList.contains('fa-chess-queen')) {
                item.classList.remove('fa-diamond');
                item.classList.add('fa-circle-xmark');
            }
        }
    }

    function blockHorizontal(playerX) {
        for (let i = 0; i < sessionStorage.getItem('sizeY'); i++) {
            //Do not change queen
            let item = document.getElementById(`${playerX}-${i}`);
            if (!item.classList.contains('fa-chess-queen')) {
                item.classList.remove('fa-diamond');
                item.classList.add('fa-circle-xmark');
            }
        }
    }

    function blockVertical(playerY) {
        for (let i = 0; i < sessionStorage.getItem('sizeX'); i++) {
            //Do not change queen
            let item = document.getElementById(`${i}-${playerY}`);
            if (!item.classList.contains('fa-chess-queen')) {
                item.classList.remove('fa-diamond');
                item.classList.add('fa-circle-xmark');
            }
        }
    }
}