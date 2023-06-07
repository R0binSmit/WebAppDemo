import { Country } from "../countries/countrie.model";

export interface State {
    id: number;
    name: string;
    country: Country;
}