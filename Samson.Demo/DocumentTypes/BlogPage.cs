using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samson.Services;

namespace Samson.Demo.DocumentTypes
{
    public class BlogPage : Page
    {
        public DateTime DisplayDate { get { return GetProperty<DateTime>("displayDate"); } }
    }
}