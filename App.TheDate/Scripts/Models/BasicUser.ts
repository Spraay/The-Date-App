import { IBasicUser } from "./IBasicUser";
export class BasicUser implements IBasicUser {
    Id: string;
    FirstName: string;
    LastName: string;
    ProfileImgSrc: string;
    constructor(Id?: string, FirstName?: string, LastName?: string, ProfileImgSrc?: string)
    {
        this.Id = Id || "";
        this.FirstName = FirstName || "";
        this.LastName = LastName || "";
        this.ProfileImgSrc = ProfileImgSrc || "";
    }
    getFullName = () => this.FirstName+" "+this.LastName;
}