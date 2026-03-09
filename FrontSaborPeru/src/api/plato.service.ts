import { api } from "./api.service";
import type { PlatoReadInterface } from "../modules/client/interfaces/platoServiceInterface/PlatoReadInterface";

export const GetPlatos = async():Promise<PlatoReadInterface[]> => {
  try {
    const { data } = await api.get<PlatoReadInterface[]>(`/api/Plato`);
    return data;
  } catch (error) {
    throw error;
  }
};
