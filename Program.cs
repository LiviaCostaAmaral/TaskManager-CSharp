using System;

class Program
{
    static void Main()
    {
        TarefaService service = new TarefaService();
        service.CarregarArquivo();

        int opcao;

        do
        {
            Console.WriteLine("\n===== TASK MANAGER =====");
            Console.WriteLine("1 - Adicionar tarefa");
            Console.WriteLine("2 - Listar tarefas");
            Console.WriteLine("3 - Concluir tarefa");
            Console.WriteLine("4 - Remover tarefa");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("Descrição: ");
                    string desc = Console.ReadLine();
                    service.Adicionar(desc);
                    break;

                case 2:
                    service.Listar();
                    break;

                case 3:
                    Console.Write("ID: ");
                    int idC = int.Parse(Console.ReadLine());
                    service.Concluir(idC);
                    break;

                case 4:
                    Console.Write("ID: ");
                    int idR = int.Parse(Console.ReadLine());
                    service.Remover(idR);
                    break;
            }

        } while (opcao != 0);
    }
}