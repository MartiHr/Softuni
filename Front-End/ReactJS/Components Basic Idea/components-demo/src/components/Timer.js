import {useState} from 'react'

export const Timer = (props) => {

    console.log(props.start);
    const [time, setTime] = useState(props.start);

    setTimeout(() => {
        if (time < 10) {
            setTime(time + 1)
        }
    }, 1000);

    return (
        <div>
            <h1>Timer: {time} sec.</h1>
        </div>
    );
} 