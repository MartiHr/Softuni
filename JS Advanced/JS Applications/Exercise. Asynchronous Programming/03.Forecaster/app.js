function attachEvents() {
    const contentElement = document.getElementById('content');
    const locationElement = document.getElementById('location');
    const forecastDivElement = document.getElementById('forecast');
    const getWeatherButtonElement = document.getElementById('submit');
    const currentDivElement = document.getElementById('current');
    const upcomingDivElement = document.getElementById('upcoming');

    const conditions = {
        Sunny: '&#x2600;',
        Partly: '&#x26C5;',
        Overcast: '&#x2601;',
        Rain: '&#x2614;',
    }

    const divErrorElement = document.createElement('div');
    divErrorElement.textContent = 'Error';
    divErrorElement.classList.add('label');
    divErrorElement.style.textAlign = 'center';

    getWeatherButtonElement.addEventListener('click', async (e) => {
        try {
            const location = locationElement.value;
            locationElement.value = '';

            const data = await getWeatherData();
            let soughtObject = data.find(x => x.name == location);
            const conditionsData = await getConditionsData(soughtObject);
            const threeDayConditionsData = await getThreeDayConditionsData(soughtObject);

            if (Array.of(contentElement).some(x => x == divErrorElement)) {
                contentElement.removeChild(divErrorElement);
            }

            currentDivElement.innerHTML = '<div class="label">Current conditions</div>';
            upcomingDivElement.innerHTML = '<div class="label">Three-day forecast</div>';
            forecastDivElement.style.display = 'block';

            let forecastsElement = document.createElement('div');
            forecastsElement.classList.add('forecasts');

            let symbolElement = document.createElement('span');
            symbolElement.classList.add('condition');
            symbolElement.classList.add('symbol');
            symbolElement.innerHTML = conditions[conditionsData.forecast.condition.split(' ')[0]];

            forecastsElement.append(symbolElement);

            let conditionElement = document.createElement('span');
            conditionElement.classList.add('condition');

            let forecastDataElement1 = document.createElement('span');
            forecastDataElement1.classList.add('forecast-data');
            forecastDataElement1.textContent = conditionsData.name;
            conditionElement.append(forecastDataElement1);

            let forecastDataElement2 = document.createElement('span');
            forecastDataElement2.classList.add('forecast-data');
            forecastDataElement2.textContent = `${conditionsData.forecast.low}\°/${conditionsData.forecast.high}\°`;
            conditionElement.append(forecastDataElement2);

            let forecastDataElement3 = document.createElement('span');
            forecastDataElement3.classList.add('forecast-data');
            forecastDataElement3.textContent = conditionsData.forecast.condition;
            conditionElement.append(forecastDataElement3);

            forecastsElement.append(conditionElement);

            currentDivElement.append(forecastsElement);

            let threeDayForecastsElement = document.createElement('div');
            threeDayForecastsElement.classList.add('forecast-info');

            for (const dayCondition of threeDayConditionsData.forecast) {
                let spanUpcomingElement = document.createElement('span');
                spanUpcomingElement.classList.add('upcoming');

                let upSymbolElement = document.createElement('span');
                upSymbolElement.classList.add('symbol');
                upSymbolElement.innerHTML = conditions[dayCondition.condition.split(' ')[0]];;
                spanUpcomingElement.append(upSymbolElement);

                let upDegreesElement = document.createElement('span');
                upDegreesElement.classList.add('forecast-data');
                upDegreesElement.textContent = `${dayCondition.low}\°/${dayCondition.high}\°`;
                spanUpcomingElement.append(upDegreesElement);

                let upConditionElement = document.createElement('span');
                upConditionElement.classList.add('forecast-data');
                upConditionElement.textContent = dayCondition.condition;
                spanUpcomingElement.append(upConditionElement);

                threeDayForecastsElement.append(spanUpcomingElement);
            }

            upcomingDivElement.append(threeDayForecastsElement);
        } catch (error) {
            currentDivElement.innerHTML = '';
            upcomingDivElement.innerHTML = '';

            contentElement.append(divErrorElement);
            forecastDivElement.style.display = 'hidden';
        }
    });

    async function getWeatherData() {
        const url = 'http://localhost:3030/jsonstore/forecaster/locations';
        const res = await fetch(url);

        if (res.status != 200) {
            throw Error();
        }

        return Object.values(await res.json());
    }

    async function getConditionsData(soughtObject) {
        const currentConditionsUrl = `http://localhost:3030/jsonstore/forecaster/today/${soughtObject.code}`;
        const conditionsRes = await fetch(currentConditionsUrl);

        if (conditionsRes.status != 200) {
            throw Error();
        }

        return await conditionsRes.json();
    }

    async function getThreeDayConditionsData(soughtObject) {
        const threeDayConditionsUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${soughtObject.code}`;
        const threeDayConditionsRes = await fetch(threeDayConditionsUrl);

        if (threeDayConditionsRes.status != 200) {
            throw Error();
        }

        return await threeDayConditionsRes.json();
    }
}

attachEvents();