using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SW2_StoreProject
{
    public enum UserTypeEnum
    {
        [Description("normal")]
        Normal = 1,
        [Description("admin")]
        Admin = 2
    }

    public static class UserTypeEnumExtensions
    {
        public static string ToDescriptionString(this UserTypeEnum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    } 
}