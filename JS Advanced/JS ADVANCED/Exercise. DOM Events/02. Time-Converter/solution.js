function attachEventsListeners() {

    let buttonElements = Array.from(document.querySelectorAll('input[type="button"]'))
        .forEach(x => x.addEventListener('click', convertEvent));

    let inputElements = Array.from(document.querySelectorAll('input[type="text"]'));

    function convertEvent(e) {
        let inputNumber =
            Number(e.target.parentElement.querySelector('input[type="text"]').value);

        let inputType = e.target.id;
        let outputObject = convert(inputNumber, inputType);

        inputElements[0].value = outputObject.days;
        inputElements[1].value = outputObject.hours;
        inputElements[2].value = outputObject.minutes;
        inputElements[3].value = outputObject.seconds;
    };

    function convert(inputNumber, inputType) {

        let outputObject = {};

        let result = '';

        switch (inputType) {
            case 'daysBtn':
                outputObject.days = inputNumber;
                outputObject.hours = inputNumber * 24;
                outputObject.minutes = inputNumber * 24 * 60;
                outputObject.seconds = inputNumber * 24 * 60 * 60;
                break;
            case 'hoursBtn':
                outputObject.days = inputNumber / 24;
                outputObject.hours = inputNumber;
                outputObject.minutes = inputNumber * 60;
                outputObject.seconds = inputNumber * 60 * 60;
                break;
            case 'minutesBtn':
                outputObject.days = inputNumber / 60 / 24;
                outputObject.hours = inputNumber / 60;
                outputObject.minutes = inputNumber;
                outputObject.seconds = inputNumber * 60;
                break;
            case 'secondsBtn':
                outputObject.days = inputNumber / 24 / 60 / 60;
                outputObject.hours = inputNumber / 60 / 60;
                outputObject.minutes = inputNumber / 60;
                outputObject.seconds = inputNumber;
                break;
        }

        return outputObject;
    }
}