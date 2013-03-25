using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;

namespace Domain.RepositoryInterface
{
    public interface IContactRepository: IRepository<Contact>
    {
        IList<Contact> GetListContactByGroupId(int groupId);
    }
}
