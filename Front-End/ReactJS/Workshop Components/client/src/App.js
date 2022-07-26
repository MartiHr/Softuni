import { Footer } from './components/footer/Footer';
import { Header } from './components/header/Header'
import { Search } from './components/search/Search';
import { UserList } from './components/user-list/UserList';

function App() {
    return (
        <div>
            <Header />

            <main className="main">
                <section className="card users-container">
                    <Search />
                    
                    <UserList />
                    
                </section>
            </main>

            <Footer />
        </div>
    );
}

export default App;
