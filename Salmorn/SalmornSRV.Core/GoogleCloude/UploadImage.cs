using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace SalmornSRV.Core.GoogleCloude
{
    public class UploadImage : IUploadImage
    {
        private IGGStorage _storage;
        private IConfiguration _configuration;
        private string bucketName;
        private string bucketLarge;
        private string bucketMedium;
        private string bucketSmall;

        private int mediumSize;
        private int smallSize;

        public UploadImage(IConfiguration configuration, IGGStorage storage)
        {
            this._configuration = configuration;
            this._storage = storage;
            this.bucketName = configuration["GoogleCloudStorage:Bucket:Image:Root"];
            this.bucketLarge = configuration["GoogleCloudStorage:Bucket:Image:Large"];
            this.bucketMedium = configuration["GoogleCloudStorage:Bucket:Image:Medium"];
            this.bucketSmall = configuration["GoogleCloudStorage:Bucket:Image:Small"];

            this.mediumSize = int.Parse(configuration["GoogleCloudStorage:Size:Medium"]);
            this.smallSize = int.Parse(configuration["GoogleCloudStorage:Size:Small"]);
        }

        public bool Upload(IFormFile file, string fileName, ref string errorMessage)
        {
            //using (Bitmap temp = new Bitmap(file.OpenReadStream()))
            //{
            //    var image = new Bitmap(temp);

            //}
            try
            {
                this._storage.Upload(file.OpenReadStream(), this.bucketName, fileName);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
        private Image Resize(Image sourceImage, int sourceWidth, int sourceHeight, int destinationWidth, int destinationHeight)
        {
            Image destinationImage = new Bitmap(destinationWidth, destinationHeight);
            Graphics g = Graphics.FromImage(destinationImage);


            g.DrawImage(
              sourceImage,
              new Rectangle(0, 0, destinationWidth, destinationHeight),
              new Rectangle(0, 0, sourceWidth, sourceHeight),
              GraphicsUnit.Pixel
            );

            return destinationImage;
        }

        private void calImageResize(double mw, double mh, ref double w, ref double h)
        {
            if (w > mw)  reCalWH(mw, mh, true, ref w, ref h);
            if (h > mh) reCalWH(mw, mh, false, ref w, ref h);
        }
        private void reCalWH(double mw, double mh, bool isWidth, ref double w, ref double h)
        {
            double ww = 0,  hh = 0;

            if (isWidth)
            {
                ww = mw;
                hh = h * (mw / w);
            }
            else
            {
                hh = mh;
                ww = w * (mh / h);
            }

            w = ww;
            h = hh;
        }

        public bool Delete(string fileName)
        {
            try
            {
                this._storage.Delete(this.bucketName, fileName);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
