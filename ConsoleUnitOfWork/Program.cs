﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWorkModule;
//using UnitOfWorkModule;
namespace ConsoleUnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Customer obj = new Customer();
            //obj.Id = 1003;
            //obj.CustomerName = "Shaam";
            //obj.Insert();

            //Address objAdd = new Address();
            //objAdd.CustomerCode = 1003;
            //objAdd.AddressName = "India";
            //objAdd.Street = "Churchgate Mumbai central";
            //objAdd.Insert();
            
            /////////////////
            //CustomerU obj = new CustomerU();
            //obj.CustomerCode = 1003;
            //obj.CustomerName = "Shaam";


            //AddressU objAdd = new AddressU();
            //objAdd.AddressName = "India";
            //objAdd.Street = "Mumbai";
            //obj.Add(objAdd);

            //objAdd = new AddressU();
            //objAdd.AddressName = "Nepal";
            //objAdd.Street = "Kathmandu";
            //obj.Add(objAdd);
            //obj.Committ();

            ///////////////////
            //CustomerU obj = new CustomerU();
            //obj.Load(1002);
            //AddressU o = obj.getAddress(0);
            //o.Street = "xxx";
            //obj.Committ();

            Customer obj = new Customer();
            obj.Id = 1000;
            obj.CustomerName = "shiv";
            SimpleExampleUOW<Customer> o1 = new SimpleExampleUOW<Customer>();
            o1.Add(obj);
            obj = new Customer();
            obj.Id = 2000;
            obj.CustomerName = "xxxx";
            o1.Add(obj);
            o1.Committ();

            SimpleExampleUOW<Supplier> o2 = new SimpleExampleUOW<Supplier>();
            o2.Add(new Supplier());
            o2.Committ();

        }
    }
}
