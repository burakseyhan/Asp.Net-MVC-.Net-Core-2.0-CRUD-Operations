using PersonManagerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonManagerApp.Repository
{
    public interface IPersonRepository
    {
        IQueryable<PersonEntity> GetAll();

        PersonEntity GetSingle(int barId);

        IQueryable<PersonEntity> FindBy(Expression<Func<PersonEntity, bool>> predicate);

        void Add(PersonEntity entity);

        void Delete(PersonEntity entity);

        void Edit(PersonEntity entity);

        void Save();
    }
}
