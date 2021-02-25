namespace Project.Core.Objects
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TypeUser_Role
    {
        [Key, Column(Order = 0)]
        public string RoleId { get; set; }
        [Key, Column(Order = 1)]

        public int TypeUserId { get; set; }
        public string Note { get; set; }

        public virtual TypeUser TypeUser { get; set; }
        public virtual Role Role { get; set; }
    }
}
