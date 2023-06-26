import { MessageType } from "./messageType.enum";

export class Message {
    constructor(
        public messageType: MessageType,
        public title: string,
        public description: string,
        public isVisible: boolean = true,
        public visibilityTime: number = 0
    ) {}
}