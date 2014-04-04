using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Category
    {
        public int ID { get; set; }
        public string CateName { get; set; }
        //Paging
        public int row { get; set; }
        public int row_count { get; set; }
    }
}
