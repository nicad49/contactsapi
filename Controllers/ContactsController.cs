using ContactsApi.Models;
using ContactsApi.Repository;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace ContactsApi.Controllers
{
  [Route("api/[controller]")]
  public class ContactsController : Controller
  {
    public IContactsRepository ContactsRepo { get; set; }
    public ContactsController(IContactsRepository _repo)
    {
      ContactsRepo = _repo;
    }

    [HttpGet]
    public IEnumerable<Contact> GetAll()
    {
      var tmpcontacts = ContactsRepo.GetAll();
      return ContactsRepo.GetAll();
    }

    [HttpGetAttribute("{id}", Name = "GetContacts")]
    public IActionResult GetById(string id)
    {
      var item = ContactsRepo.Find(id);
      if (item == null)
      {
        return NotFound();
      }
      return new ObjectResult(item);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Contact item)
    {
      if (item == null)
      {
        return BadRequest();
      }
      ContactsRepo.Add(item);
      return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.MobilePhone }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] Contact item)
    {
      if (item == null)
      {
        return BadRequest();
      }
      var contactObj = ContactsRepo.Find(id);
      if (contactObj == null)
      {
        return NotFound();
      }
      ContactsRepo.Update(item);
      return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public void Delete(string id)
    {
      ContactsRepo.Remove(id);
    }
  }
}