import { BrowserRouter as Router } from "react-router-dom";
import { AppRouter } from "./routes/AppRouter";
import { CartProvider } from "./context/CardContext";
import { HeaderComponent } from "./components/HeaderComponent";

function App() {
  return (
    <Router>
      <CartProvider>
        <HeaderComponent />
        <main>
          <AppRouter />
        </main>
      </CartProvider>
    </Router>
  );
}

export default App;
