function lockedProfile() {

    Array.from(document.querySelectorAll('button'))
        .forEach(x => x.addEventListener('click', clickEvent));

    function clickEvent(e) {

        let button = e.target;
        let locked = button.parentElement.querySelector('input[value="lock"]').checked;

        let hiddenDiv = button.parentElement.querySelector('div');

        if (!locked) {
            if (button.textContent === 'Show more') {
                hiddenDiv.style.display = 'block';
                button.textContent = 'Hide it';
            } else {
                hiddenDiv.style.display = 'none';
                button.textContent = 'Show more';
            }
        }
    }

}