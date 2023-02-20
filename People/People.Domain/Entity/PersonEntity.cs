using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Domain.Entity
{
    [Table("Person")]
    public class PersonEntity
    {
        [Key]
        public Guid PersonId { get; set; }
        public Guid JobProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
