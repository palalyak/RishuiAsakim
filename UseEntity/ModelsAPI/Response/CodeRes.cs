using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.ModelsAPI.BaseClass;

namespace Infrastructure.ModelsAPI.Response
{
    public class CodeRes : Result
    {
        public int data { get; set; }
        public Result result { get; set; }
    }



}
