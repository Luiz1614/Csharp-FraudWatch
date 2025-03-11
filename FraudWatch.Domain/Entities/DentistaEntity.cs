using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FraudWatch.Domain.Entities;

[Table("CH_Dentistas")]
public class DentistaEntity : UsuarioEntity
{
    public string CRO { get; set; }
}
