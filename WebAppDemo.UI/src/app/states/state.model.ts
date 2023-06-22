import { ICountry } from "../countries/country.interface";

export interface State {
    id: number;
    name: string;
    country: ICountry;
}