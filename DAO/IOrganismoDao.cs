﻿using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IOrganismoDao
    {
        Task<DOrganismo> buscarorganismoXId(int id);

        Task<List<DOrganismo>> retornarListaOrganismos();
    }
}
