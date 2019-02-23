import { IBasicConversation } from "./IBasicConversation";

export class BasicConversation implements IBasicConversation{
    Id: string;
    Name: string;
    UsersIds: string[];
    constructor(Id?: string, Name?: string, UsersIds?: string[] ) {
        this.Id = Id || "";
        this.Name = Name || "";
        this.UsersIds = UsersIds || []
    }
}
