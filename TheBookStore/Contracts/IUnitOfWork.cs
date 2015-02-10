using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBookStore.Contracts
{
    public interface IUnitOfWork
    {
        ////Acts as a container:
          //contains all repository as properites along with commit for datastore
        void Commit();

        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        IReviewRepository Reviews { get; }

    }
}
