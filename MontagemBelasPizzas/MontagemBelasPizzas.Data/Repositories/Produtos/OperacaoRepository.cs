using MontagemBelasPizzas.Data.Entities.Produtos;
using MontagemBelasPizzas.Data.Interfaces;

namespace MontagemBelasPizzas.Data.Repositories.Produtos
{
    public class OperacaoRepository
    {
        private readonly ISqlDataAccess _db;

        public OperacaoRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<Operacao?> GetById(int id)
        {
            var parameters = new { Id = id };
            var result = await _db.LoadData<Operacao, dynamic>(
                storedProcedure: "spOperacao_GetById",
                parameters: parameters
            );

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Operacao>> GetAll()
        {
            var result = await _db.LoadData<Operacao, dynamic>(
                storedProcedure: "spOperacao_GetAll",
                parameters: new { }
            );

            return result;
        }

        public async Task Insert(Operacao operacao)
        {
            var parameters = new
            {
                operacao.Quantidade,
                operacao.ValorUnitario,
                operacao.ValorTotal,
                operacao.DataDaOperacao,
                operacao.IdAdministrador
            };

            await _db.SaveData("spOperacao_Insert", parameters);
        }

        public async Task Delete(int id)
        {
            var parameters = new { Id = id };
            await _db.SaveData("spOperacao_Delete", parameters);
        }
    }
}
