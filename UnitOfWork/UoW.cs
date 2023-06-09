using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWork;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
namespace UnitOfWorkModule
{
   
    public interface IEntity
    {
        int Id { set; get; }
        void Insert();
        void Update();
        List<IEntity> Load();
    }
    public class SimpleExampleUOW<T>  where T : IEntity
    {
        private List<T> Changed = new List<T>();
        private List<T> New = new List<T>();

        public void Add(T obj)
        {
            New.Add(obj);
        }

        public void Committ()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (T o in Changed)
                {
                    o.Update();
                }
                foreach (T o in New)
                {
                    o.Insert();
                }
                scope.Complete();
            }
            
        }
       public  void Load(IEntity o)
        {
            
            Changed  = o.Load() as List<T>;
        }

       public void Add(IEntity obj)
       {
           throw new NotImplementedException();
       }
    }
    public class Customer : IEntity
    {
        private int _CustomerCode = 0;

        public int Id
        {
            get { return _CustomerCode; }
            set { _CustomerCode = value; }
        }
        private string _CustomerName = "";

        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        public void Insert()
        {
            DataAccess obj = new DataAccess();
            obj.InsertCustomer(_CustomerCode, CustomerName);
        }
        public  List<IEntity> Load()
        {
            DataAccess obj = new DataAccess();
            Customer o = new Customer();
            SqlDataReader ds = obj.GetCustomer(Id);
            while (ds.Read())
            {
                o.CustomerName = ds["CustomerName"].ToString();
            }
            List<IEntity> Li = (new List<Customer>()).ToList<IEntity>();
            Li.Add((IEntity) o);
            return Li;
        }


        public void Update()
        {
            DataAccess obj = new DataAccess();
            obj.UpdateCustomer(_CustomerCode, CustomerName);
        }
    }

    public class Supplier : IEntity
    {
        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public List<IEntity> Load()
        {
            throw new NotImplementedException();
        }
    }
}
