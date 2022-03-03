using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsDemo.Models
{
    public class OrderDetail : XPObject
    {
        string fProductName;
        public string ProductName
        {
            get { return fProductName; }
            set { SetPropertyValue("ProductName", ref fProductName, value); }
        }

        private XPDelayedProperty fPicture = new XPDelayedProperty();
        [Delayed("fPicture", "GroupAttributes")]
        public byte[] Picture
        {
            get { return (byte[])fPicture.Value; }
            set { fPicture.Value = value; }
        }

        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    set
        //    {
        //        bool changed = SetPropertyValue("Name", ref name, value);
        //        if (!IsLoading && !IsSaving && changed)
        //        {
        //            //... YourBusinessRule...  
        //}
        //    }
        //}

        //[Persistent("Name")]
        //private string PersistentName
        //{
        //    get { return name; }
        //    set { SetPropertyValue("PersistentName", ref name, value); }
        //}
        //[PersistentAlias("PersistentName")]
        //public virtual string Name
        //{
        //    get { return PersistentName; }
        //    set
        //    {
        //        DoMyBusinessTricksBeforePropertyAssignement();
        //        PersistentName = value;
        //        DoMyBusinessTricksAfterPropertyAssignement();
        //    }
        //}
        public OrderDetail(Session session) : base(session)
        {
        }
        // ...  
    }
}
