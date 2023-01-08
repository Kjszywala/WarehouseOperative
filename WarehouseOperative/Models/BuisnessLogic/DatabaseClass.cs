using WarehouseOperative.Models.DatabaseEntities;

namespace WarehouseOperative.Models.BuisnessLogic
{
    public class DatabaseClass
    {
        #region Properties

        protected KjsCompany2Entities2 Db { get; set; }

        #endregion

        #region Constructor

        public DatabaseClass(KjsCompany2Entities2 db)
        {
            Db = db;
        }

        #endregion
    }
}
