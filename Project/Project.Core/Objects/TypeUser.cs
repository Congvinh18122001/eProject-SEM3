namespace Project.Core.Objects
{
    using System;
    using System.Collections.Generic;

    public partial class TypeUser
    {
        public TypeUser()
        {
            this.Users = new HashSet<User>();
        }

        public int TypeUserId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Sale { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
