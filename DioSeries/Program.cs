using System;

namespace DioSeries{

    class Program{
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args){
            string opcaoUsuario = obterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                        listarSeries();
                    break;
                    case "2":
                        inserirSerie();
                    break;
                    case "3":
                        atualizarSerie();
                    break;
                    case "4":
                        excluirSerie();
                    break;
                    case "5":
                        visualizarSerie();
                    break;
                    case "C":
                        Console.Clear();
                    break;
                    default:
                        Console.WriteLine("Opção invalida...");
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = obterOpcaoUsuario();

            }

            Console.WriteLine("Final.");
			Console.ReadLine();
        }

        private static void excluirSerie(){
            int idSerie = obterIdSerie();

            Console.WriteLine("Confirmar exclusão(S/N): ");
            string confirmar = Console.ReadLine().ToUpper();

            if(confirmar.Equals("S")){
                repositorio.excluir(idSerie);
                Console.WriteLine("Série excluida");
            }
            else
                Console.WriteLine("Série não excluida.");
        }

        private static void visualizarSerie(){

            

            var serie = repositorio.retornaPorId(obterIdSerie());

            Console.WriteLine(serie);

        }

        private static void atualizarSerie(){

            int indiceSerie = obterIdSerie();

            repositorio.atualizar(indiceSerie, gerarSerie(indiceSerie));
            

            

        }


        private static void listarSeries(){

            Console.WriteLine("Listar séries:");

            var listaTemporaria = repositorio.lista();

            if(listaTemporaria.Count == 0){

                Console.WriteLine("Nenhuma série cadastrada.");
                return;

            }

            foreach(var s in listaTemporaria){

                var excluido = s.getExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", s.getId(), s.getTitulo(), (excluido ? "*Excluido*" : ""));

            }

        }

        private static void inserirSerie(){
            Console.WriteLine("Inserir nova série");

            repositorio.insere(gerarSerie(repositorio.proximoId()));
        }

        
        private static Serie gerarSerie(int indice){

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: indice, genero: (Genero)entradaGenero, titulo: entradaTitulo, 
                                                descricao: entradaDescricao, ano: entradaAno);
            
            return novaSerie;

            

        }


        private static int obterIdSerie(){
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            return indiceSerie;
        }

        private static string obterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Listar série");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair" + Environment.NewLine);

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            
            return opcao;
        }
    }

}