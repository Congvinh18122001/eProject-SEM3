namespace Project.Core.Objects
{
    using System;
    using System.Collections.Generic;

    public partial class TypeUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeUser()
        {
            this.TypeUser_Roles = new HashSet<TypeUser_Role>();
            this.Users = new HashSet<User>();
        }

        public int TypeUserId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Sale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeUser_Role> TypeUser_Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
