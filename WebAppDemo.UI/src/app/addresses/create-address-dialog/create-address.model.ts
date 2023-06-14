export class CreateAddressDto {
    constructor(
        public stateId: number|null,
        public city: string,
        public street: string,
        public zipCode: string,
        public houseNumber: number|null,
        public houseNumberAddition: string
    ) {

    }
}