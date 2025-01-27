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

        // Obter todas as compras
        public async Task<IEnumerable<Compra>> GetAllCompras()
        {
            var result = await _db.LoadData<Compra, dynamic>(
                storedProcedure: "spCompra_GetAll",
                parameters: new { }
            );

            return result;
        }

        // Obter todas as compras por administrador
        public async Task<IEnumerable<Compra>> GetAllComprasByAdminId(int adminId)
        {
            var result = await _db.LoadData<Compra, dynamic>(
                storedProcedure: "spCompra_GetAllByAdminId",
                parameters: new { IdAdministrador = adminId }
            );

            return result;
        }

        // Obter todas as vendas
        public async Task<IEnumerable<Venda>> GetAllVendas()
        {
            var result = await _db.LoadData<Venda, dynamic>(
                storedProcedure: "spVenda_GetAll",
                parameters: new { }
            );

            return result;
        }

        // Obter todas as vendas por administrador
        public async Task<IEnumerable<Venda>> GetAllVendasByAdminId(int adminId)
        {
            var result = await _db.LoadData<Venda, dynamic>(
                storedProcedure: "spVenda_GetAllByAdminId",
                parameters: new { IdAdministrador = adminId }
            );

            return result;
        }

        public async Task AddCompra(dynamic parameters)
        {
            await _db.SaveData("spInserirCompra", parameters);
        }

        public async Task AddVenda(dynamic parameters)
        {
            await _db.SaveData("spInserirVenda", parameters);
        }
    }
}

