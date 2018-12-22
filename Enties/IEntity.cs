using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    interface IEntity
    {
		Guid Id { get; set; }
        DateTime CreatedDate { get; }
    }
}
