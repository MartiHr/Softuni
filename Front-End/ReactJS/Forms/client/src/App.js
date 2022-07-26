import './App.css';

import { useState, useEffect, useRef } from 'react';

function App() {
    const infoRef = useRef()

    let [values, setValues] = useState({
        username: '',
        password: '',
        age: '',
        bio: '',
        gender: 'm',
        userType: 'personal',
        egn: '',
        eik: '',
        tac: false,
    });

    useEffect(() => {
        if (values.username && values.age) {
            infoRef.current.value = `${values.username}: ${values.age} years old`;
        }
    }, [values.username, values.age]);

    const changeHandler = (e) => {
        setValues(state => ({
            ...state,
            [e.target.name]: e.target.type === 'checkbox' ? e.target.checked : e.target.value
        }))
    }

    const submitHandler = (e) => {
        e.preventDefault();

        console.log(values);
    }

    return (
        <div className="App">
            <header className="App-header">
                <form onSubmit={submitHandler}>
                    <div>
                        <label htmlFor="username">Username: </label>
                        <input
                            type="text"
                            name="username"
                            id="username"
                            value={values.username}
                            onChange={changeHandler}
                        />
                    </div>
                    <div>
                        <label htmlFor="password">Password: </label>
                        <input
                            type="password"
                            name="password"
                            id="password"
                            value={values.password}
                            onChange={changeHandler}
                        />
                    </div>
                    <div>
                        <label htmlFor="age">Age: </label>
                        <input
                            type="number"
                            name="age"
                            id="age"
                            value={values.age}
                            onChange={changeHandler}
                        />
                    </div>
                    <div>
                        <label htmlFor="bio">Bio: </label>
                        <textarea
                            name="bio"
                            id="bio"
                            cols="30"
                            rows="5"
                            value={values.bio}
                            onChange={changeHandler}
                        >
                        </textarea>
                    </div>
                    <div>
                        <label htmlFor="gender">Gender: </label>
                        <select
                            name="gender"
                            id="gender"
                            value={values.gender}
                            onChange={changeHandler}
                        >
                            <option value="m">Male</option>
                            <option value="f">Female</option>
                            <option value="o">Other</option>
                        </select>
                    </div>

                    <div>
                        <label htmlFor="personal-user-type">Personal:</label>
                        <input
                            type="radio"
                            name="userType"
                            id="personal-user-type"
                            value="personal"

                            checked={values.userType === 'personal'}
                            onChange={changeHandler}
                        />

                        <label htmlFor="corporate-user-type"> Corporate:</label>
                        <input
                            type="radio"
                            name="userType"
                            id="corporate-user-type"
                            value="corporate"
                            checked={values.userType === 'corporate'}
                            onChange={changeHandler}
                        />
                    </div>
                    <div>
                        <label htmlFor="identifier"> {values.userType === 'personal' ? 'EGN: ' : 'EIK: '}</label>

                        {values.userType === 'personal'
                            ? <input type="number" name="egn" id="identifier" value={values.egn} onChange={changeHandler} />
                            : <input type="number" name="eik" id="identifier" value={values.eik} onChange={changeHandler} />
                        }
                    </div>
                    <div>
                        <label htmlFor="tac"> Terms and conditions:</label>
                        <input
                            type="checkbox"
                            name="tac"
                            id="tac"
                            checked={values.tac}
                            onChange={changeHandler}
                        />
                    </div>
                    <div>
                        <button type='submit' disabled={!values.tac}>Submit</button>
                    </div>
                    <div>
                        <label htmlFor="uncontrolled-field">Uncontrolled field: </label>
                        <input
                            type="text"
                            name="uncontrolled"
                            id="uncontrolled-field"
                            disabled={true}
                            ref={infoRef}
                        />
                    </div>
                </form>
            </header>
        </div>
    );
}

export default App;
