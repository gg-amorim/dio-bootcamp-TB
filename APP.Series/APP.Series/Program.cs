using System;

namespace APP.Series
{
    internal class Program
    {
        private static SerieRepositorio repositorio = new SerieRepositorio();

        private static void Main()
        {
            string opcaoUser = ObterOpcaoUser();

            while (opcaoUser.ToUpper() != "X")
            {
                switch (opcaoUser)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUser = ObterOpcaoUser();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.GetAll();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            Console.WriteLine("  #Título#   #Ano#   #Excluido#");
            foreach (var item in lista)
            {
                Console.WriteLine($"ID:{item.RetornaId()} - {item.RetornaTitulo()}({item.RetornaAno()}) {(item.RetornaExcluido() ? "!EXCLUÍDO!" : "")}");

            }
        }

        private static void InserirSerie()
        {
            repositorio.CadastrarSerie(repositorio);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.GetById(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            repositorio.AtualizarSerie(repositorio);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.Write("Deseja Mesmo excluir esse registro?(S/N): ");
            string resp = Console.ReadLine().ToUpper();
            if (resp.ToUpper() == "S")
            {
                repositorio.DeleteObj(indiceSerie);
                Console.Write("Série Excluida com Sucesso!");
                Console.WriteLine();
            }
            if (resp == "N")
            {
                Console.WriteLine();
                Main();
                return;
            }
            if (resp != "N" && resp != "S")
            {
                Console.WriteLine("Comando Inválido tente novamente");
                ExcluirSerie();
                Console.WriteLine();
                return;
            }
        }

        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine("SEJA BEM VINDO(A)!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}