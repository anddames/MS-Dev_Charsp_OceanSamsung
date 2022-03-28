using System;
using ProjetoElevador.Models;

namespace ProjetoElevador
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Elevador elevador = new Elevador();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Bem vindo ao software de elevador ");
            Console.WriteLine("--------------------------------------------------------");
            elevador.Inicializar();
            Console.ReadLine();
        }
        
    }

}