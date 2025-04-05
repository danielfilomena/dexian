
using System.ComponentModel.DataAnnotations;

namespace Dexian.Domain.Entities
{
    public class Escola
    {
        
        public int iCodEscola { get; set; }
        public string? sDescricao { get; set; }

        public virtual ICollection<Aluno>? Alunos { get; set; }

    }
}
