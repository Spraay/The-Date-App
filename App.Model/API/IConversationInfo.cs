using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.API
{
    interface IConversationInfo
    {
        Guid Id { get; set; }
        string Name { get; set; }
        List<IConversationUser> Users { get; set; }
    }
}
