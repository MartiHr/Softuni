export const FeaturesSection = () => {
    return (
        <div>
            <section className="has-bg-img" id="features">
                <div className="overlay" />
                {/* Button trigger modal */}
                <a data-toggle="modal" href="#exampleModalCenter">
                    <i />
                </a>
                {/* Modal */}
                <div className="modal fade" id="exampleModalCenter" tabIndex={-1} role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                    <div className="modal-dialog modal-dialog-centered modal-lg" role="document">
                        <div className="modal-content">
                            <iframe width="100%" height="450px" className="border-0" src="https://www.youtube.com/embed/tgbNyZ7vqY?controls=0">
                            </iframe>
                        </div>
                    </div>
                </div>{/* End of Modal */}
            </section>
        </div>
    );
} 