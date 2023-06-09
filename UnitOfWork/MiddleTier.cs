using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitOfWork
{
    public class Customer
    {
        private int _CustomerCode = 0;

        public int CustomerCode
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
            obj.InsertCustomer(CustomerCode, CustomerName);
        }

    }
   
}
