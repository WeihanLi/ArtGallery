using System.Collections.Generic;
using System.Data.SqlClient;

namespace MSSQLDAL
{
    public abstract class BaseDAL<T> where T :class,new ()
    {
        /// <summary>
        /// 要执行的sql语句
        /// </summary>
        protected static string commandText;

        /// <summary>
        /// sql语句的参数
        /// </summary>
        protected static SqlParameter[] commandParameters;

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="t">数据实体</param>
        /// <returns>是否新增成功</returns>
        public abstract bool Add(T t);
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="id">要删除数据对应的数据实体的主键值</param>
        /// <returns>是否删除成功</returns>
        public abstract bool Delete(int id);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t">更新后的数据实体</param>
        /// <returns>是否更新成功</returns>
        public abstract bool Update(T t);

        public abstract T Select(int id);

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageIndex">页码索引</param>
        /// <param name="pageSize">页容量</param>
        /// <returns>数据列表</returns>
        public virtual List<T> SelectPageList(int pageIndex, int pageSize)
        {
            return Common.ConverterHelper.DataTableToList<T>(MySqlHelper.ExecuteDataTable(commandText, commandParameters));
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns>数据列表</returns>
        public virtual List<T> Select()
        {
            return Common.ConverterHelper.DataTableToList<T>(MySqlHelper.ExecuteDataTable(commandText,commandParameters));
        }

        /// <summary>
        /// 查询满足条件的数据列表
        /// </summary>
        /// <param name="whereCondition">条件</param>
        /// <returns>数据列表</returns>
        public virtual List<T> SelectConditional(string whereCondition)
        {
            return Common.ConverterHelper.DataTableToList<T>(MySqlHelper.ExecuteDataTable(commandText,commandParameters));
        }
    }
}
