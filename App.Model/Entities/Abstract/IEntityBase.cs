using System;

namespace App.Model.Entities.Abstract
{
    public interface IEntityBase
    {
		Guid Id { get; set; }
        DateTime CreatedDate { get; }
    }
}
