using IP.Desafio.Application.Models;
namespace IP.Desafio.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        bool Criar(UsuarioViewModel model);
    }
}
