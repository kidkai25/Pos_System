using Pos_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pos_System.ViewModel
{
    public class BaseViewModel
    {
        //Adding My two Sub models (these correspond to left and right views respectively)
        public SubViewModel1 SubViewModel1 { get; set; }
        public SubViewModel2 SubViewModel2 { get; set; }
    }
}