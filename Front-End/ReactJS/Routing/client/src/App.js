import { Routes, Route } from 'react-router-dom';

import './App.css';

import Navigation from './components/Navigation';
import Home from './components/Home';
import Dashboard from './components/Dashboard';
import About from './components/About';
import Help from './components/Help';
import NotFound from './components/NotFound';

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <Navigation />

                <Routes>
                    <Route path="/" element={<Home />}/>
                    <Route path="/dashboard" element={<Dashboard />}/>
                    <Route path="/about" element={<About />}/>
                    <Route path="/help" element={<Help />}/>
                    <Route path="/*" element={<NotFound />}/>
                </Routes>
            </header>
        </div>
    );
}

export default App;
