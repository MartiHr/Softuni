export const TestmonialSection = () => {
    return (
        <div>
            <section className="text-center pt-5" id="testmonial">
                {/* Container */}
                <div className="container">
                    <h3 className="mt-3 mb-5 pb-5">What our Client says</h3>
                    {/* Row */}
                    <div className="row">
                        <div className="col-sm-10 col-md-4 m-auto">
                            <div className="testmonial-wrapper">
                                <img src="assets/imgs/avatar1.jpg" alt="Client Image" />
                                <h6 className="title mb-3">Adell Smith</h6>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Praesentium voluptates voluptatem eum nisi cumque veniam est id reprehenderit atque rerum, cum sit perspiciatis, harum cupiditate nostrum quibusdam perferendis accusamus, illo.</p>
                            </div>
                        </div>
                        <div className="col-sm-10 col-md-4 m-auto">
                            <div className="testmonial-wrapper">
                                <img src="assets/imgs/avatar2.jpg" alt="Client Image" />
                                <h6 className="title mb-3">John Doe</h6>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Praesentium voluptates voluptatem eum nisi cumque veniam est id reprehenderit atque rerum, cum sit perspiciatis, harum cupiditate nostrum quibusdam perferendis accusamus, illo.</p>
                            </div>
                        </div>
                        <div className="col-sm-10 col-md-4 m-auto">
                            <div className="testmonial-wrapper">
                                <img src="assets/imgs/avatar3.jpg" alt="Client Image" />
                                <h6 className="title mb-3">Kyle Butler</h6>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Praesentium voluptates voluptatem eum nisi cumque veniam est id reprehenderit atque rerum, cum sit perspiciatis, harum cupiditate nostrum quibusdam perferendis accusamus, illo.</p>
                            </div>
                        </div>
                    </div>{/* end of Row */}
                </div>{/* End of Cotanier */}
            </section>
        </div>
    );
}