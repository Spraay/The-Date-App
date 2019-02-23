using System;

namespace Core.Models.Entities.Abstract
{
    public interface IEntityBase
    {
		Guid Id { get; set; }
        DateTime CreatedDate { get; }
    }
}
