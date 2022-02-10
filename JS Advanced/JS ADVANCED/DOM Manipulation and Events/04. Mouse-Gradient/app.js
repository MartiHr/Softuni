function attachGradientEvents() {

    let gradientBoxElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    const gradientMouseOverHandler = (e) => {
        let percent = Math.trunc(e.offsetX / (e.target.clientWidth - 1) * 100);

        resultElement.textContent = `${percent}%`;
    };

    const gradientMouseOutHandler = (e) => {
        resultElement.textContent = '';
    };

    gradientBoxElement.addEventListener('mousemove', gradientMouseOverHandler);
    gradientBoxElement.addEventListener('mouseout', gradientMouseOutHandler);
}