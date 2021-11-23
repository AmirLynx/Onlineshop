using System;
using Models;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IRepositoryContact
    {
        void Add(ContactEntity contact);
        List<ContactEntity> GetAll();
        ContactEntity GetById(int id);
        ContactEntity ChekName(string name);
        void Update(ContactEntity contact);
        void Delete(int id);
        
    }
}
