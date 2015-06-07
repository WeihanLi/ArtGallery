using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;

namespace WebApplication1.Admin
{
    /// <summary>
    /// 上传文件
    /// </summary>
    public class UploadFileHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //验证上传权限
            if (context.Session["User"] == null)
            {
                context.Response.Write("no permission");
                context.Response.End();
                return;
            }
            try
            {
                //获取上传文件
                //Filedata是客户端已经定义好的，如果想要更改，更改js文件中的配置
                HttpPostedFile image_upload = context.Request.Files["Filedata"];
                //获取文件扩展名
                string fileExt = System.IO.Path.GetExtension(image_upload.FileName).ToLower();
                //验证文件扩展名是否符合要求，是否是允许的图片格式
                if (fileExt!=".jpg"&& fileExt!=".png")
                {
                    return;
                }
                //当前时间字符串
                string timeString = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                //保存虚拟路径构建
                string path =  timeString + fileExt;
                //获取、构建要上传文件的物理路径
                string serverPath = context.Server.MapPath("~/Upload/" + path);
                string thumbPath = context.Server.MapPath("~/Upload/thumb/" + path);
                string smallThumbPath = context.Server.MapPath("~/Upload/small/" + path);
                //保存图片到服务器
                //原图太大，可以不保存
                //image_upload.SaveAs(serverPath);
                #region 生成缩略图

                // 获取上传图片的文件流
               System.Drawing.Image  original_image = System.Drawing.Image.FromStream(image_upload.InputStream);
                // 根据原图计算缩略图的宽度和高度，及缩放比例等~~
                int width = original_image.Width;
                int height = original_image.Height;
                int target_width = 400,target_height = 400,new_width=960, new_height=960,small_width=112,small_height=112;
                //float target_ratio = (float)target_width / (float)target_height;
                //图片的宽高比
                float image_ratio = (float)width / (float)height;
                
                //根据宽高比生成动态缩略图，如果宽高比大于1，即宽大于高则生成宽指定，宽高比小于1，即宽度小于高度，生成高度指定的图片
                if (image_ratio < 1)
                {
                    target_width = (int)Math.Floor(image_ratio * (float)target_height);
                    new_width = (int)Math.Floor(image_ratio * (float)new_height);
                    small_width = (int)Math.Floor(image_ratio * (float)small_height);
                }
                else
                {
                    target_height = (int)Math.Floor((float)target_width / image_ratio);
                    new_height = (int)Math.Floor((float)new_width / image_ratio);
                    small_height = (int)Math.Floor((float)small_width / image_ratio);
                }
                GenThumbnail(original_image, serverPath, new_width, new_height, fileExt);
                GenThumbnail(original_image,thumbPath,target_width,target_height,fileExt);
                GenThumbnail(original_image,smallThumbPath,small_width,small_height,fileExt);

                #endregion

                //输出保存路径
                context.Response.Write(path);
            }
            catch (Exception ex)
            {
                
                context.Response.Write("Error");
                //记录日志
                new Common.LogHelper(typeof(UploadFileHandler)).Error(ex);
            }
        }

        public static void GenThumbnail(Image imageFrom, string pathImageTo, int width, int height,string fileExt)
        {
            if (imageFrom == null)
            {
                return;
            }
            // 源图宽度及高度 
            int imageFromWidth = imageFrom.Width;
            int imageFromHeight = imageFrom.Height;
            // 生成的缩略图实际宽度及高度 
            int bitmapWidth = width;
            int bitmapHeight = height;
            // 生成的缩略图在上述"画布"上的位置 
            int X = 0;
            int Y = 0;
            // 根据源图及欲生成的缩略图尺寸,计算缩略图的实际尺寸及其在"画布"上的位置 
            if (bitmapHeight * imageFromWidth > bitmapWidth * imageFromHeight)
            {
                bitmapHeight = imageFromHeight * width / imageFromWidth;
                Y = (height - bitmapHeight) / 2;
            }
            else
            {
                bitmapWidth = imageFromWidth * height / imageFromHeight;
                X = (width - bitmapWidth) / 2;
            }
            // 创建画布 
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            // 用白色清空 
            g.Clear(Color.White);
            // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // 指定高质量、低速度呈现。 
            g.SmoothingMode = SmoothingMode.HighQuality;
            // 在指定位置并且按指定大小绘制指定的 Image 的指定部分。 
            g.DrawImage(imageFrom, new Rectangle(X, Y, bitmapWidth, bitmapHeight), new Rectangle(0, 0, imageFromWidth, imageFromHeight), GraphicsUnit.Pixel);
            try
            {
                //经测试 .jpg 格式缩略图大小与质量等最优 
                if (fileExt == ".png")
                {
                    bmp.Save(pathImageTo, ImageFormat.Png);
                }
                else
                {
                    bmp.Save(pathImageTo, ImageFormat.Jpeg);
                }
            }
            catch
            {
            }
            finally
            {
                //显示释放资源 
                bmp.Dispose();
                g.Dispose();
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}