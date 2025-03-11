using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FraudWatch.Domain.Entities;

[Table("CH_Analistas")]
public class AnalistaEntity : UsuarioEntity
{
    public string Departamento { get; set; }
}
