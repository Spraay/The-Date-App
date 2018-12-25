using System;
namespace App.Abstract
{
    public interface IEntityBase
    {
		Guid Id { get; set; }
        DateTime CreatedDate { get; }
    }
}
