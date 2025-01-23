using System;
using System.Collections.Generic;

public class Medicamentos
{
    private List<Medicamento> listaMedicamentos = new List<Medicamento>();

    public void Adicionar(Medicamento medicamento)
    {
        listaMedicamentos.Add(medicamento);
    }

    public bool Deletar(Medicamento medicamento)
    {
        if (medicamento.QtdeDisponivel() == 0)
        {
            return listaMedicamentos.Remove(medicamento);
        }
        return false;
    }

    public Medicamento Pesquisar(int id)
    {
        return listaMedicamentos.Find(m => m.Id == id) ?? new Medicamento();
    }

    public List<Medicamento> Listar()
    {
        return listaMedicamentos;
    }
}
