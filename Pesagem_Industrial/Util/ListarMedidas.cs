using Pesagem_Industrial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pesagem_Industrial.Util
{
    public static class ListarMedidas
    {
        public static Unidade Listar()
        {
            Unidade unidade = new Unidade();

            unidade.Tipos.Add("Massa");
            unidade.Tipos.Add("Comprimento");
            unidade.Tipos.Add("Capacidade");
            unidade.Tipos.Add("Unitário");
            return unidade;
        }
    }
}