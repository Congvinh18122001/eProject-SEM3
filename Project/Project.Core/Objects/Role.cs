namespace Project.Core.Objects
{
    using System.Collections.Generic;

    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            this.TypeUser_Roles = new HashSet<TypeUser_Role>();
        }

        public string RoleId { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeUser_Role> TypeUser_Roles { get; set; }
    }
}
