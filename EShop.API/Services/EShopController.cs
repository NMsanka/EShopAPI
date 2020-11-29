using EShop.Cache;
using EShop.Entity.EShop;
using EShop.Logic.EShop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
namespace EShop.API.Services
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/eshop")]
    [AllowAnonymous]

    public class EShopController : BaseController
    {
        IEShopLogic _eshopLogic = null;

        public EShopController(IEShopLogic eshopLogic, ICacheRepository CacheRepository) : base(CacheRepository)
        {
            _eshopLogic = eshopLogic;

        }        

        [Route("Login")]
        [HttpPost]
        public IHttpActionResult Login(LoginRequest request)
        {
            try
            {
                var result = _eshopLogic.Login(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}