using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pesagem_Industrial.DbConnect;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    public class UnidadeDAL : IUnidadeDAL
    {
        private PesagemIndustrialConnect db = new PesagemIndustrialConnect();

        public SelectList ListarMedidas(string tipo)
        {
            List<Unidade> medidasPrimario = new List<Unidade>();

            medidasPrimario = db.Unidades.Where(x => x.Tipo == tipo).ToList();

            SelectList medidas = new SelectList(medidasPrimario, "Id", "Medida");

            return medidas;
        }
    }
}