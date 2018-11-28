using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enties
{
    public class Image
    {
        [Key]
        public Guid ID { get; set; }
        [ForeignKey(nameof(UserID))]
        public Guid UserID { get; set; }
        public string Src { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
        
    }
}