using System.Data;
using System.Linq;

namespace detectVideoApp
{
    public class DataTableService
    {
        /// <summary>
        /// Checks if a specific data exists in datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="data"></param>
        /// <returns>true if data exists in dataTable</returns>
        public static bool CheckIfValueExist(DataTable dt,string data)
        {
            if (dt.Select().Any(e => e.ItemArray[1].ToString() == data))
            {
                return true;
            }
            return false;
        }

    }
}
