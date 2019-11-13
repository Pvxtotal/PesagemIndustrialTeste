using System.Web.Mvc;

namespace Pesagem_Industrial.DAL
{
    public interface IUnidadeDAL
    {
        SelectList ListarMedidas(string tipo);
    }
}