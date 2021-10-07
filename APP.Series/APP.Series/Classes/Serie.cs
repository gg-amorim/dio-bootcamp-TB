using System;

namespace APP.Series
{
    internal class Serie : BaseEntity
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            var linha = Environment.NewLine;
            retorno += $"Genero: {Genero}{linha}" +
                       $"Titulo: {Titulo}{linha}" +
                       $"Descrição: {Descricao}{linha}" +
                       $"Ano de Início: {Ano}{linha}" +
                       $"Excluido: {(Excluido != true ? "Não" : "Sim")} ";
            return retorno;

        }

        public string RetornaTitulo()
        {
            return Titulo;
        }

        public int RetornaId()
        {
            return Id;
        }

        public string RetornaAno()
        {
            return Ano.ToString();
        }

        public bool RetornaExcluido()
        {
            return Excluido;
        }

        public bool Excluir()
        {
            return Excluido = true;
        }

    }
}