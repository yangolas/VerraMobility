﻿using Microsoft.EntityFrameworkCore;
using Prueba1.Repository.Contracts;
using Prueba1.Repository.Models.Context;
using Prueba1.Repository.Models.EntitiesRepository;

namespace Prueba1.Repository.Repositories;

public class ResultadoRepository : IResultadoRepository
{
    private readonly SqlServerContext _sqlServerContext;
    private Resultado? _resultado;

    public ResultadoRepository(SqlServerContext sqlServerContext)
    {
        _sqlServerContext = sqlServerContext;
    }

    public async Task<Resultado?> GetByIdsync(Guid id)
    {
        _resultado = await _sqlServerContext.Resultados
            .FirstOrDefaultAsync(resultado => resultado.Id == id);

        return _resultado;
    }

    public void CreateResultado(Resultado resultado)
    {
        _sqlServerContext.Add(resultado);
    }

    public void UpdateDescription(string description)
    {
        if (_resultado == null)
        {
            //Aqui podria crearme mis excepiones customizadas pero voy a usar las de por defecto
            throw new ArgumentNullException($"Ey, developer, you must sure of getting the entity for updated it in bd : {nameof(Resultado)} currently is null");
        }
        _resultado.Description = description;
    }
}