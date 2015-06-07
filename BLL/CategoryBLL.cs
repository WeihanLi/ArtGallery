using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public class CategoryBLL : BaseBLL<Model.Category>
    {
        MSSQLDAL.CategeryDAL helper = new MSSQLDAL.CategeryDAL();
        public override bool Add(Category t)
        {
            return helper.Add(t);
        }

        public override bool Delete(int id)
        {
            return helper.Delete(id);
        }

        public override List<Category> Select()
        {
            return helper.Select();
        }

        public override List<Category> Select(string whereCondition)
        {
            return helper.SelectConditional(whereCondition);
        }

        public string SelectNameById(int cId)
        {
            return helper.Select(cId).CategoryName;
        }

        public override bool Update(Category t)
        {
            return helper.Update(t);
        }

        protected override void Init()
        {
            BLLHelper = new MSSQLDAL.CategeryDAL();
        }
    }
}
