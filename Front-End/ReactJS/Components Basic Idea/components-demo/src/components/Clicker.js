import { useState } from 'react';

export const Clicker = (props) => {
    const [clicks, setClicks] = useState(0);

    const dereaseClickHandler = (e) => {
        setClicks(oldClicks => oldClicks - 1);
    };

    const increaseClickHandler = (e) => {
        setClicks(oldClicks => oldClicks + 1);
    };

    let title = '';

    if (clicks < 10) {
        title = 'Counter';
    } else if (clicks < 20) {
        title = 'BigCounter';
    } else {
        title = 'GigaCounter'
    }

    return (
        <div>
            <h1>{title}</h1>
            <button onClick={dereaseClickHandler}>-</button>
            <span> {clicks} </span>
            <button onClick={increaseClickHandler}>+</button>
        </div>
    );
}