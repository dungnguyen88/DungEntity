using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.RepositoryInterface;
using Domain.Entity;
using DungEntity.Models;

namespace DungEntity.Controllers
{
    public class ContactController : Controller
    {
        private IContactRepository ContactRepository;
        private IRepository<Group> GroupRepostiroy;

        public ContactController(IContactRepository contactRepostory, IRepository<Group> groupRepository)
        {
            this.ContactRepository = contactRepostory;
            this.GroupRepostiroy = groupRepository;
        }

        public ActionResult Index()
        {
            //Group gr1 = new Group { Title = "Group1", Description = "Group1", NumberOfContact = 3 };
            //GroupRepostiroy.Add(gr1);

            //ContactRepository.Add(new Contact { Name = "Dung1", Email = "dungnhik@aaa.com", Birthday = new DateTime(2012, 12, 12), Group = gr1 });
            //ContactRepository.Add(new Contact { Name = "Dung2", Email = "dungnhik@aaa.com", Birthday = new DateTime(2012, 12, 12), Group = gr1 });
            //ContactRepository.Add(new Contact { Name = "Dung3", Email = "dungnhik@aaa.com", Birthday = new DateTime(2012, 12, 12), Group = gr1 });

            //ContactRepository.Save();

            IList<Contact> lst = ContactRepository.GetAll().ToList();

            return View(lst);
        }

        public ActionResult Delete(int Id)
        {
            Contact c = ContactRepository.GetById(Id);
            ContactRepository.Delete(c);

            ContactRepository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            Contact c = ContactRepository.GetById(Id);
            ContactEditModel model = new ContactEditModel() { Id = c.Id, Name = c.Name, Email = c.Email };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Contact c)
        {
            Contact c2 = ContactRepository.GetById(c.Id);
            c2.Name = c.Name;
            c2.Email = c.Email;
            ContactRepository.Update(c2);
            ContactRepository.Save();

            return RedirectToAction("Index");
        }
    }
}