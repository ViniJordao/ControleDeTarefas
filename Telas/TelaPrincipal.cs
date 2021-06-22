using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Telas
{
    public class TelaPrincipal
    {
        public string MenuPrincipal()
        {
            Console.WriteLine("Digite 1 para tarefas");
            Console.WriteLine("Digite 2 para agenda");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
