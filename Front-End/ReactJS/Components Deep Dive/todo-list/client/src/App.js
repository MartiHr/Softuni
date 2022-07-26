import { Footer } from './components/Footer';
import { Header } from './components/Header';
import { Spinner } from './components/Spinner';
import { TodoList } from './components/TodoList';

function App() {
    return (
        <div>
            {/* Navigation header */}
            <Header />
            
            {/* <!-- Main content --> */}
            <main className="main">
                <section className="todo-list-container">
                    <h1>Todo List</h1>

                    <div className="table-wrapper">

                       {/* <Spinner /> */}

                        <TodoList />
                    </div>
                </section>
            </main>

            {/* Footer */}
            <Footer />
        </div>
    );
}

export default App;
