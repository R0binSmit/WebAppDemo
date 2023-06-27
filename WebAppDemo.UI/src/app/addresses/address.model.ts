import { State } from "../states/state.model";

export class Address {
    constructor( 
        public id: number,
        public zipCode: string,
        public city: string,
        public street: string,
        public houseNumber: number,
        public houseNumberAddition: string,
        public stateId: number,
        public state: State|null
    ) { }
}