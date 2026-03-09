import React from "react"
import { NavbarComponent } from "../components/NavbarComponent"
import { FooterComponent } from "../components/FooterComponent"

type LayoutProps = {
    children: React.ReactNode;
}

export const ShoppingCartLayout: React.FC<LayoutProps> = ({children}) => {
    return(
        <div>
            <NavbarComponent/>
            <main>
                {children}
            </main>
            <FooterComponent/>
        </div>
    )
}