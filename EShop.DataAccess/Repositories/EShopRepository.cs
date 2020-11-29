using EShop.Cache;
using EShop.Data.Common.Parameters;
using EShop.Data.Common.Utilties;
using EShop.Data.Entity;
using EShop.Data.Extention;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Data.Repositories
{
    public interface IEShopRepository
    {
        Users Login(string uname, string pword);
    }

    public class EShopRepository : BaseReposiory, IEShopRepository
    {
        private DbSqlAdapter _eShopDataAdapter = null;

        public EShopRepository(ICacheRepository cacheProvider)
        {
            _cacheRepository = cacheProvider;

            if (!_cacheRepository.IsSet("cache_eshopschema"))
            {
                _eShopDataAdapter = new DbSqlAdapter("EShop.Data.Queries.EShopSchema.xml");
                _cacheRepository.Set("cache_eshopschema", _eShopDataAdapter);
            }
            else
                _eShopDataAdapter = _cacheRepository.Get<DbSqlAdapter>("cache_eshopschema");
        }

        public EShopRepository(ICacheRepository cacheProvider, Common.Enums.Connections connection) : base(connection)
        {
            _cacheRepository = cacheProvider;

            if (!_cacheRepository.IsSet("cache_eshopschema"))
            {
                _eShopDataAdapter = new DbSqlAdapter("EShop.Data.Queries.EShopSchema.xml");
                _cacheRepository.Set("cache_eshopschema", _eShopDataAdapter);
            }
            else
                _eShopDataAdapter = _cacheRepository.Get<DbSqlAdapter>("cache_eshopschema");
        }


        public Users Login(string uname, string pword)
        {


            DbDataReader dataReader = null;
            DbInputParameterCollection paramCollection = new DbInputParameterCollection();

            try
            {
                paramCollection.Add("@uname", uname, DbType.String);
                paramCollection.Add("@pword", pword, DbType.String);
                dataReader = _dataAcessService.ExecuteQuery(_eShopDataAdapter["Login"], paramCollection);
                return dataReader.MapToSingle<Users>();
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                    dataReader.Close();
            }
        }

    }
}
