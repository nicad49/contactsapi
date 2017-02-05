using ContactsApi.Models;
using System.Collections.Generic;

namespace ContactsApi.Repository 
{

  public interface IContactsRepository 
  {
    void Add(Contact item);
    IEnumerable<Contact> GetAll();
    Contact Find(string key);
    void Remove(string id);
    void Update(Contact item);
  }
}