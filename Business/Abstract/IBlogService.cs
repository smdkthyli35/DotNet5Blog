using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        Blog GetById(int id);
        void Add(Blog blog);
        void Delete(Blog blog);
        void Update(Blog blog);
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogById(int id);
        List<Blog> GetBlogListByWriter(int id);
        List<Blog> GetLast3Blog();
        List<Blog> GetListWithCategoryByWriter(int id);
    }
}
