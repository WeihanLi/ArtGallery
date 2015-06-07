using Model;
using MSSQLDAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ItemBLL : BaseBLL<Model.Item>
    {
        static Common.LogHelper logger = new Common.LogHelper(typeof(ItemBLL));
        ItemDAL helper = new ItemDAL();
        //static Thread threadUpdate = null;

        public override bool Add(Item t)
        {
            bool bValue = helper.Add(t);
            CreateItemFile(t);
            //threadUpdate = new Thread(new ThreadStart(UpdateIndexPage));           
            //threadUpdate.IsBackground = true;
            //threadUpdate.Start();
            return bValue;
        }

        /// <summary>
        /// Create or Update  file
        /// </summary>
        /// <param name="t"> entity</param>
        private void CreateItemFile(Item t)
        {
            try
            {
                //构建路径
                string path = t.ItemPath;
                if (String.IsNullOrEmpty(path))
                {
                    path = Select(t.ItemId).ItemPath;
                }
                string serverPath = Common.PathHelper.MapPath("~/") + path;
                //获取目录名
                string dir = System.IO.Path.GetDirectoryName(serverPath);
                string templateServerPath = Common.PathHelper.MapPath("~/App_Data/template.html");
                //读取模板信息
                string template = System.IO.File.ReadAllText(templateServerPath);
                //设置静态文件的内容
                //string content = String.Format(template, t.ItemName,t.ItemId>0?t.ItemId:helper.GetMaxId(), t.ItemAuthor, t.ItemDesc,"/Upload/"+t.ItemImagePath);
                string content = template.Replace("{0}", t.ItemName).Replace("{1}", Convert.ToString(t.ItemId > 0 ? t.ItemId : helper.GetMaxId())).Replace("{2}", t.ItemAuthor).Replace("{3}", t.ItemDesc).Replace("{4}", "/Upload/" + t.ItemImagePath);
                //判断目录是否存在
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                //创建静态文件
                using (System.IO.TextWriter writer = System.IO.File.CreateText(serverPath))
                {
                    writer.Write(content);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public bool AddFav(int id)
        {
            return helper.AddFav(id);
        }

        /// <summary>
        /// Delete item file
        /// </summary>
        /// <param name="item">item Entity</param>
        private void DeleteItemFile(Item item)
        {
            try
            {
                string path = Common.PathHelper.MapPath(item.ItemPath);
                System.IO.File.Delete(path);
                if (item.ItemImagePath!=null)
                {
                    System.IO.File.Delete(Common.PathHelper.MapPath(item.ItemImagePath));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public List<Item> SelectPageList(int pageIndex, bool isAsc, int pageSize = 10)
        {
            return helper.SelectPageList(pageIndex-1, isAsc, pageSize);
        }

        /// <summary>
        /// 更新index页面,list Page
        /// </summary>
        //Todo:自动获取网站的域名或IP及端口
        //System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName();
        //private static void UpdateIndexPage()
        //{
        //    try
        //    {
        //        //更新首页 index.html
        //        WebClient client = new WebClient();
        //        client.Encoding = System.Text.Encoding.UTF8;
        //        //Todo:替换
        //        string url= @"http://218.196.240.79:8081/default.aspx";
        //        string html = client.DownloadString(url);
        //        using (System.IO.TextWriter writer = System.IO.File.CreateText(Common.PathHelper.MapPath("~/index.html")))
        //        {
        //            writer.Write(html);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        new Common.LogHelper(typeof(ItemBLL)).Error(ex);
        //    }
        //    finally
        //    {
        //        threadUpdate.Abort();
        //    }
        //}

        public override bool Delete(int id)
        {
            bool bValue = base.Delete(id);
            //threadUpdate = new Thread(new ThreadStart(UpdateIndexPage));
            //threadUpdate.IsBackground = true;
            //threadUpdate.Start();
            return bValue;
        }

        public bool Delete(Item item)
        {
            bool bValue = helper.Delete(item.ItemId);
            DeleteItemFile(item);
            //threadUpdate = new Thread(new ThreadStart(UpdateIndexPage));
            //threadUpdate.IsBackground = true;
            //threadUpdate.Start();
            return bValue;
        }

        public Item Select(int id)
        {
            return helper.Select(id);
        }

        public Item SelectPrevious(int id)
        {
            return helper.SelectPrevious(id);
        }

        public Item SelectNext(int id)
        {
            return helper.SelectNext(id);
        }

        public override List<Item> Select()
        {
            return helper.Select();
        }

        public List<Item> Select(bool isAsc)
        {
            return helper.Select(isAsc);
        }

        public List<Item> SelectOdd(int id, int count)
        {
            return helper.SelectOdd(id, count);
        }

        public List<Item> SelectByCategory(int categoryId)
        {
            return helper.SelectNewsByCategory(categoryId);
        }

        public List<Item> SelectByCategory(int categoryId,bool isAsc)
        {
            return helper.SelectNewsByCategory(categoryId,isAsc);
        }

        public List<Item> SelectPageListByCategory(int cId, int pageIndex, int pageSize, bool isAsc)
        {
            return helper.SelectPageListByCategory(cId, pageIndex-1, pageSize, isAsc);
        }

        //public List<Item> SelecteImageItem(int count)
        //{
        //    return helper.SelectConditional("itemImagePath IS NOT NULL ",count);
        //}

        public List<Item> SelecteImageItem()
        {
            return helper.SelectConditional("itemImagePath IS NOT NULL ");
        }

        public override List<Item> Select(string whereCondition)
        {
            return helper.SelectConditional(whereCondition);
        }

        public override List<Item> Select(int pageIndex, int pageSize = 10)
        {
            return helper.SelectPageList(pageIndex-1, pageSize);
        }

        public override bool Update(Item t)
        {
            bool bValue = helper.Update(t);
            CreateItemFile(t);
            //threadUpdate = new Thread(new ThreadStart(UpdateIndexPage));
            //threadUpdate.IsBackground = true;
            //threadUpdate.Start();
            return bValue;
        }

        protected override void Init()
        {
            BLLHelper = new ItemDAL();
        }
    }
}
