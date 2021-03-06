﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModles
{
    public class FutureDate:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isvalid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy", 
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,out dateTime);
            return (isvalid && dateTime > DateTime.Now);
        }

        //public override bool IsValid(object value)
        //{
        //    DateTime dateTime;
        //    var isValid = DateTime.TryParseExact(Convert.ToString(value),
        //        "d MMM yyyy",
        //        CultureInfo.CurrentCulture,
        //        DateTimeStyles.None, out dateTime);

        //    return (isValid && dateTime > DateTime.Now);

        //}
    }
}