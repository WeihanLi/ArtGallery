using Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MSSQLDAL
{
    public class ItemDAL : BaseDAL<Item>
    {
        public override bool Add(Item t)
        {
            commandText = "insert into tabItem(itemName,itemDesc,publishTime,itemPath,itemImagePath,itemAuthor,itemTypeId) values(@iName,@iDesc,@pubTime,@nPath,@imgPath,@iAuthor,@typeId)";
            commandParameters = new SqlParameter[] { new SqlParameter("@iName", t.ItemName),new SqlParameter("@iDesc",t.ItemDesc),new SqlParameter("@pubTime",t.PublishTime),new SqlParameter("@nPath",t.ItemPath),new SqlParameter("@imgPath",t.ItemImagePath),new SqlParameter("@iAuthor",t.ItemAuthor) ,new SqlParameter("typeId",t.ItemTypeId)};
            return MySqlHelper.ExecuteNonQuery(commandText, commandParameters) == 1;
        }

        public override bool Delete(int id)
        {
            commandText = "delete from tabItem where itemId=@id";
            commandParameters = new SqlParameter[] { new SqlParameter("@id", id) };
            return MySqlHelper.ExecuteNonQuery(commandText, commandParameters) == 1;
        }

        public override bool Update(Item t)
        {
            commandText = "update tabItem set itemName = @iName,itemDesc=@iDesc,itemAuthor=@iAuthor,itemImagePath=@imgPath,itemTypeId=@typeId where itemId=@id";
            commandParameters = new SqlParameter[] { new SqlParameter("@iName", t.ItemName), new SqlParameter("@iDesc", t.ItemDesc), new SqlParameter("@id", t.ItemId),new SqlParameter("@iAuthor",t.ItemAuthor), new SqlParameter("@imgPath", t.ItemImagePath),new SqlParameter("@typeId",t.ItemTypeId) };
            return MySqlHelper.ExecuteNonQuery(commandText, commandParameters) == 1;
        }

        public bool AddFav(int id)
        {
            commandText = "update tabItem set itemFavCount=itemFavCount+1 where itemId=@id";
            commandParameters = new SqlParameter[] { new SqlParameter("@id", id)};
            return MySqlHelper.ExecuteNonQuery(commandText, commandParameters) == 1;
        }

        public List<Item> SelectOdd(int id,int count)
        {
            commandText = "select TOP(@cnt)  * from tabItem where itemId BETWEEN (@id-@cnt) AND (@id-1) UNION ALL select TOP(@cnt+1) * from tabItem where itemId >= @id order by itemId";
            commandParameters = new SqlParameter[] { new SqlParameter("@id", id), new SqlParameter("@cnt", count/2) };
            return base.Select();
        }

        public Item SelectPrevious(int id)
        {
            commandText = "select TOP 1 * from tabItem where itemId<@id order by itemId DESC";
            commandParameters = new SqlParameter[] { new SqlParameter("@id", id) };
            List<Model.Item> items = base.SelectConditional(commandText);
            return items == null ? null : items[0];
        }

        public Item SelectNext(int id)
        {
            commandText = "select TOP 1 * from tabItem where itemId>@id order by itemId";
            commandParameters = new SqlParameter[] { new SqlParameter("@id", id) };
            List<Model.Item> items = base.SelectConditional(commandText);
            return items == null ? null : items[0];
        }

        public override List<Item> Select()
        {
            commandText = "select * from tabItem order by itemId";
            commandParameters = null;
            return base.Select();
        }

        public List<Item> Select(bool isAsc)
        {
            commandText = "select * from tabItem order by itemId";
            if (!isAsc)
            {
                commandText += " DESC";
            }
            commandParameters = null;
            return base.Select();
        }

        public override List<Item> SelectConditional(string whereCondition)
        {
            commandText = "select * from tabItem where " + whereCondition+ " order by itemId";
            commandParameters = null;
            return base.SelectConditional(whereCondition);
        }

        public override List<Item> SelectPageList(int pageIndex, int pageSize)
        {
            commandText = "select top(@pSize) * from tabItem where itemId not in (select top(@pIndex*@pSize) itemId from tabItem) order by itemId";
            commandParameters = new SqlParameter[] { new SqlParameter("@pSize", pageSize), new SqlParameter("pIndex", pageIndex) };
            return base.SelectPageList(pageIndex, pageSize);
        }

        public List<Item> SelectPageList(int pageIndex,bool isAsc, int pageSize)
        {
            commandText = "select top(@pSize) * from tabItem where itemId not in (select top(@pIndex*@pSize) itemId from tabItem) order by itemId";
            if (isAsc==false)
            {
                commandText += " DESC";
            }
            commandParameters = new SqlParameter[] { new SqlParameter("@pSize", pageSize), new SqlParameter("pIndex", pageIndex) };
            return Common.ConverterHelper.DataTableToList<Item>(MySqlHelper.ExecuteDataTable(commandText, commandParameters));
        }

        public List<Item> SelectConditional(string whereCondition,int count)
        {
            commandText = "select TOP(@cnt) * from tabItem where " + whereCondition + " order by publishTime DESC";
            commandParameters = new SqlParameter[] { new SqlParameter("@cnt", count) };
            return base.SelectConditional(whereCondition);
        }

        public List<Item> SelectNewsByCategory(int cId)
        {
            commandText = "select * from tabItem where itemTypeId=@id order by id";
            commandParameters = new SqlParameter[] { new SqlParameter("@id", cId) };
            return base.SelectConditional(commandText);
        }

        public List<Item> SelectNewsByCategory(int cId,bool isAsc)
        {
            commandText = "select * from tabItem where itemTypeId=@id order by itemId";
            if (!isAsc)
            {
                commandText += " DESC";
            }
            commandParameters = new SqlParameter[] { new SqlParameter("@id", cId) };
            return base.SelectConditional(commandText);
        }

        public List<Item> SelectPageListByCategory(int cId, int pageIndex,int pageSize, bool isAsc)
        {
            commandText = "select top(@pSize) * from tabItem where itemId not in (select top(@pIndex*@pSize) itemId from tabItem) AND itemTypeId=@tId order by itemId";
            if (isAsc == false)
            {
                commandText += " DESC";
            }
            commandParameters = new SqlParameter[] { new SqlParameter("@pSize", pageSize), new SqlParameter("pIndex", pageIndex),new SqlParameter("@tId",cId) };
            return Common.ConverterHelper.DataTableToList<Item>(MySqlHelper.ExecuteDataTable(commandText, commandParameters));
        }

        public override Item Select(int id)
        {
            commandText = "select * from tabItem where itemId=@id";
            commandParameters = new SqlParameter[] { new SqlParameter("@id", id) };
            List<Model.Item> items = base.SelectConditional(commandText);
            return items==null?null:items[0];
        }

        public int GetMaxId()
        {
            commandText = "select MAX(itemId) from tabItem";
            commandParameters = null;
            return int.Parse(MySqlHelper.ExecuteScalar(commandText).ToString());
        }
    }
}