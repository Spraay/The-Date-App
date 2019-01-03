using System;

namespace App.Model.Entity.Abstract
{
    public interface IEntityBase
    {
		Guid Id { get; set; }
        DateTime CreatedDate { get; }
    }
}
