using EShop.Cache;
using EShop.Data.Entity;
using EShop.Data.Repositories;
using EShop.Entity.EShop;
using EShop.Logic.Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Logic.EShop
{
    public class EShopLogic : IEShopLogic
    {
        private IEShopRepository _eshopRepositoryRepository = null;
        private ICacheRepository _cacheRepository = null;
        
        public EShopLogic(IEShopRepository eshopRepository, ICacheRepository cacheRepository)
        {
            _eshopRepositoryRepository = eshopRepository;
            _cacheRepository = cacheRepository;           
        }
        

        public LoginResponse Login(LoginRequest request)
        {
            var result = _eshopRepositoryRepository.Login(request.Username, request.Password);

            return new LoginResponse() { IsSuccess = (result.Id==0)?false:true };
        }

    }
}
