using MontagemBelasPizzas.Data.Entities.Produtos;
using MontagemBelasPizzas.Data.Repositories.Produtos;

namespace MontagemBelasPizzas.Business.Services.Produtos
{
    public class LinhaDeMontagemService
    {
        private readonly LinhaDeMontagemRepository _linhaDeMontagemRepository;

        public LinhaDeMontagemService(LinhaDeMontagemRepository linhaDeMontagemRepository)
        {
            _linhaDeMontagemRepository = linhaDeMontagemRepository;
        }

        public async Task<LinhaDeMontagem?> GetLinhaDeMontagemById(int id)
        {
            return await _linhaDeMontagemRepository.GetById(id);
        }

        public async Task<IEnumerable<LinhaDeMontagem>> GetAllLinhasDeMontagem()
        {
            return await _linhaDeMontagemRepository.GetAll();
        }

        public async Task CreateLinhaDeMontagem(LinhaDeMontagem linha)
        {
            await _linhaDeMontagemRepository.Insert(linha);
        }

        public async Task UpdateLinhaDeMontagem(LinhaDeMontagem linha)
        {
            await _linhaDeMontagemRepository.Update(linha);
        }

        public async Task DeleteLinhaDeMontagem(int id)
        {
            await _linhaDeMontagemRepository.Delete(id);
        }
    }
}
