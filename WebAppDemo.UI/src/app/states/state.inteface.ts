import { ICountry } from "../countries/country.interface";

export interface IState {
    id: number;
    name: string;
    country: ICountry;
}