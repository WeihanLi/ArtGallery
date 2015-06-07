using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MSSQLDAL
{
    public class UserDAL : BaseDAL<User>
    {

        public bool Login(User u)
        {
            commandText = "select userPassword from tabUser where userName=@uName";
            SqlParameter para = new SqlParameter("@uName", u.UserName) ;
            object result = MySqlHelper.ExecuteScalar(commandText, para);
            if (result!=null)
            {
                if (u.UserPassword.Equals(result.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public override bool Add(User t)
        {
            commandText = "insert into tabUser(userName,userPassword,isAdmin,addTime) values(@uid,@pwd,@isAdmin,@addTime)";
            commandParameters = new SqlParameter[] { new SqlParameter("@uid", t.UserName), new SqlParameter("@pwd", t.UserPassword), new SqlParameter("@isAdmin", false),new SqlParameter("@addTime",t.AddTime) };
            return MySqlHelper.ExecuteNonQuery(commandText, commandParameters) == 1;
        }

        public bool ExistUserName(string name)
        {
            commandText = "select Count(*) from tabUser where userName=@uName";
            SqlParameter para = new SqlParameter("@uName", name);
            return (int)MySqlHelper.ExecuteScalar(commandText, para)>0;
        }

        public override bool Delete(int id)
        {
            commandText = "delete from tabUser where userId=@id";
            commandParameters = new SqlParameter[] { new SqlParameter("@id", id) };
            return MySqlHelper.ExecuteNonQuery(commandText, commandParameters) == 1;
        }

        public override bool Update(User t)
        {
            commandText = "update tabUser set userPassword = @pwd where userName=@uid";
            commandParameters = new SqlParameter[] { new SqlParameter("@pwd",t.UserPassword),new SqlParameter("@uid",t.UserName)};
            return MySqlHelper.ExecuteNonQuery(commandText, commandParameters) == 1 ;
        }

        public override List<User> Select()
        {
            commandText = "select userId,userName,addTime from tabUser where isAdmin=0";
            return base.Select();
        }

        public bool IsAdmin(string uName)
        {
            commandText = "select isAdmin from tabUser where userName=@uid";
            commandParameters = new SqlParameter[] {  new SqlParameter("@uid", uName) };
            return Convert.ToBoolean(MySqlHelper.ExecuteScalar(commandText,commandParameters));
        }

        public override List<User> SelectPageList(int pageIndex, int pageSize)
        {
            //拼接字符串
            //StringBuilder sbText = new StringBuilder();
            //sbText.Append("select * from tabUser take ");
            //sbText.Append(pageSize);
            //sbText.Append(" skip ");
            //sbText.Append((pageIndex - 1) * pageSize);
            //sbText.Append(" order by userId");

            //commandText = sbText.ToString();
            commandText = "select top(@size) from tabUser where id not in (select top @pIndex*@size userId from tabUser) order by id";
            commandParameters = new SqlParameter[] { new SqlParameter("@size", pageSize), new SqlParameter("pIndex", pageIndex) };
            return base.Select();
        }

        public override User Select(int id)
        {
            commandText = "select userId,userName,userPassword,addTime from tabUser where userId=@id";
            commandParameters = new SqlParameter[] { new SqlParameter("@id", id) };
            return base.SelectConditional(commandText).ToArray()[0];
        }
    }
}
