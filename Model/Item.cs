using System;

namespace Model
{
    public class Item
    {
        private int itemId;
        private string itemName;
        private string itemAuthor;
        private int itemTypeId;
        private string itemImagePath;
        private string itemDesc;
        private string itemPath;
        private DateTime publishTime;

        /// <summary>
        /// 图片路径
        /// </summary>
        public string ItemImagePath
        {
            get
            {
                return itemImagePath;
            }

            set
            {
                itemImagePath = value;
            }
        }
        
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime
        {
            get
            {
                return publishTime;
            }

            set
            {
                publishTime = value;
            }
        }

        /// <summary>
        /// 作品保存路径
        /// </summary>
        public string ItemPath
        {
            get
            {
                return itemPath;
            }

            set
            {
                itemPath = value;
            }
        }

        /// <summary>
        /// 作品名称
        /// </summary>
        public string ItemName
        {
            get
            {
                return itemName;
            }

            set
            {
                itemName = value;
            }
        }

        /// <summary>
        /// 作品编号
        /// </summary>
        public int ItemId
        {
            get
            {
                return itemId;
            }

            set
            {
                itemId = value;
            }
        }

        /// <summary>
        /// 作品简介
        /// </summary>
        public string ItemDesc
        {
            get
            {
                return itemDesc;
            }

            set
            {
                itemDesc = value;
            }
        }

        /// <summary>
        /// 作品作者
        /// </summary>
        public string ItemAuthor
        {
            get
            {
                return itemAuthor;
            }

            set
            {
                itemAuthor = value;
            }
        }

        public int ItemTypeId
        {
            get
            {
                return itemTypeId;
            }

            set
            {
                itemTypeId = value;
            }
        }
    }
}
