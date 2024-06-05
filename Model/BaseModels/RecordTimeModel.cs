using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;
namespace Models.BaseModels
{
    public class RecordTimeModel
    {

        [Column(ServerTime = DateTimeKind.Utc, CanUpdate = false)]
        public DateTime CreateTime { get; set; }

        [Column(ServerTime = DateTimeKind.Utc)]
        public DateTime UpdateTime { get; set; }
    }
}
