export const FlowerSection = () => {
    return (
        <div>
            <section>
                {/* Container */}
                <div className="container">
                    {/* row */}
                    <div className="row justify-content-between align-items-center">
                        <div className="col-md-6">
                            <div className="img-wrapper">
                                <div className="after" />
                                <img src="assets/imgs/img-1.jpg" className="w-100" alt="About Us" />
                            </div>
                        </div>
                        <div className="col-md-5">
                            <h6 className="title mb-3">Lorem ipsum dolor sit amet, consectetur.</h6>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quae autem rem impedit molestiae hic ducimus, consequuntur ullam dolorem quaerat beatae labore explicabo, sint laboriosam aperiam nihil inventore facilis. Quasi, facilis.</p>
                            <p className="text-muted">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Consequuntur, amet!</p>
                            <button className="btn btn-outline-primary btn-sm">Learn More</button>
                        </div>
                    </div>
                    {/* End of Row */}
                </div>
                {/* End of Container */}
            </section>
        </div>    
    );
} 