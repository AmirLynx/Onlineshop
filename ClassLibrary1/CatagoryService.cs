using System;
using Data;
using Models;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CatagoryService
    {
        private readonly Context _context;

        public  CatagoryService()
        {
            _context = new Context();
        }
        public void Add(CatagoryEntity category)
        {
            _context.CategoryRepo.Add(category);
        }

        public void Delete(int id)
        {
            _context.CategoryRepo.Delete(id);
        }

        public List<CatagoryEntity> GetAll()
        {
            return _context.CategoryRepo.GetAll();
        }

        public CatagoryEntity GetById(int id)
        {
            return _context.CategoryRepo.GetById(id);
        }

        public void Update(CatagoryEntity category)
        {
            _context.CategoryRepo.Update(category);
        }
        public CatagoryEntity ChangeUse(int id)
        {
            return _context.CategoryRepo.ChangeUse(id);
        }
    }
}
