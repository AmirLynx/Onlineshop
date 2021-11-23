using System;
using System.Collections.Generic;
using Models;

namespace Data
{
    public class ContactRepository : IRepositoryContact
    {
        List<ContactEntity> contacts = new List<ContactEntity>();
        public void Add(ContactEntity contact)
        {
            contacts.Add(contact);
        }

        public void Delete(int id)
        {
            ContactEntity foundContact = null;

            var foundContactOrder = 0;

            foreach (var item in contacts)
            {
                if (id.Equals(item.ContactId))
                {
                    foundContact = item;
                    foundContactOrder = item.OrderCounter;
                    break;
                }

            }
            if (foundContact == null)
            {
                throw new NullReferenceException("Contact not found !");
            }
            if (foundContactOrder != 0)
            {
                throw new NullReferenceException("You cant delete this Contact (Contact has order)");
            }
            
            contacts.Remove(foundContact);
        }

        public List<ContactEntity> GetAll()
        {
            return contacts;
        }

        public ContactEntity GetById(int id)
        {
            ContactEntity foundContact = null;

            foreach (var item in contacts)
            {
                if(id.Equals(item.ContactId))
                {
                    foundContact = item;
                    break;
                }
            }
            
            return foundContact;
        }
        public ContactEntity ChekName(string name)
        {
            ContactEntity foundName = null;

            foreach (var item in contacts)
            {
                if(name.Equals(item.Name))
                {
                    foundName = item;
                    break;
                }
            }
            return foundName;
        }

        public void Update(ContactEntity contact)
        {
            ContactEntity foundContact = null;

            foreach (var item in contacts)
            {
                if (contact.ContactId == item.ContactId)
                {
                    foundContact = item;
                    break;
                }
            }
            if (foundContact == null)
            {
                throw new NullReferenceException("Contact not found !");
            }

            foundContact.Name = contact.Name;
            foundContact.PhoneNumber = contact.PhoneNumber;
            foundContact.Adress = contact.Adress;
        }
    }
}
