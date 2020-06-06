using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Aniversario
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Aniversario { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(string nome, string sobrenome, DateTime aniversario)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Aniversario = aniversario;
        }

        public List<Pessoa> Filtrar(List<Pessoa> lista, string encontrar)
        {
            List<Pessoa> resultQuery = lista.Where(x => x.Nome.Contains(encontrar)).ToList();



            return resultQuery;
        }

        public double CalcularAniversario(DateTime niver)
        {
            if (niver < DateTime.Now.Date)
                niver = niver.AddYears(1);

            double dias = DateTime.Now.Date.Subtract(niver).TotalDays;

            return dias;
        }

        public void NiverHoje(List<Pessoa> lista)
        {
            foreach (Pessoa pessoa in lista)
            {
                if (pessoa.Aniversario.Date == DateTime.Now.Date)
                {
                   Console.WriteLine(pessoa.Nome + " " + pessoa.Sobrenome + " Faz Aniversário Hoje!!!");
                }

            }
            
        }

    }
}
