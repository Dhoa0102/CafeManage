using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BasicCoffeeShop.DTO
{
    public class BillInfo
    {
        private int idBillInfo;
        private int idBill;
        private int iDdrink;
        private int drinkCount;
        private string baristaServe;

        public string BaristaServe
        {
            get { return baristaServe; }
            set { baristaServe = value; }
        }
        public int IDBillInfo
        {
            get { return idBillInfo; }      
            set { idBillInfo = value; }     
        }
        public int IDBill
        {
            get { return idBill; }      
            set { idBill = value; }     
        }
        public int IDdrink
        {
            get { return iDdrink; }
            set { iDdrink = value; }        
        }
        public int DrinkCount
        {
            get
            {
                return drinkCount;
            }
            set
            {
                drinkCount = value;     
            }
        }
        public BillInfo(int idBillInfo, int idBill,int iDdrink, int drinkCount,string baristaServe)
        {
            this.IDBillInfo = idBillInfo;
            this.IDBill=idBill;
            this.IDdrink = iDdrink;    
            this.DrinkCount=drinkCount;    
            this.BaristaServe = baristaServe;

        }
        public BillInfo(DataRow row)
        {

            this.IDBillInfo = (int)row["IDBillInfo"];
            this.IDBill = (int)row["IDBill"];
            this.IDdrink = (int)row["IDdrink"];
            this.DrinkCount = (int)row["DrinkCount"];
            this.BaristaServe = (string)row[""];
        }
/*        public override string ToString() 
        {
            
            return IDBillInfo.ToString()+" || "+idBill.ToString()+" || "+IDdrink.ToString;
        }*/
    }
}
