using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;

namespace SalesManagementApp.Models
{
    public class Bill
    {
        private int iID;
        private ProductList lProducts;
        private int iEmployeeID;
        private int iCustomerID;
        private Date dPurchaseDate;
        private int iPrice;

        public int ID 
        { 
            get { return iID; }
            set { iID = value; }
        }

        public ProductList Products
        {
            get { return lProducts; }
            set { lProducts = value; }
        }

        public int EmployeeID
        {
            get { return iEmployeeID; }
            set { iEmployeeID = value; }
        }

        public int CustomerID
        {
            get { return iCustomerID; }
            set { iCustomerID = value; }
        }

        public Date PurchaseDate
        {
            get { return dPurchaseDate; }
            set { dPurchaseDate = value; }
        }

        public int Price
        {
            get { return iPrice; }
            set { iPrice = value; }
        }

        public Bill(int id,ProductList products, int employeeID, int customerID, Date purchaseDate)
        {
            this.iID = id;
            this.lProducts = products;
            this.iEmployeeID = employeeID;
            this.iCustomerID = customerID;
            this.dPurchaseDate = purchaseDate;
        }

        public Bill()
        {
            dPurchaseDate = new Date();
            lProducts = new ProductList(1000);
        }

        public void Input(ProductList tempproductlist)
        {
            Product temp = new Product();
            Product lh = new Product();
            Product lk = new Product();

            Console.WriteLine("Enter bill ID");
            this.iID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number of products: ");
            int sl = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < sl; i++)
            {
                Console.WriteLine("Enter product ID: ");
                lh.ID = Convert.ToInt32(Console.ReadLine());
               
                Console.WriteLine("Number of products with ID "+lh.ID);
                int sl1 = Convert.ToInt32(Console.ReadLine());

                //templist = tempproductlist.SearchItemByID(lh); // dua ra 1sp, còn list

                // temlisst là sản phẩm cần tìm

                //templist.Bill(sl1);
                temp.Print();

                //lh = temp; // bill sanPhamMua
                //lh.NumberOfProduct = sl1;//so luong mua

                //lk = temp;  //sản phâm trong kho

                
                if (temp != null)
                {
                    //if(lh.NumberOfProduct<=temp.NumberOfProduct)
                    //{ 
                        lProducts.AddLast(lh);
                        //tempproductlist.DeleteByProductNumber(lk);
                        
                        
                    //}
                    //else
                    //{
                    //    lProducts.AddLast(temp);
                    //    //int temp2 = tempproductlist.CheckStock(temp, sl1); //giam sl


                    //    //if (temp2 != 0)
                    //    //{
                    //    //    Console.WriteLine("thieu" + temp2 + "sanPham");
                    //    //    sl1 -= temp2;
                    //    //}
                    //}


                    this.Price += TotalPrice(temp,sl1);
                }
                else
                {
                    int j = i + 1;
                    Console.WriteLine("product" + j);
                    Console.WriteLine("Out of stock");
                }

            }
            Console.WriteLine("Customer ID : ");
            this.CustomerID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Employee ID : ");
            this.EmployeeID = Convert.ToInt32(Console.ReadLine());
            this.dPurchaseDate = Date.GetCurrentDate();
        }

        public void Print()
        {
            Console.WriteLine("Bill");
            Console.WriteLine("Employee ID: " + this.EmployeeID);
            Console.WriteLine("Customer ID: " + this.CustomerID);
            lProducts.Print();
            Console.WriteLine("Total cost: "+this.Price);
            dPurchaseDate.Print();
        }

        public int TotalPrice(Product temp, int sl)
        {
            int sum=0;
            for(int i=1; i<=sl;i++)
            {
                sum  += temp.Price;
            }    
            return sum;
        } 
    }
}
