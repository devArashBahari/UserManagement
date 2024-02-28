using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Base
{
    public abstract class Base
    {
        
        public long Id { get; set; }
        [Column(TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "timestamp with time zone")]
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

    }
}