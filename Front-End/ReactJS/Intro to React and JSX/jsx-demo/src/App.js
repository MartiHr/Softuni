import { AboutSection } from './Sections/AboutSection';
import { FeaturesSection } from './Sections/FeaturesSection';
import { FlowerSection } from './Sections/FlowerSection';
import { HeroSection } from './Sections/HeroSection'
import { LaptopSection } from './Sections/LaptopSection';
import { TabletSection } from './Sections/TabletSection';
import { TestmonialSection } from './Sections/TestmonialSection';
import { BusinessSection } from './Sections/BusinessSection';
import { ContactSection } from './Sections/ContactSection';

function App() {
    return (
        <div className="App">
            <meta charSet="utf-8" />
            <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
            <meta name="description" content="Start your development with Creative Design landing page." />
            <meta name="author" content="Devcrud" />
            <title>Creative Design | Free Bootstrap 4.3.x template</title>
            {/* font icons */}
            <link rel="stylesheet" href="assets/vendors/themify-icons/css/themify-icons.css" />
            {/* Bootstrap + Creative Design main styles */}
            <link rel="stylesheet" href="assets/css/creative-design.css" />
            {/* Page Navbar */}
            <nav id="scrollspy" className="navbar page-navbar navbar-light navbar-expand-md fixed-top" data-spy="affix" data-offset-top={20}>
                <div className="container">
                    <a className="navbar-brand" href="#"><strong className="text-primary">Creative</strong> <span className="text-dark">Design</span></a>
                    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon" />
                    </button>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav ml-auto">
                            <li className="nav-item">
                                <a className="nav-link" href="#home">Home</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#about">About</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#features">Features</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#testmonial">Testmonial</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#contact">Contact</a>
                            </li>
                            <li className="nav-item ml-md-4">
                                <a className="nav-link btn btn-primary" href="components.html">Components</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>{/* End of Page Navbar */}
            
            {/* Page Header */}
            <HeroSection />
            {/* End of Page Header */}

            {/* About Section */}
            <AboutSection />
            {/*End of Section */}
            {/* section */}
            <FlowerSection />
            {/* End of Section */}
            {/* section */}
            <LaptopSection />
            {/* End of Section */}
            {/* Features Section */}
            <FeaturesSection />
            {/* End of features Section */}
            {/* Section */}
            <TabletSection />
            {/* End of Section */}
            {/* Testmonial Section */}
            <TestmonialSection />
            {/* End of Testmonial Section */}
            {/* Section */}
            <BusinessSection />
           {/* End of Section */}
            {/* Contact Section */}
            <ContactSection />
            {/* End of Contact Section */}
      
            {/* Section for footer */}
            <section className="pb-0">
                {/* Container */}
                <div className="container">
                    {/* Pre footer */}
                    <div className="pre-footer">
                        <ul className="list">
                            <li className="list-head">
                                <h6 className="font-weight-bold">ABOUT US</h6>
                            </li>
                            <li className="list-body">
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nobis fugit maxime deleniti minus optio accusamus, quam maiores explicabo sunt.</p>
                                <a href="#"><strong className="text-primary">Creative</strong> <span className="text-dark">Design</span></a>
                            </li>
                        </ul>
                        <ul className="list">
                            <li className="list-head">
                                <h6 className="font-weight-bold">USEFUL LINKS</h6>
                            </li>
                            <li className="list-body">
                                <div className="row">
                                    <div className="col">
                                        <a href="#">Link 1</a>
                                        <a href="#">Link 2</a>
                                        <a href="#">Link 3</a>
                                        <a href="#">Link 4</a>
                                    </div>
                                    <div className="col">
                                        <a href="#">Link 5</a>
                                        <a href="#">Link 6</a>
                                        <a href="#">Link 7</a>
                                        <a href="#">Link 8</a>
                                    </div>
                                </div>
                            </li>
                        </ul>
                        <ul className="list">
                            <li className="list-head">
                                <h6 className="font-weight-bold">CONTACT INFO</h6>
                            </li>
                            <li className="list-body">
                                <p>Contact us and we'll get back to you within 24 hours.</p>
                                <p><i className="ti-location-pin" /> 12345 Fake ST NoWhere AB Country</p>
                                <p><i className="ti-email" />  info@website.com</p>
                                <div className="social-links">
                                    <a href="#" className="link"><i className="ti-facebook" /></a>
                                    <a href="#" className="link"><i className="ti-twitter-alt" /></a>
                                    <a href="#" className="link"><i className="ti-google" /></a>
                                    <a href="#" className="link"><i className="ti-pinterest-alt" /></a>
                                    <a href="#" className="link"><i className="ti-instagram" /></a>
                                    <a href="#" className="link"><i className="ti-rss" /></a>
                                </div>
                            </li>
                        </ul>
                    </div>{/* End of Pre footer */}
                    {/* foooter */}
                    <footer className="footer">
                        <p>Copyright  © <a href="http://www.devcrud.com">DevCRUD</a></p>
                    </footer>{/* End of Footer*/}
                </div>{/*End of Container */}
            </section>{/* End of Section */}
            {/* core  */}
            {/* bootstrap affix */}
            {/* Creative Design js */}
        </div>
    );
}

export default App;
