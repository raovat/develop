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
        public int CityId { get; set; }
        public int Parent { get; set; }
        public int SubParent { get; set; }
        public int Order { get; set; }
        public int CodeId { get; set; }
        //Paging
        public int row { get; set; }
        public int row_count { get; set; }
    }
}
