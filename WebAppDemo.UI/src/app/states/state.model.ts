import { Country } from "../countries/country.model";

export interface State {
    id: number;
    name: string;
    country: Country;
}