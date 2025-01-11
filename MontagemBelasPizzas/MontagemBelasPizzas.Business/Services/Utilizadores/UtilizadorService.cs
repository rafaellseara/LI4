using MontagemBelasPizzas.Data.Entities.Utilizadores;
using MontagemBelasPizzas.Data.Repositories.Utilizadores;

namespace MontagemBelasPizzas.Business.Services.Utilizadores;

public class UtilizadorService
{
    private readonly UtilizadorRepository _utilizadorRepository;

    public UtilizadorService(UtilizadorRepository utilizadorRepository)
    {
        _utilizadorRepository = utilizadorRepository;
    }

    public async Task<Utilizador?> GetUtilizadorById(int id)
    {
        return await _utilizadorRepository.GetById(id);
    }

    public async Task<IEnumerable<Utilizador>> GetAllUtilizadores()
    {
        return await _utilizadorRepository.GetAll();
    }

    public async Task CreateUtilizador(Utilizador utilizador)
    {
        await _utilizadorRepository.Insert(utilizador);
    }

    public async Task UpdateUtilizador(Utilizador utilizador)
    {
        await _utilizadorRepository.Update(utilizador);
    }

    public async Task DeleteUtilizador(int id)
    {
        await _utilizadorRepository.Delete(id);
    }
}

