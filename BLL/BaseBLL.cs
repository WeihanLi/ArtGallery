using MSSQLDAL;
using System.Collections.Generic;

namespace BLL
{
    public abstract class BaseBLL<T> where T :class,new ()
    {
        protected BaseDAL<T> BLLHelper = null;

        public BaseBLL()
        {
            Init();
        }

        protected abstract void Init();

        public virtual bool Add(T t)
        {
            return BLLHelper.Add(t);
        }

        public virtual bool Update(T t)
        {
            return BLLHelper.Update(t);
        }

        public virtual bool Delete(int id)
        {
            return BLLHelper.Delete(id);
        }

        public virtual List<T> Select(int pageIndex, int pageSize)
        {
            return BLLHelper.SelectPageList(pageIndex, pageSize);
        }

        public virtual List<T> Select()
        {
            return BLLHelper.Select();
        }

        public virtual List<T> Select(string whereCondition)
        {
            return BLLHelper.SelectConditional(whereCondition);
        }
    }
}
