import { useEffect, useState } from 'react';
import { TodoItem } from './TodoItem';

export const TodoList = (props) => {

    const [todos, setTodos] = useState([]);

    useEffect(() => {
        fetch('http://localhost:3030/jsonstore/todos')
            .then(res => res.json())
            .then(result => {
                setTodos(Object.values(result));
            });
    }, [todos])

    const todoClickHandler = (todo) => {
        fetch(`http://localhost:3030/jsonstore/todos/${todo._id}`, {
            method: 'PUT',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify({ ...todo, isCompleted: !todo.isCompleted })
        });
    };

    return (
        <table className="table">
            <thead>
                <tr>
                    <th className="table-header-task">Task</th>
                    <th className="table-header-status">Status</th>
                    <th className="table-header-action">Action</th>
                </tr>
            </thead>
            <tbody>
                {todos.map(todo => <TodoItem key={todo._id} {...todo} onClick={todoClickHandler} />)}
            </tbody>
        </table>
    );
}