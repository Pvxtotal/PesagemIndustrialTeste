﻿using System.Collections.Generic;
using Pesagem_Industrial.Models;

namespace Pesagem_Industrial.DAL
{
    public interface IArmazemDAL
    {
        void InserirArmazem(Armazem armazem);
        IEnumerable<Armazem> ListarArmazens();

        void EditarArmazem(Armazem armazem);

        void ExcluirArmazem(Armazem armazem);
    }
}