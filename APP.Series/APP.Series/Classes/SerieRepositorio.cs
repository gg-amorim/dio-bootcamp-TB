using APP.Series.Interfaces;
using System;
using System.Collections.Generic;

namespace APP.Series
{
    internal class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> series = new List<Serie>();
        public void DeleteObj(int id)
        {
            series[id].Excluir();
        }

        public List<Serie> GetAll()
        {
            return series;
        }

        public Serie GetById(int id)
        {
            return series[id];
        }

        public int NextId()
        {
            return series.Count;
        }

        public void PostObj(Serie obj)
        {
            series.Add(obj);
        }

        public void UpdadeObj(int id, Serie obj)
        {
            series[id] = obj;
        }
        
        public void CadastrarSerie(SerieRepositorio obj)
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: obj.NextId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            obj.PostObj(novaSerie);
        }

        public void AtualizarSerie(SerieRepositorio obj)
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            obj.UpdadeObj(indiceSerie, atualizaSerie);
        }
    }
}