using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace Interface
{
    public interface ICategory
    {
        int Insert(Category cateInfo);//insert
        IList<Category> GetListCategory(int startindex, int maxrecords);
        IList<Category> GetListCategory(string where,int startindex, int maxrecords);
        Category GetDetail(int Id);
    }
}
