export const Header = () => {
    return (
        <div>
            <header className="navigation-header">
                <span className="navigation-logo">
                    <img src="/images/todo-icon.png" alt="todo-logo" />
                </span>
                <span className="spacer"></span>
                <span className="navigation-description">Todo List</span>
            </header>
        </div>
    );
}