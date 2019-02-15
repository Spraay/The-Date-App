import * as request from 'request';

export interface IConversationInfo
{
    Id: string;
    Name: string;
    Users: IConversationUser[];
}

export interface IConversationUser
{
    Id: string;
    FirstName: string;
    LastName: string;
    ProfileImgSrc: string;
}

export class ConversationApiService
{
    getConversationInfo(conversationId : string)
    {
        request.get("/api/MessagesApi/conversation/"+ conversationId, null, (response: IConversationInfo) =>
        {
            console.log(response);
        });
    }
}