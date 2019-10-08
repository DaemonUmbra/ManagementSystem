using System.ComponentModel.DataAnnotations;

namespace Data.Core.Models.Mapping.Metadata
{
    public class ClassMemberMetadataBase
        : MetadataBase
    {
        [Required]
        public virtual ClassMetadata MemberOf { get; set; }

        [Required]
        public bool IsStatic { get; set; }
    }
}