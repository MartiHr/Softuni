export const ContactSection = () => {
    return (
        <div>
            <section id="contact" className="text-center">
                {/* container */}
                <div className="container">
                    <h1>CONTACT US</h1>
                    <p className="mb-5">If you have some Questions or need Help! Please Contact Us! <br />
                        We make Cool and Clean Design for your Business</p>
                    {/* Contact form */}
                    <form className="contact-form col-md-11 col-lg-9 mx-auto">
                        <div className="form-row">
                            <div className="col form-group">
                                <input type="text" className="form-control" placeholder="Name" />
                            </div>
                            <div className="col form-group">
                                <input type="email" className="form-control" placeholder="Email" />
                            </div>
                        </div>
                        <div className="form-group">
                            <textarea cols={30} rows={5} className="form-control" placeholder="Your Message" defaultValue={""} />
                        </div>
                        <div className="form-group">
                            <input type="submit" className="btn btn-primary btn-block" defaultValue="Send Message" />
                        </div>
                    </form>{/* End of Contact form */}
                </div>{/* End of Container*/}
            </section>
        </div>
    );
}