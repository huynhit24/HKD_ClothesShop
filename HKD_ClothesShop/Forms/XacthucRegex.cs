using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKD_ClothesShop.Forms
{
    class XacthucRegex
    {
        public static string Regex_HoTen = "^[A-Z]{1}[A-Za-z]{0,}$";
        public static string Regex_SDT = "^[6-9]{1}{0-9}{9}$";
        public static string Regex_Email = @"^(([^<>()[\]\\.,;:\s@]+(\.[^<>()[\]\\.,;:\s@]+)*)|(.+))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
        public static string Regex_Password = "^[a-zA-Z0-9]{15}$";
        //public static string Regex_Email = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    }
}
