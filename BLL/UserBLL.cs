using Model;
using MSSQLDAL;
using System.Collections.Generic;
using System;

namespace BLL
{
    public class UserBLL : BaseBLL<User>
    {
        private UserDAL helper = new UserDAL();

        protected override void Init()
        {
            helper = new UserDAL();
            BLLHelper = helper;
        }

        public bool Login(User u)
        {
            return helper.Login(u);
        }

        public bool ExistUserName(string name)
        {
            return helper.ExistUserName(name);
        }

        public override bool Add(User t)
        {
            t.AddTime = DateTime.Now;
            return helper.Add(t);
        }

        public override bool Delete(int id)
        {
            return helper.Delete(id);
        }

        public override List<User> Select()
        {
            return helper.Select();
        }

        public bool IsAdmin(string uName)
        {
                return helper.IsAdmin(uName);
        }

        public override List<User> Select(string whereCondition)
        {
            return helper.SelectConditional(whereCondition);
        }

        //public override List<User> Select(int pageIndex, int pageSize,ref int rowsCount)
        //{
        //    return helper.Select(pageIndex, pageSize,ref rowsCount);
        //}

        public override bool Update(User t)
        {
            return helper.Update(t);
        }
    }
}
