using System;
using ControleDeTarefas.Telas;

namespace ControleDeTarefas
{
    public class TelaTarefas
    {
        public string Menu()
        {
            Console.WriteLine("Digite 1 para inserir nova tarefa");
            Console.WriteLine("Digite 2 para visualizar as tarefas");
            Console.WriteLine("Digite 3 para visualizar por um Id específico");
            Console.WriteLine("Digite 4 para atualizar as tarefas");
            Console.WriteLine("Digite 5 para excluir uma tarefa");
           

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}