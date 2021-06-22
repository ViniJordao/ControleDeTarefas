using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Telas
{
    public class TelaAgenda
    {
        public string Menu()
        {
            Console.WriteLine("Digite 1 para inserir novo contato");
            Console.WriteLine("Digite 2 para visualizar os contatos");
            Console.WriteLine("Digite 3 para visualizar um contato por Id específico");
            Console.WriteLine("Digite 4 para atualizar os contatos");
            Console.WriteLine("Digite 5 para excluir um contato");


            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
