export class UpdateAddressDto {
    constructor(
        public id: number,
        public stateId: number,
        public city: string,
        public street: string,
        public zipCode: string,
        public houseNumber: number,
        public houseNumberAddition: string
        ) {

        }
}