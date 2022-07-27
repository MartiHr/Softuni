import {Link, NavLink} from 'react-router-dom';
import styles from './Navigation.module.css';

const Navigation = () => {
    const setNavStyle = ({isActive}) => {
        return isActive 
            ? `${styles["link-style"]} ${styles["active-link"]}`
            :   styles["link-style"]
    };

    return (
        <nav>
            <ul>
                <li><NavLink to="/" className={setNavStyle}>Home</NavLink></li>
                <li><NavLink to="/dashboard" className={setNavStyle}>Dashboard</NavLink></li>
                <li><NavLink to="/about" className={setNavStyle}>About</NavLink></li>
                <li><NavLink to="/help" className={setNavStyle}>Help</NavLink></li>
            </ul>
        </nav>
    );
}

export default Navigation;