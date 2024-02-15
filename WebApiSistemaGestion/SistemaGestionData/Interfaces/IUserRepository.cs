﻿using Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Interfaces
{
    public interface IUserRepository
    {
        Usuario GetById(int id);
        IEnumerable<Usuario> GetAll();
        bool Add(Usuario usuario);
        int Delete(int id);
        bool Update(int id, Usuario user);
    }
}
