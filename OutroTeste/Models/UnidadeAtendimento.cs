using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutroTeste.Models
{
    [Table("UnidadeAtendimento", Schema = "CACTB")]
    public class UnidadeAtendimento
    {
        [Key]
        [Column("idUnidadeAtendimento", TypeName = "smallint")]
        public short idUnidadeAtendimento { get; set; }

        [Column("deUnidadeAtendimento", TypeName = "varchar(200)")]
        public string deUnidadeAtendimento { get; set; }

        [Column("imUnidadeAtendimento", TypeName = "varbinary(max)")]
        public byte[] imUnidadeAtendimento { get; set; }

        [Column("nmUnidadeAtendimento", TypeName = "varchar(100)")]
        public string nmUnidadeAtendimento { get; set; }

        [Column("icAtivo", TypeName = "bit")]
        public bool icAtivo { get; set; }

        [ForeignKey("CentroAtendimento")]
        [Column("idCentroAtendimento", TypeName = "smallint")]
        public short idCentroAtendimento { get; set; }

        public CentroAtendimento CentroAtendimento { get; set; }
    }
}
