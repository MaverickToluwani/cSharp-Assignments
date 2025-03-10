using DataAccessLayer.Data;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ICommentRepository
    {
        Comment Create(Comment comment);

        void Delete(Comment comment);

        Comment? Get(int id);

        List<Comment> Get();

        Comment? Update(Comment comment);
    }
}
