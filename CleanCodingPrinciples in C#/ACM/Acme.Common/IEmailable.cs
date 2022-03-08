using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    interface IEmailable
    {
        bool CopyToSender { get; set; }
        string Send(string sendTo, string[] ccTo);
    }
}
