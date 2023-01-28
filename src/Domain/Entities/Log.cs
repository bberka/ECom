using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Log
    {
        public long Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public int LogType { get; set; }
        public int OperationType { get; set; }
        public int OperationMemo { get; set; }
        [MaxLength(32)]
        public string IpAddress { get; set; }
        public long? UserNo { get; set; }
        [MaxLength(2000)]
        public string Params { get; set; }

    }
}
