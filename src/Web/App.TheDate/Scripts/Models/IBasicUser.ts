export interface IBasicUser{
    Id : string;
    FirstName : string;
    LastName: string;
    ProfileImgSrc: string;
    getFullName() : string;
}