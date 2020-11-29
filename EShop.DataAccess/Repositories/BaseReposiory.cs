using EShop.Cache;
using EShop.Configuration;
using EShop.Data.Common;
using EShop.Data.Common.Enums;
using System;

namespace EShop.Data.Repositories
{
    public class BaseReposiory 
    {
        protected DbDataAccessHandle _dataAcessService = null;
        
        protected ICacheRepository _cacheRepository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReposiory"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public BaseReposiory(Connections connection = Connections.Default)
        {

            switch (connection)
            {
                case Connections.Event:
                    _dataAcessService = new DbDataServiceHandle(ApplicationConfiguration.ConnectionString, ApplicationConfiguration.Provider);
                    break;                
                default:
                    _dataAcessService = new DbDataServiceHandle(ApplicationConfiguration.ConnectionString, ApplicationConfiguration.Provider);
                    break;
                 

            }

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReposiory"/> class.
        /// </summary>
        /// <param name="dataAccesshandler">The data accesshandler.</param>
        /// <param name="connection">The connection.</param>
        public BaseReposiory(DbDataAccessHandle dataAccesshandler)
        {
            _dataAcessService = dataAccesshandler;
        }

        public virtual string ValidateString(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return value.Replace(@"'", @"''").Trim();
            else
                return string.Empty;
        }
    }
}
