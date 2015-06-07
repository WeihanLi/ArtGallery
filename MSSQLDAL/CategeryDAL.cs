using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace MSSQLDAL
{
    public class CategeryDAL : BaseDAL<Category>
    {
        /// <summary>
        /// 新增新闻类别
        /// </summary>
        /// <param name="t">类别实体</param>
        /// <returns>是否新增成功</returns>
        public override bool Add(Category t)
        {
            commandText = "insert into tabCategory(categoryName) values(@cName)";
            commandParameters = new SqlParameter[]{ new SqlParameter("@cName", t.CategoryName)};
            return MySqlHelper.ExecuteNonQuery(commandText, commandParameters) == 1;
        }

        /// <summary>
        /// 根据id删除相应类别
        /// </summary>
        /// <param name="id">要删的类别对应id</param>
        /// <returns>是否删除成功</returns>
        public override bool Delete(int id)
        {
            commandText = "delete from tabCategory where categoryId=@id";
            commandParameters = new SqlParameter[] { new SqlParameter("@id", id) };
            return MySqlHelper.ExecuteNonQuery(commandText, commandParameters) == 1;
        }
        
        /// <summary>
        /// 更新分类名称
        /// </summary>
        /// <param name="t">分类模型实体</param>
        /// <returns>是否更新成功</returns>
        public override bool Update(Category t)
        {
            commandText = "update tabCategory set categoryName = @cName where categoryId=@id";
            commandParameters = new SqlParameter[] { new SqlParameter("@cName", t.CategoryName),new SqlParameter("@id",t.CategoryId) };
            return MySqlHelper.ExecuteNonQuery(commandText,commandParameters)==1;
        }

        public override List<Category> Select()
        {
            commandText = "select * from tabCategory";
            return base.Select();
        }

        public override List<Category> SelectConditional(string whereCondition)
        {
            commandText = "select * from tabCategory where "+whereCondition;
            return base.SelectConditional(whereCondition);
        }

        public override List<Category> SelectPageList(int pageIndex, int pageSize)
        {
            commandText = "select top(@pSize) from tabCategory where id not in (select top @pIndex*@pSize itemId from tabCategory) order by id";
            commandParameters = new SqlParameter[] { new SqlParameter("@pSize", pageSize), new SqlParameter("pIndex", pageIndex) };
            return base.SelectPageList(pageIndex, pageSize);
        }

        public override Category Select(int id)
        {
            commandText = "select * from tabCategory where categoryId=@id";
            commandParameters = new SqlParameter[] { new SqlParameter("@id", id) };
            return base.SelectConditional(commandText).ToArray()[0];
        }
    }
}
