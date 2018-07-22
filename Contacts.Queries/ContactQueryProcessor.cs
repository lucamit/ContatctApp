using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Api.Common.Exceptions;
using Contacts.Data.Access.DAL;
using Contacts.Data.Model;
using Contacts.Queries;

namespace Contacts.Queries
{
    public class ContactQueryProcessor :IContactQueryProcessor
    {

        private readonly Func<IUnitOfWork> _unitOfWork;

        public ContactQueryProcessor( Func<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Contact> Get()
        {
           return _unitOfWork().Query<Contact>();
        }

        public Contact Get(long id)
        {
            var contact = Get().SingleOrDefault(x => x.Id == id);
            if (contact == null)
            {
                throw new ContactException("Not Exists");
            }

            return contact;
        }

        public Contact Create(Contact contactModel)
        {
            
            var contact = new Contact
            {
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                Email = contactModel.Email,
                PhoneNumber = contactModel.PhoneNumber,
                Status = contactModel.Status
            };
            using (var tx = _unitOfWork().BeginTransaction())
            {
                _unitOfWork().Add(contact);
                tx.Commit();
            }

            return contact;
        }

        public Contact Update(Contact contactModel)
        {
            var contact = Get(contactModel.Id);
            if (contact == null)
            {
                throw new ContactException("Not Exists");
            }

            contact.FirstName = contactModel.FirstName;
            contact.LastName = contactModel.LastName;
            contact.Email = contactModel.Email;
            contact.Status = contactModel.Status;
            contact.PhoneNumber = contactModel.PhoneNumber;
            using (var tx = _unitOfWork().BeginTransaction())
            {
                _unitOfWork().Update(contact);
                tx.Commit();
            }
          
            return contact;
        }

        public void Delete(long id)
        {
            var contact = Get(id);
            if (contact == null)
            {
                throw new ContactException("Not Exists");
            }
            using (var tx = _unitOfWork().BeginTransaction())
            {
                _unitOfWork().Remove(contact);
                tx.Commit();
            }
           
        }
    }
}
