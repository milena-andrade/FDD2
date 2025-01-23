using System;
using System.Collections.Generic;
using System.Linq;

public class Medicamento
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Laboratorio { get; set; } = string.Empty;
    private Queue<Lote> lotes = new Queue<Lote>();

    public Medicamento() { }

    public Medicamento(int id, string nome, string laboratorio)
    {
        Id = id;
        Nome = nome;
        Laboratorio = laboratorio;
    }

    public int QtdeDisponivel()
    {
        return lotes.Sum(lote => lote.Qtde);
    }

    public void Comprar(Lote lote)
    {
        lotes.Enqueue(lote);
    }

    public bool Vender(int qtde)
    {
        if (qtde <= 0 || qtde > QtdeDisponivel()) return false;

        int quantidadeRestante = qtde;
        while (quantidadeRestante > 0 && lotes.Count > 0)
        {
            Lote loteAtual = lotes.Peek();
            if (loteAtual.Qtde > quantidadeRestante)
            {
                loteAtual.Qtde -= quantidadeRestante;
                return true;
            }
            else
            {
                quantidadeRestante -= loteAtual.Qtde;
                lotes.Dequeue();
            }
        }
        return true;
    }

    public override string ToString()
    {
        return $"{Id}-{Nome}-{Laboratorio}-{QtdeDisponivel()}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Medicamento medicamento && Id == medicamento.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public string ConsultarAnalitico()
    {
        string lotesDetalhes = lotes.Count > 0
            ? string.Join(Environment.NewLine, lotes.Select(lote => lote.ToString()))
            : "Nenhum lote disponível.";

        return $"{ToString()}\nLotes:\n{lotesDetalhes}";
    }
}
