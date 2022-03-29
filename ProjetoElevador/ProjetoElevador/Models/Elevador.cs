using System;
namespace ProjetoElevador.Models
{
    /// <summary>
    /// clase Elevador onde temo a inicilização e o metodo que controla o elevador instanciado
    /// </summary>
    public class Elevador
    {
        /// <summary>
        /// Capacidade total do elevado já definida
        /// </summary>
        public int CapacidadeTotal { get; set; } = 15; 

        /// <summary>
        /// Total de andares do predio já com definição
        /// </summary>
        public int TotalDeAndaresDoPredio { get; set; } = 20;

        /// <summary> 
        /// incia-se o elevador do terreo 
        /// </summary>
        int andarAtual = 1; 
        int andarDesejado;
        int qtdPessoas;


        /// <summary> 
        /// iniciar o elevador
        /// </summary> 
        public void Inicializar() 

        {
            Entrar();
            string escolhaUsuario = OpcaoUsuario();
            while (escolhaUsuario.ToUpper() != "E")
            {
                switch (escolhaUsuario)
                {
                    case "S":
                        Subir();
                        break;
                    case "D":
                        Descer();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                escolhaUsuario = OpcaoUsuario();
            }
        }

        /// <summary>
        /// Metodo que faz o elevador Subir para o andar desejado pelo usuário
        /// </summary>
        public void Subir()
        {
            NovoAndar:
            // <summary>A primeira partir será subir pois o elavador está sendo inicializador do terreo</summary>
            Console.WriteLine("Qual é o Andar desejado ?");
            andarDesejado = Int32.Parse(Console.ReadLine());

            if (andarDesejado < 0 || andarDesejado > TotalDeAndaresDoPredio) // <summary> Verificar se o anadr selcionador pelo usuario é valido </summary>
            {
                Console.WriteLine("Andar inválido!!! Selecione um andar válido");
                goto NovoAndar;
            }
            else if (andarAtual <= andarDesejado ) // <summary>verificar se o andar desejador pelo usuario está acima ou no mesmo andar que o atual </summary>
            {
                for (int andar = andarAtual ; andar <= TotalDeAndaresDoPredio; andar++) // <summary>Este For pecorre os andares está chega o destino desejado pelo usuario </summary>
                {
                    if (andar == andarDesejado) // <summary> esté if dentro do for verificar se nesse interação com o for o andar desejado já chegou  </summary>
                    {
                        break;
                    }
                    andarAtual = andar;
                }
                // <summary> Mostra o andar que o elevador está parado </summary>
                Console.WriteLine("Seu Andar Chegou");
                Sair();
                Console.WriteLine("irá Entra alguém ?");
                Entrar();
            }
            else // <summary> Caso o andar seja menor que o condição ele ira exibir uma mensagem para o usuario </summary>
                Console.WriteLine("O andar já foi passado ou encontra-se no andar !!!");
        }

        /// <summary>
        /// Metodo que fazr o elevador Descer para o andar desejado pelo usuário
        /// </summary>
        public void Descer() 
        {
            NovoAndar:
            // <summary>A primeira partir será subir pois o elavador está sendo inicializador do terreo </summary>
            Console.WriteLine("Qual é o Andar desejado ?");
            andarDesejado = Int32.Parse(Console.ReadLine());

            if (andarDesejado < 0 || andarDesejado > TotalDeAndaresDoPredio) // <summary> Verificar se o andar selecionador pelo usuario é valido </summary>
            {
                Console.WriteLine("Andar inválido!!! Selecione um andar válido");
                goto NovoAndar;
            }
            else if (andarAtual >= andarDesejado) // <summary> verificar se o andar desejador pelo usuario está abaixo ou no mesmo andar que o atual </summary>
            {
                for (int andar = andarAtual ; andar >= 0; andar--) // <summary>Este For pecorre os andares está chega o destino desejado pelo usuario </summary>
                {
                    if (andar == andarDesejado) // <summary> esté if dentro do for verificar se nesse interação com o for o andar desejado já chegou </summary>
                    {
                        break;
                    }
                    andarAtual = andar;
                }
                // <summary> Mostra o andar que o elevador está parado </summary>
                Console.WriteLine("Seu Andar Chegou");
                Sair();
                Console.WriteLine("irá Entra alguém ?");
                Entrar();
            }
            else // <summary> Caso o andar seja maior que o condição ele ira exibir uma mensagem para o usuario </summary>
                Console.WriteLine("O andar já foi passado ou encontra-se no andar !!!");
        }
        /// <summary>
        /// Metodo para inserir pessoas no elevador
        /// </summary>
        public void Entrar() 
        {
            NovaEntrada:
            //**
            //* <summary> Aqui ele Perguntar para o usuario quantas pessoas irão entra
            //* para pode verificar se não ultrapassar a capacidad total do elavador </summary>*//
            Console.WriteLine("Quantas pessoas irão entra ?");
            int entradaDePessoa = Int32.Parse(Console.ReadLine());
            if (entradaDePessoa <= CapacidadeTotal) // <summary> Verificar se a capacidade do elevador foi totalmente preenchida </summary>
            {
                qtdPessoas =+ entradaDePessoa ;
            }
            else // <summary>aqui caso a capicidade estoure ele avisa o usuario. </summary>
            {
                Console.WriteLine("A capacidade Do elevador Foi atiginda. Por favor diminuir a quantidade de pessoas");
                goto NovaEntrada;
            }
            
            // <summary>Mostra a quantidade de pessoas dentro do elevador </summary>
            Console.WriteLine($"São {qtdPessoas} pessoas no elevador");
        }

        /// <summary>
        /// Metodo para tirar pessoas do elevador
        /// </summary>
        public void Sair() 
        {
            // <summary>Ele Pergunta se saiu alguma pessoa no andar parado </summary>
            Console.WriteLine("Quantas Pessoas irão Sair ?");
            int saidaDePessoas = Int32.Parse(Console.ReadLine());
            
            if (qtdPessoas > 0) // <summary> Verificar se tem alguma pessoa para se removida </summary>
            {
                qtdPessoas = qtdPessoas - saidaDePessoas;
            }
            else // <summary> caso não tenha nehuma pessoa ele informa ao usuário </summary>
                Console.WriteLine("Não tem niguém no elevador");

            // <summary>Mostra a quantidade de pessoas dentro do elevador </summary>
            Console.WriteLine($"Ainda tem {qtdPessoas} pessoas no elevador");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string OpcaoUsuario()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Deseja Subir ou Descer ?");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("D - Descer");
            Console.WriteLine("S - Subir");
            Console.WriteLine("E - Exit");
            Console.WriteLine("--------------------------------------------------------");
            string escolhaUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return escolhaUsuario;
        }
    }
}