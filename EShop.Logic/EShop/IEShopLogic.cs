using EShop.Entity.EShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Logic.EShop
{
    public interface IEShopLogic
    {
        LoginResponse Login(LoginRequest request);

    }
}
