using System;


namespace CadastroSeries
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            #region Opção do Usuário
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por utilizar nosso cadastro de séries");
            Console.WriteLine();

            #endregion
        }
        #region Obter a Opção Usuário
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Olá! Seja Bem Vindo!!!");
            Console.WriteLine("Digite a opção desejada:");

            Console.WriteLine("1- Listar as séries cadastradas");
            Console.WriteLine("2- Inserir uma nova série");
            Console.WriteLine("3- Atualizar série as cadastradas");
            Console.WriteLine("4- Excluir uma série");
            Console.WriteLine("5- Visualizar uma série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        #endregion

        #region Listar Séries
        public static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada. ");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        #endregion 

        #region Inserir Serie
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir uma nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Título da Série: ");
            string entTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Produção da Série: ");
            int entAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Sinopse da Série: ");
            string entSinopse = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entGenero, titulo: entTitulo, ano: entAno, sinopse: entSinopse);

            repositorio.Insere(novaSerie);

        }


        #endregion

        #region Atualizar Serie
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Título da Série: ");
            string entTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Produção da Série: ");
            int entAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Sinopse da Série: ");
            string entSinopse = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entGenero, titulo: entTitulo, ano: entAno, sinopse: entSinopse);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
            
        }
        #endregion

        #region Excluir Série
        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}
        #endregion

        #region Visualiar Série
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série que deseja consultar: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        #endregion

       

        

    }
}
