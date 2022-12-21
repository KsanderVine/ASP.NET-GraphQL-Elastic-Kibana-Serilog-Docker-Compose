using System.ComponentModel.DataAnnotations;

namespace WebLibraryApp.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        [GraphQLIgnore]
        public DateTime CreatedAt { get; set; }

        [GraphQLIgnore]
        public DateTime UpdatedAt { get; set; }
    }
}
