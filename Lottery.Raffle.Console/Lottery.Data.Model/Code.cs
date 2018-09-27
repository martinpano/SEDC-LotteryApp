using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Data.Model
{
    [Table("dbo.Codes")]
    public class Code : IEntity
    {
        [Key]
        [Column("CodeID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CodeValue { get; set; }

        public bool IsWinning { get; set; }

        [DefaultValue(false)]
        public bool IsUsed { get; set; }
    }
}
