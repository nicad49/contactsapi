using System.Collections.Generic;
using System.Linq;
using ContactsApi.Models;
using ContactsApi.Contexts;

namespace ContactsApi.Repository
{
  public class ContactsRepository : IContactsRepository
  {
    ContactsContext _context;

    public ContactsRepository(ContactsContext context)
    {
      _context = context;
    }

    public void Add(Contact item)
    {
      _context.Contacts.Add(item);
      _context.SaveChanges();
    }

    public Contact Find(string key)
    {
      return _context.Contacts
        .Where(e => e.MobilePhone.Equals(key))
        .SingleOrDefault();
    }

    public IEnumerable<Contact> GetAll()
    {
      return _context.Contacts.ToList();
    }

    public void Remove(string id)
    {
      var itemToRemove = _context.Contacts.SingleOrDefault(r => r.MobilePhone == id);
      if (itemToRemove != null)
      {
        _context.Contacts.Remove(itemToRemove);
      }
    }

    public void Update(Contact item)
    {
      var itemToUpdate = _context.Contacts.SingleOrDefault(r => r.MobilePhone == item.MobilePhone);
      if (itemToUpdate != null)
      {
        itemToUpdate.FirstName = item.FirstName;
        itemToUpdate.LastName = item.LastName;
        itemToUpdate.IsFamilyMember = item.IsFamilyMember;
        itemToUpdate.Company = item.Company;
        itemToUpdate.JobTitle = item.JobTitle;
        itemToUpdate.Email = item.Email;
        itemToUpdate.MobilePhone = item.MobilePhone;
        itemToUpdate.DateOfBirth = item.DateOfBirth;
        itemToUpdate.AnniversaryDate = item.AnniversaryDate;
      }
    }
    // static List<Contact> ContactList = new List<Contact>();

    // public void Add(Contact item)
    // {
    //   ContactList.Add(item);
    // }

    // public Contact Find(string key)
    // {
    //   return ContactList
    //     .Where(e => e.MobilePhone.Equals(key))
    //     .SingleOrDefault();
    // }

    // public IEnumerable<Contact> GetAll()
    // {
    //   return ContactList;
    // }

    // public void Remove(string id)
    // {
    //   var itemToRemove = ContactList.SingleOrDefault(r => r.MobilePhone == id);
    //   if (itemToRemove != null)
    //   {
    //     ContactList.Remove(itemToRemove);
    //   }
    // }

    // public void Update(Contact item)
    // {
    //   var itemToUpdate = ContactList.SingleOrDefault(r => r.MobilePhone == item.MobilePhone);
    //   if (itemToUpdate != null)
    //   {
    //     itemToUpdate.FirstName = item.FirstName;
    //     itemToUpdate.LastName = item.LastName;
    //     itemToUpdate.IsFamilyMember = item.IsFamilyMember;
    //     itemToUpdate.Company = item.Company;
    //     itemToUpdate.JobTitle = item.JobTitle;
    //     itemToUpdate.Email = item.Email;
    //     itemToUpdate.MobilePhone = item.MobilePhone;
    //     itemToUpdate.DateOfBirth = item.DateOfBirth;
    //     itemToUpdate.AnniversaryDate = item.AnniversaryDate;
    //   }
    // }
  }
}