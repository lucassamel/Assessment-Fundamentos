using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.ComponentModel;

namespace Gerenciador_de_Aniversario
{
    public class Arquivo
    {
        public StreamWriter db;

        string path = @"D:\Desenvolvimento\VisualStudio\Assessment-Fundamentos";

        string arquivo = @"D:\Desenvolvimento\VisualStudio\Assessment-Fundamentos\dados.txt";


        public void CriarArquivo()
        {
            if (!Directory.Exists(this.path))
                Directory.CreateDirectory(this.path);

            if (!File.Exists(this.arquivo))
            {
                db = File.CreateText(this.arquivo);
                db.Close();
            }
            
        }       

        public void GravarDados(Pessoa pessoa)
        {
            
            using (StreamWriter fs = File.AppendText(arquivo))
            {
                
                fs.WriteLine(string.Format("{0};{1};{2}", pessoa.Nome, pessoa.Sobrenome, pessoa.Aniversario));
            }
            
        }

        public List<Pessoa> ListarDados()
        {
            List<Pessoa> lista = new List<Pessoa>();
            using (StreamReader reader = new StreamReader(arquivo))
            {
                string line;
                int i = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] dados = line.Split(';');
                    Pessoa pessoa = new Pessoa()
                    {
                        Nome = dados[0],
                        Sobrenome= dados[1],
                        Aniversario = Convert.ToDateTime(dados[2])
                    };
                    Console.WriteLine(string.Format(i + " - {0} {1} {2}" , 
                        pessoa.Nome, pessoa.Sobrenome, pessoa.Aniversario.ToString("dd/MM/yyyy")));
                    i += 1;
                    lista.Add(pessoa);
                }
                Console.WriteLine("-------------------");
            }

            return lista;
        }
        
        public void DeletarPessoa()
        {
            List<Pessoa> lista = ListarDados();
            Console.WriteLine("Escolha uma pessoa para ser deletada: ");
            string escolha = Console.ReadLine();
            int i = Int32.Parse(escolha);

            lista.Remove(i);

            var itemToRemove = lista.Single(r => r. == i);
            lista.Remove(itemToRemove);

        }

    }
}
