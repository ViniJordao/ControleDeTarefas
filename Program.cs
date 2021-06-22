using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Telas;
using ControleDeTarefas.Controladores;

namespace ControleDeTarefas
{
    public class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            TelaAgenda telaAgenda = new TelaAgenda();
            TelaTarefas telaTarefa = new TelaTarefas();

            Tarefas tarefa = new Tarefas(1, "aaa", new DateTime(2021, 10, 10), new DateTime(2021, 09, 10), "Normal", "50%");
            Agenda agenda = new Agenda(1, "João", "joaodasilva@teste.com", "99485206", "petrobras", "diretor");

            ControladorTarefas controladorTarefas = new ControladorTarefas();
            ControladorAgenda controladorAgenda = new ControladorAgenda();

            while (true)
            {
                string opcao = telaPrincipal.MenuPrincipal();
                Console.Clear();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    break;

                if (opcao == "1")
                {
                    string opcaoMenu = telaTarefa.Menu();
                    Console.Clear();

                    if (opcaoMenu.Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (opcaoMenu == "1")
                    {

                        controladorTarefas.InserirTarefa(tarefa);

                    }
                    else if (opcaoMenu == "2")
                    {
                        controladorTarefas.SelecionarTodasTarefas();
                    }
                    else if (opcaoMenu == "3")
                    {
                        int id = tarefa.Id;

                        Tarefas tarefasSelecionada = controladorTarefas.SelecionarTarefasPorId(id);

                        Console.WriteLine(tarefasSelecionada.Titulo);
                    }
                    else if (opcaoMenu == "4")
                    {
                        controladorTarefas.AtualizarTarefas(tarefa);

                        tarefa.Titulo = "Limpar o Pc";
                        tarefa.DataCriacao = new DateTime(2021, 12, 10);
                        tarefa.DataFinalizacao = DateTime.Now;
                        tarefa.Prioridade = "Baixo";
                        tarefa.Percentual = "50%";
                    }
                    else if (opcaoMenu == "5")
                    {
                        controladorTarefas.ExcluirTarefas(tarefa);
                    }
                    Console.ReadKey();
                }


                else if (opcao == "2")
                {
                    string opcaoMenu = telaAgenda.Menu();
                    Console.Clear();
                    if (opcaoMenu == "1")
                    {

                        controladorAgenda.InserirNaAgenda(agenda);

                    }
                    else if (opcaoMenu == "2")
                    {
                        controladorAgenda.SelecionarTodasAgenda();
                    }
                    else if (opcaoMenu == "3")
                    {
                        int id = agenda.Id;

                        Agenda contatoSelecionado = controladorAgenda.SelecionarAgendaPorId(id);
                       
                        Console.WriteLine(contatoSelecionado.Nome);
                    }
                    else if (opcaoMenu == "4")
                    {
                        controladorAgenda.AtualizarAgenda(agenda);


                        agenda.Nome = "José";
                        agenda.Email = "josesouza@teste.com";
                        agenda.Telefone = "88525474";
                        agenda.Empresa = "Shell";
                        agenda.Cargo = "Gerente";
                    }
                    else if (opcaoMenu == "5")
                    {
                        controladorAgenda.ExcluirAgenda(agenda);
                    }
                }
            }
        }
    }
}
