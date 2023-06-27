import { Country } from "../countries/country.model";

export class State {
    constructor (
        public id: number,
        public name: string,
        public country: Country|null
    ) { }
}