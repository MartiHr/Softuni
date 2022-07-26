import './App.css';
import { Clicker } from './components/Clicker';
import { Timer } from './components/Timer';

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <Timer start={1}/>
                <Clicker />
            </header>   
        </div>
    );
}

export default App;
