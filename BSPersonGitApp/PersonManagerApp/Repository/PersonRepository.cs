using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonManagerApp.Model;

namespace PersonManagerApp.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext dbContext = new PersonContext();

        public void Add(PersonEntity entity)
        {
            dbContext.Person.Add(entity);
        }

        public void Delete(PersonEntity entity)
        {
            dbContext.Person.Remove(entity);
        }

        public void Edit(PersonEntity entity)
        {
            dbContext.Entry<PersonEntity>(entity).State = EntityState.Modified;
        }

        public IQueryable<PersonEntity> FindBy(Expression<Func<PersonEntity, bool>> predicate)
        {
            IQueryable<PersonEntity> query = dbContext.Set<PersonEntity>().Where(predicate);

            return query;
        }

        public IQueryable<PersonEntity> GetAll()
        {
            IQueryable<PersonEntity> getItems = dbContext.Person;

            return getItems;
        }

        public PersonEntity GetSingle(int id)
        {
            PersonEntity result = this.GetAll().FirstOrDefault(x => x.Id == id);

            return result;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
