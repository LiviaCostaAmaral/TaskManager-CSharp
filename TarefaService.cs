using System;
using System.Collections.Generic;
using System.IO;

public class TarefaService
{
    private List<Tarefa> tarefas = new List<Tarefa>();
    private int proximoId = 1;
    private string arquivo = "tarefas.txt";

    public void Adicionar(string descricao)
    {
        Tarefa t = new Tarefa
        {
            Id = proximoId++,
            Descricao = descricao,
            Concluida = false
        };

        tarefas.Add(t);
        SalvarArquivo();
    }

    public void Listar()
    {
        if (tarefas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.");
            return;
        }

        foreach (var t in tarefas)
        {
            string status = t.Concluida ? "✔" : "⏳";
            Console.WriteLine($"{t.Id} - {t.Descricao} [{status}]");
        }
    }

    public void Concluir(int id)
    {
        var tarefa = tarefas.Find(t => t.Id == id);

        if (tarefa != null)
        {
            tarefa.Concluida = true;
            SalvarArquivo();
        }
    }

    public void Remover(int id)
    {
        var tarefa = tarefas.Find(t => t.Id == id);

        if (tarefa != null)
        {
            tarefas.Remove(tarefa);
            SalvarArquivo();
        }
    }

    private void SalvarArquivo()
    {
        using (StreamWriter sw = new StreamWriter(arquivo))
        {
            foreach (var t in tarefas)
            {
                sw.WriteLine($"{t.Id};{t.Descricao};{t.Concluida}");
            }
        }
    }

    public void CarregarArquivo()
    {
        if (!File.Exists(arquivo)) return;

        string[] linhas = File.ReadAllLines(arquivo);

        foreach (var linha in linhas)
        {
            var partes = linha.Split(';');

            Tarefa t = new Tarefa
            {
                Id = int.Parse(partes[0]),
                Descricao = partes[1],
                Concluida = bool.Parse(partes[2])
            };

            tarefas.Add(t);

            if (t.Id >= proximoId)
                proximoId = t.Id + 1;
        }
    }
}