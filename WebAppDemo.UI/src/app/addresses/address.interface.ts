import { IState } from "../states/state.inteface";

export interface IAddress {
    id: number;
    zipCode: string
    city: string;
    street: string;
    houseNumber: number;
    houseNumberAddition: string;
    stateId: number;
    state: IState;
}