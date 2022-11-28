﻿using SalesManagementApp.Activities;
using SalesManagementApp.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Models
{
    public class Sale : Person
    {
        private int iSalary;
        private LinkedLst<StringCustom> lOrdersSold;
  
        //properties
        public int Salary
        {
            get => iSalary;
            set => iSalary = value;
        }

        public LinkedLst<StringCustom> OrdersSold
        {
            get => lOrdersSold;
            set => lOrdersSold = value;
        }

        //constructor
        public Sale():base()
        {
            this.lOrdersSold = new LinkedLst<StringCustom>();
        }
        public Sale(string id, StringCustom name, StringCustom sex, Date birthday, 
            StringCustom address, StringCustom phoneno, int salary
            ) :base(id,name,sex,birthday,address, phoneno)
        {
            this.iSalary = salary;
            this.lOrdersSold = new LinkedLst<StringCustom>();
        }

        //destruction
        ~Sale() { }

        //method
        public override void Input()
        {
            base.Input();
            Console.WriteLine("Salary: "); this.iSalary = Convert.ToInt32(Console.ReadLine());
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Salary: " + this.iSalary);
        }

        public override bool IsEquals(Person person)
        {
            if(this.ID == person.ID)
                return true;
            return false;
        }
    }
}
