using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Data
{
    class CatagoryRepository : IRepositoryCatagory
    {
        List<CatagoryEntity> categories = new List<CatagoryEntity>();
        public void Add(CatagoryEntity category)
        {
            categories.Add(category);
        }

        public CatagoryEntity ChangeUse(int id)
        {
            CatagoryEntity foundCategory = null;

            foreach (var item in categories)
            {
                if (id.Equals(item.Id))
                {
                    foundCategory = item;
                    break;
                }

            }
            return foundCategory;
        }

        public void Delete(int id)
        {
            CatagoryEntity foundCategory = null;
            
            foreach (var item in categories)
            {
                if (id.Equals(item.Id) && item.used != CatagoryEntity.Used.used)
                {
                    foundCategory = item;
                    break;
                }

            }

            categories.Remove(foundCategory);
        }

        public List<CatagoryEntity> GetAll()
        {
            return categories;
        }

        public CatagoryEntity GetById(int id)
        {
            CatagoryEntity foundCategory = null;

            foreach (var item in categories)
            {
                if (id.Equals(item.Id))
                {
                    foundCategory = item;
                    break;
                }

            }
            
            return foundCategory;
        }

        public void Update(CatagoryEntity category)
        {
            CatagoryEntity foundCategory = null;

            foreach (var item in categories)
            {
                if (category.Id == item.Id)
                {
                    foundCategory = item;
                    break;
                }
            }

            foundCategory.Name = category.Name;
            foundCategory.used = category.used;
        }
    }
}
