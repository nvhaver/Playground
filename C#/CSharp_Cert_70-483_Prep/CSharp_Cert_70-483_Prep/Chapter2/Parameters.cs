using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Cert_70_483_Prep.Chapter2
{
    public class Parameters
    {
        public void OptionalParams(int firstArg, string secondArg = "default")
        {
            // The second parameter is optional and has a default value.
        }

        public void CallMethod()
        {
            // Switch the order of the parameters using named parameters.
            OptionalParams(secondArg: "string", firstArg: 2);
            // Omit the optional parameter. The default will be used.
            OptionalParams(1);
        }

    }
}
