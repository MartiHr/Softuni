export const TodoItem = (props) => {
    return (
            <tr className={`todo ${props.isCompleted ? 'is-completed': ''}`}>
            <td>{props.text}</td>
            <td>{props.isCompleted ? 'Complete' : 'Incomplete'}</td>
            <td className="todo-action">
                <button onClick={() => props.onClick(props)} className="btn todo-btn">Change status</button>
            </td>
        </tr>
    );
}