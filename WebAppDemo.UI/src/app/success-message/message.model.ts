import { MessageType } from "../shared/messageType.enum";

export class Message {
    constructor(
        public messageType: MessageType,
        public title: string,
        public description: string
    ) {
        
    }
}