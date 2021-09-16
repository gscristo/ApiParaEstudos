using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Enums
{
    public enum UserType : short
    {
        /// <summary>
        /// User type system
        /// </summary>
        System = 1,

        /// <summary>
        /// User type manager
        /// </summary>
        Manager = 2,

        /// <summary>
        /// User type operator
        /// </summary>
        Operator = 3,

        /// <summary>
        /// User type eployee
        /// </summary>
        Employee = 4
    }
}
