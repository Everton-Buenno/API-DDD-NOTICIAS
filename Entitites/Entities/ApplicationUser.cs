using Entitites.Enums;
using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations.Schema;


namespace Entitites.Entities
{
    public class ApplicationUser: IdentityUser
    {


        [Column("USR_AGE")]
        public int Age { get; set; }


        [Column("USR_CELL")]
        public string Cell { get; set; }


        [Column("USR_TYPE")]
        public TypeUsers? Type  { get; set; }



    }
}
