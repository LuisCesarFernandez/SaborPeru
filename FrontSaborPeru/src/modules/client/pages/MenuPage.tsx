import { CardComponent } from "../components/menuComponents/CardComponent";
import type { PlatoReadInterface } from "../interfaces/platoServiceInterface/PlatoReadInterface";
import { GetPlatos } from "../../../api/plato.service";
import { useState, useEffect } from "react";
import { MenuLayout } from "../layouts/MenuLayout";

export const MenuPage = () => {
  const [platos, setPlato] = useState<PlatoReadInterface[]>([]);

  useEffect(() => {
    const fetchPlatos = async () => {
      try {
        const data = await GetPlatos();
        console.log(data)
        setPlato(data);
      } catch (error) {
        throw error;
      }
    };
    fetchPlatos();
  },[]);

  return (
    <MenuLayout>
      <div>
      {platos.map(plato => (
        <CardComponent 
        key={plato.id}
        {...plato}/>
      ))}
    </div>
    </MenuLayout>
  );
};
