using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using Domain.RepositoryInterface;

namespace EF
{
    public class ContactRepository: Repository<Contact>, IContactRepository
    {

        public IList<Contact> GetListContactByGroupId(int groupId)
        {
            return null;
        }
    }
}
