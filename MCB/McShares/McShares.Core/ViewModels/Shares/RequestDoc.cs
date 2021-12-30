using System;
using System.Collections.Generic;
using System.Text;

namespace McShares.Core.ViewModels.Shares
{
    public class RequestDoc
    {
        public DateTime Doc_Date { get; set; }

        public string Doc_Ref { get; set; }

        public List<Doc_Data> Doc_Data { get; set; }

    }

    public class Doc_Data
    {
        public List<DataItem_Customer> DataItem_Customer { get; set; }
    }

    public class DataItem_Customer
    {
        public string customer_id { get; set; }
        public string Customer_Type { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public DateTime Date_Incorp { get; set; }
        public string REGISTRATION_NO { get; set; }
        public List<Mailing_Address> Mailing_Address { get; set; }
        public List<Contact_Details> Contact_Details { get; set; }
        public List<Shares_Details> Shares_Details { get; set; }
    }
    public class Mailing_Address
    {
        public string Address_Line1 { get; set; }
        public string Address_Line2 { get; set; }
        public string Town_City { get; set; }
        public string Country { get; set; }
    }

    public class Contact_Details
    {
        public string Contact_Name { get; set; }
        public string Contact_Number { get; set; }
    }
    public class Shares_Details
    {
        public string Num_Shares { get; set; }
        public string Share_Price { get; set; }
    }

}
