namespace SalesWebMVC.Models
{
    public class Departamento
    {
        public int CodigoDepartamento { get; set; }
        public string NomeDepartamento { get; set; }

        public Departamento(int codigoDepartamento, string nomeDepartamento)
        {
            CodigoDepartamento = codigoDepartamento;
            NomeDepartamento = nomeDepartamento;
        }
    }
}
