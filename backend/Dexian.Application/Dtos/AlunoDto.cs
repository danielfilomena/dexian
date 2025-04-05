namespace Dexian.Application.Dtos
{
    public class AlunoDto
    {

        public int iCodAluno { get; set; }
        public string? sNome { get; set; }
        public DateTime dNacimento { get; set; }
        public string? sCPF { get; set; }
        public string? sEndereco { get; set; }
        public string? sCelular { get; set; }
        public int iCodEscola { get; set; }

        //public virtual EscolaDto? Escola { get; set; }

    }
}
