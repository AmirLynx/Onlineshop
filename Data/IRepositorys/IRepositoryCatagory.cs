using System;
using Models;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IRepositoryCatagory
    {
        void Add(CatagoryEntity category);
        List<CatagoryEntity> GetAll();
        CatagoryEntity GetById(int id);
        void Update(CatagoryEntity category);
        CatagoryEntity ChangeUse(int id);
        void Delete(int id);
    }
}
