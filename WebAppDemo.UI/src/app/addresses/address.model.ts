import { State } from "../states/state.model";

export interface Address {
    id: number;
    zipCode: string
    city: string;
    street: string;
    houseNumber: number;
    houseNumberAddition: string;
    state: State;
}