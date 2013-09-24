using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morrison.Models
{
   public class addressinfo
    {
       //送货地址ID
       public int addressid
       {
           get;
           set;
       }
       //配送区域I id
       public int deliveryIid
       {
           get;
           set;
       }
       //配送区域II id
       public int deliveryIIid
       {
           get;
           set;
       }
       //配送区域I
       public string deliveryI
       {
           get;
           set;
       }
       //配送区域II 
       public string deliveryII
       {
           get;
           set;
       }
       //送货详细地址
       public string address
       {
           get;
           set;
       }
       //联系电话
       public string tel
       {
           get;
           set;
       }
       //联系手机
       public string mobile
       {
           get;
           set;
       }
       //联系人
       public string contact
       {
           get;
           set;
       }
       //用户ID
       public string userid
       {
           get;
           set;
       }
       //是否默认送货地址 0为不是 1为默认送货地址
       public int isdefault
       {
           get;
           set;
       }

    }
}
