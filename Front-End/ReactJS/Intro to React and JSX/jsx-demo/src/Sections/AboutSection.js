export const AboutSection = () => {
    return (
        <div>
            <section id="about">
                {/* Container */}
                <div className="container">
                    {/* About wrapper */}
                    <div className="about-wrapper">
                        <div className="after"><h1>About Us</h1></div>
                        <div className="content">
                            <h5 className="title mb-3">Lorem ipsum dolor sit.</h5>
                            {/* row */}
                            <div className="row">
                                <div className="col">
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Assumenda soluta nisi cumque nostrum porro repellat iusto neque quos asperiores, aliquam.</p>
                                    <p><b>Adipisicing elit. Modi similique  iusto voluptatibus sint.</b></p>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Distinctio dignissimos modi molestias voluptas possimus perferendis saepe soluta accusantium, obcaecati neque quas ducimus, alias labore nesciunt atque ab voluptatibus quis! Molestiae dicta reprehenderit, quod laborum voluptatem laboriosam! Sapiente vel, fugiat voluptates.</p>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorem, quis!</p>
                                </div>
                                <div className="col">
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Assumenda soluta nisi cumque nostrum porro repellat iusto neque quos asperiores, aliquam.</p>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorem, quis!</p>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Distinctio dignissimos modi molestias voluptas possimus perferendis saepe soluta accusantium, obcaecati neque quas ducimus, alias labore nesciunt atque ab voluptatibus quis! Molestiae dicta reprehenderit, quod laborum voluptatem laboriosam! Sapiente vel, fugiat voluptates.</p>
                                </div>
                            </div>{/* End of Row */}
                            <a href="#">Read More...</a>
                        </div>
                    </div>{/* End of About Wrapper */}
                </div>  {/* End of Container*/}
            </section>
        </div>
    );
}