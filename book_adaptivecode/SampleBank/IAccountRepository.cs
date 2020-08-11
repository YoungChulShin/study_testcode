using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBank
{
    public interface IAccountRepository
    {
        Account getByName(string name);
    }
}
