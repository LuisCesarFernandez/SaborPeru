import { NavbarComponent } from "../components/NavbarComponent"
import { FooterComponent } from "../components/FooterComponent"
import React from "react"

type LayoutProps = {
    children:React.ReactNode;
}

export const MenuLayout:React.FC<LayoutProps> = ({children}) => {
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