using System;

namespace App.Model.API
{
    public interface IConversationUser
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string ProfileImgSrc { get; set; }
    }
}