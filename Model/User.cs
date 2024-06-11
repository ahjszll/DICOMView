using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;
using Models.BaseModels;
namespace Models
{
    [Table(Name = "User")]
    public class User : RecordTimeModel
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }

        [Column(StringLength = 50)]
        public string Name { get; set; } = "";

        [Column(StringLength = 50)]
        public string RealName { get; set; } = "";

        [Column(StringLength = 200)]
        public string PWD { get; set; } = ""; 
    }
}
