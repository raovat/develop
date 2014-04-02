using SysPro.Core.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPro.Core.EF
{
    public interface ISingletonFix
    {
        void Dispose();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new();
        T GetImplement<T>();
    }

    public class SingletonFix : ISingletonFix
    {

        #region Properties
        private string _schema;
        public string schema { get { return this._schema; } }

        private Repository.UnitOfWork _unitOfWork;
        public Repository.UnitOfWork unitOfWork
        {
            get
            {
                if (this._unitOfWork == null)
                    this._unitOfWork = new Repository.UnitOfWork(this._schema);
                return this._unitOfWork;
            }
            set
            {
                this._unitOfWork = value;
            }
        }

        private Hashtable _implements;
        public Hashtable implements
        {
            get
            {
                if (this._implements == null)
                    this._implements = new Hashtable();
                return this._implements;
            }
            set { this._implements = value; }
        }
        #endregion

        #region Create Instance

        public SingletonFix(string schema)
        {
            this._schema = schema;
        }

        public static SingletonFix GetInstance(string schema)
        {
            return new SingletonFix(schema);
        }

        #endregion

        public void Dispose()
        {
            if (this._unitOfWork != null)
                this._unitOfWork.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new()
        {
            Repository.IRepository<TEntity> repository = this.unitOfWork.Repository<TEntity>();
            return repository;
        }

        public T GetImplement<T>()
        {
            string type = typeof(T).Name;

            if (this.implements.ContainsKey(type))
                return (T)this.implements[type];

            this.implements.Add(type, Activator.CreateInstance(typeof(T), this.unitOfWork));
            return (T)this.implements[type];
        }

        public static T GetInstance<T>(UnitOfWork unitOfWork)
        {
            return (T)Activator.CreateInstance(typeof(T), unitOfWork);
        }
    }
}
