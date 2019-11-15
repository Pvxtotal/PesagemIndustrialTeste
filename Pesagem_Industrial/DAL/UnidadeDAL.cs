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
        public SelectList ListarMedidas(string tipo)
        {
            using (PesagemIndustrialConnect db = new PesagemIndustrialConnect())
            {
                List<Unidade> medidasPrimario = new List<Unidade>();

                medidasPrimario = db.Unidades.Where(x => x.Tipo == tipo).ToList();

                SelectList medidas = new SelectList(medidasPrimario, "Id", "Medida");

                return medidas;
            }

        }
    }
}