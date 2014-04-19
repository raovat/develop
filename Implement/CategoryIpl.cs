using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Interface;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using LibCore.Data;
using LibCore.EF;

namespace Implement
{
    public class CategoryIpl :BaseIpl<ADOProvider>, ICategory
    {
       // private static ADOProvider unitOfWork = SingletonIpl.GetInstance<ADOProvider>();
        //private static ICategory iCate = null;
        private readonly string _schema;
        //#region CreateInstance
        public CategoryIpl(string schema):base(schema)
        {
            _schema = schema;
        }
        //public static ICategory CreateInstance()
        //{
        //    if (iCate == null)
        //    {
        //        iCate = new CategoryIpl();
        //    }
        //    return iCate;
        //}
        //#endregion
        /// <summary>
        /// Inserts the specified item info.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <returns></returns>
        public int Insert(Category itemInfo)
        {
            try
            {
                var param = GetDynamicParams(itemInfo);
                unitOfWork.ProcedureExecute(unitOfWork.RunProcedureSchema("spCategory_Insert"), param);
                int Id = param.Get<int>("@cateId");
                return (Id != 0) ? Id : 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Inserts the specified items.
        /// </summary>
        /// <param name="items">The list items.</param>
        /// <returns></returns>
        public int Insert(IEnumerable<Category> items)
        {
            var ret = 0;
            foreach (var item in items)
            {
                ret = Insert(item);
            }
            return ret;
        }

        /// <summary>
        /// Gets the list category.
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetListCategory(int startindex, int maxrecords)
        {
            var data = unitOfWork
                .Procedure<Category>(unitOfWork.RunProcedureSchema("spCategory_GetList"), new {
                    Startindex = startindex,
                    Maxrecords = maxrecords
                }).ToList();
            return data;
        }

        public IList<Category> GetListCategory(string where, int startindex, int maxrecords) 
        {
            var data = unitOfWork
           .Procedure<Category>(unitOfWork.RunProcedureSchema("spCategory_GetListPageDynamic"), new
           {
               WhereCondition = where,
               Startindex = startindex,
               Maxrecords = maxrecords
           }).ToList();
            return data;
        }

        public IList<Category> GetListCategory(string where)
        {
            var data = unitOfWork
           .Procedure<Category>(unitOfWork.RunProcedureSchema("spCategory_GetListDynamic"), new
           {
               WhereCondition = where
           }).ToList();
            return data;
        }

        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="Id">The id.</param>
        /// <returns></returns>
        public Category GetDetail(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Id);
            var data = unitOfWork
             .Procedure<Category>(unitOfWork.RunProcedureSchema("spCategory_GetDataByID"), p).FirstOrDefault();
            return data;
        }
        #region Dynamic Parram
        private DynamicParameters GetDynamicParams(Category itemInfo, string action = "add")
        {
            var p = new DynamicParameters();
            p.Add("@cateId", itemInfo.ID);
            p.Add("@cateName", itemInfo.CateName);

            if (action == "edit")
            {
                p.Add("@cateId", itemInfo.ID);
            }
            else
            {
                p.Add("@cateId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            }
            return p;
        }
        #endregion
    }
}
