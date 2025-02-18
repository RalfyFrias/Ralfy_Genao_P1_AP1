using Microsoft.EntityFrameworkCore;
using Ralfy_Genao_P1_AP1.DAL;
using Ralfy_Genao_P1_AP1.Models;
using System.Linq;
using System.Linq.Expressions;

namespace Ralfy_Genao_P1_AP1.Services
{
        public class AporteServices(IDbContextFactory<Contexto> DbFactory)
    {
        // Método Existe
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aporte
                .AnyAsync(a => a.AporteId == id);
        }

        // Método para verificar si el nombre del aporte ya está registrado en la base de datos
        public async Task<bool> ExistePersonaAporte(string persona, int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aporte
                .AnyAsync(a => a.Persona.ToLower().Equals(persona.ToLower()) && a.AporteId != id);
        }

        // Método Insertar
        private async Task<bool> Insertar(Aporte aporte)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Aporte.Add(aporte);
            return await contexto.SaveChangesAsync() > 0;
        }

        // Método Modificar
        private async Task<bool> Modificar(Aporte aporte)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(aporte);
            return await contexto.SaveChangesAsync() > 0;
        }

        // Método Guardar
        public async Task<bool> Guardar(Aporte aporte)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            if (!await Existe(aporte.AporteId))
                return await Insertar(aporte);
            else
                return await Modificar(aporte);
        }

        // Método Eliminar
        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var eliminarAporte = await contexto.Aporte
                .Where(a => a.AporteId == id)
                .ExecuteDeleteAsync();
            return eliminarAporte > 0;
        }

        // Método Buscar
        public async Task<Aporte?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aporte
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AporteId == id);
        }
        // Método ObtenerSiguienteId
        public async Task<int> ObtenerSiguienteId()
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var ultimoId = await contexto.Aporte.MaxAsync(a => (int?)a.AporteId) ?? 0;
            return ultimoId + 1;
        }
        // Método Listar con criterio
        public async Task<List<Aporte>> Listar(Expression<Func<Aporte, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aporte
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        // Método Listar todos los aportes
        public async Task<List<Aporte>> ListarAportes()
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aporte
                .AsNoTracking()
                .ToListAsync();
        }
    }
}