using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Gerenciador_de_Aniversario;



namespace Assessment_Fundamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<Pessoa>();
            Pessoa filtro = new Pessoa();

            Arquivo arquivo = new Arquivo();

            //Pessoa pessoa1 = new Pessoa();

            //pessoa1.Nome = "Claudio";
            //pessoa1.Sobrenome = "Rezene";
            //pessoa1.Aniversario = DateTime.Now;


            arquivo.CriarArquivo();
            //arquivo.GravarDados(pessoa1);
    


            Console.WriteLine("Pessoas já Cadastradas: ");
            Console.WriteLine("#################################");
            lista = arquivo.ListarDados();
            Console.WriteLine("--------------------------");

            Pessoa pessoa = new Pessoa();
            pessoa.NiverHoje(lista);

            Console.WriteLine(" ");
            Console.WriteLine("***************************");
            Console.WriteLine(" ");

            while (true)
            {
                string opcao = Menu();

                if (opcao == "1")
                {
                    ListarPessoas(lista, filtro);
                }
                else if (opcao == "2")
                {
                    AddPessoa(lista);                    
                }
                else if (opcao == "3")
                {
                    arquivo.ListarDados();
                }
                else if (opcao == "4")
                {
                    arquivo.AtualizarPessoa();
                }
                else if(opcao == "5")
                {
                    arquivo.DeletarPessoa();
                }
                else
                {
                    break;
                }



            }


        }

        private static void ListarPessoas(List<Pessoa> lista, Pessoa filtro)
        {
            Console.WriteLine("Digite o nome, ou parte do nome, da pessoa que deseja encontrar: ");
            string encontrar = Console.ReadLine();

            //Filtra as pessoas

            List<Pessoa> resultQuery = filtro.Filtrar(lista, encontrar);


            if (resultQuery.Count() <= 0)
            {
                Console.WriteLine("Não foi possível encontrar nehuma pessoa.");
                Console.WriteLine(" ");
            }
            else
            {
                int i = 0;
                foreach (Pessoa pessoa in resultQuery)
                {
                    Console.WriteLine(i + " -  Nome: " + pessoa.Nome + " " + pessoa.Sobrenome);
                    i += 1;
                }

                Console.Write("Selecione uma das opções para visualizar os dados de uma das pessoas encontradas: ");
                string escolha = Console.ReadLine();
                int x = Int16.Parse(escolha);

                Console.WriteLine("Nome: " + resultQuery[x].Nome + " " + resultQuery[x].Sobrenome);
                Console.WriteLine(resultQuery[x].Aniversario);

                DateTime niver = resultQuery[x].Aniversario;

                //DateTime niver = new DateTime(2010, 10, 01);

                niver = new DateTime(DateTime.Now.Year, niver.Month, niver.Day);

                Pessoa p1 = new Pessoa();

                double dias = p1.CalcularAniversario(niver);

                Console.WriteLine("Faltam " + (dias * -1) + " dias para o seu aniversário");


                Console.WriteLine("------------------------------------------");
                Console.WriteLine(" ");

            }
        }

        private static string Menu()
        {
            Console.WriteLine("Escolha uma das opções a baixo: ");
            Console.WriteLine("1 - Pesquisar Pessoas");
            Console.WriteLine("2 - Adicionar Nova Pessoa");
            Console.WriteLine("3 - Listar pessoas cadastradas.");
            Console.WriteLine("4 - Editar uma pessoa.");
            Console.WriteLine("5 - Deletar uma pessoa.");
            Console.WriteLine("Digite qualquer outra tecla para Sair");
            string opcao = Console.ReadLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" ");
            return opcao;
        }

        private static void AddPessoa(List<Pessoa> lista)
        {
            Console.Write("Digite o nome da pessoa: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o sobrenome da pessoa: ");
            string sobrenome = Console.ReadLine();
            Console.Write("Digite a data de aniversário da pessoa no formato DD/MM/YYYY : ");
            string data = Console.ReadLine();
            DateTime aniversario = Convert.ToDateTime(data);
            Pessoa pessoa = new Pessoa(nome, sobrenome, aniversario);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" ");

            Console.WriteLine("Os dados abaixo estão corretos?");
            Console.WriteLine("Nome: " + pessoa.Nome + " " + pessoa.Sobrenome);
            Console.WriteLine("Aniversário: " + pessoa.Aniversario);
            Console.WriteLine("1 - SIM");
            Console.WriteLine("2 - NÃO");
            string escolha = Console.ReadLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" ");

            if (escolha == "1")
            {
                Console.WriteLine("Dados adicionados com sucesso!");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(" ");

            }
            else
            {
                AddPessoa(lista);
            }
            lista.Add(pessoa);

            Arquivo arquivo = new Arquivo();

            arquivo.GravarDados(pessoa);


            
        }


    }

        
        


    
}
