using System;
using System.Collections.Generic;
using Data;
using Models;

namespace Service
{
    public class ContactService
    {
        private readonly Context _context;
        public ContactService()
        {
            _context = new Context();
        }
        public void Add(ContactEntity contact)
        {
            _context.ContactRepo.Add(contact);
        }
        public List<ContactEntity> GetAll()
        {
            return _context.ContactRepo.GetAll();
        }
        public ContactEntity GetById(int id)
        {
            return _context.ContactRepo.GetById(id);
        }
        public ContactEntity ChekName(string name)
        {
            return _context.ContactRepo.ChekName(name);
        }
        public void Update(ContactEntity contact)
        {
            _context.ContactRepo.Update(contact);
        }
        public void Delete(int id)
        {
            _context.ContactRepo.Delete(id);
        }
    }
}
