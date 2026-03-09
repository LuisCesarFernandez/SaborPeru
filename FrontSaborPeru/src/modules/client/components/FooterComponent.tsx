import "../styles/FooterStyle.css"

export const FooterComponent = () => {
    return (
        <footer className="Footer-Container">
            <section className="Footer-Information">
                <h3>Contáctanos: 123456789</h3>
                <h3>Ubicación: Júpiter</h3>
            </section>
            <section className="Footer-Socialnetworks">
                <h3>¡Síguenos en nuestras redes!</h3>
                <ul>
                    <li>TikTok</li>
                    <li>Facebook</li>
                    <li>Instagram</li>
                </ul>
            </section>
        </footer>
    );
};
