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

        // Obter todas as vendas por mes
        public async Task<List<int>> GetSalesPerMonth()
        {
            var result = await _db.LoadData<dynamic, dynamic>(
                storedProcedure: "spSalesPerMonth",
                parameters: new { }
            );

            var salesPerMonth = new int[12];
            foreach (var row in result)
            {
                salesPerMonth[row.Mes - 1] = row.NumeroDeVendas;
            }

            Console.WriteLine("RAFA" + salesPerMonth.ToList());

            return salesPerMonth.ToList();
        }

        // Obter todas as compras por mes 
        public async Task<List<int>> GetBuysPerMonth()
        {
            var result = await _db.LoadData<dynamic, dynamic>(
                storedProcedure: "spBuysPerMonth",
                parameters: new { }
            );

            var buysPerMonth = new int[12];
            foreach (var row in result)
            {
                buysPerMonth[row.Mes - 1] = row.NumeroDeCompras;
            }

            Console.WriteLine("RAFA" + buysPerMonth.ToList());

            return buysPerMonth.ToList();
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

