using MontagemBelasPizzas.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MontagemBelasPizzas.Data.Entities.Utilizadores;

namespace MontagemBelasPizzas.Data.Repositories.Utilizadores
{
    public class UtilizadorRepository
    {
        private readonly ISqlDataAccess _db;

        public UtilizadorRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<Utilizador?> GetById(int id)
        {
            var parameters = new { Id = id };
            var result = await _db.LoadData<Utilizador, dynamic>(
                storedProcedure: "spUtilizador_GetById",
                parameters: parameters
            );

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Utilizador>> GetAll()
        {
            var result = await _db.LoadData<Utilizador, dynamic>(
                storedProcedure: "spUtilizador_GetAll",
                parameters: new { }
            );

            return result;
        }

        public async Task Insert(Utilizador utilizador)
        {
            var parameters = new
            {
                utilizador.Nome,
                utilizador.Senha,
                utilizador.NIF,
                utilizador.DataDeNascimento,
                utilizador.DataDeCriacao,
                utilizador.ImagemUrl,
                utilizador.Tipo
            };

            await _db.SaveData(
                storedProcedure: "spUtilizador_Insert",
                parameters: parameters
            );
        }

        public async Task Update(Utilizador utilizador)
        {
            var parameters = new
            {
                utilizador.Nome,
                utilizador.Senha,
                utilizador.NIF,
                utilizador.DataDeNascimento,
                utilizador.DataDeCriacao,
                utilizador.ImagemUrl,
                utilizador.Tipo
            };

            await _db.SaveData(
                storedProcedure: "spUtilizador_Update",
                parameters: parameters
            );
        }

        public async Task Delete(int id)
        {
            var parameters = new { Id = id };

            await _db.SaveData(
                storedProcedure: "spUtilizador_Delete",
                parameters: parameters
            );
        }
    }
}
