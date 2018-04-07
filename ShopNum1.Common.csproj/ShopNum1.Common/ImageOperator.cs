namespace ShopNum1.Common
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.IO;

    public class ImageOperator
    {
        public static void AddImageSignPic(string imgPath, string watermarkFilename, int watermarkStatus, int quality, int watermarkTransparency)
        {
            Image image = Image.FromStream(new MemoryStream(File.ReadAllBytes(imgPath)));
            if (File.Exists(watermarkFilename))
            {
                Graphics graphics = Graphics.FromImage(image);
                Image image2 = new Bitmap(watermarkFilename);
                if ((image2.Height < image.Height) && (image2.Width < image.Width))
                {
                    ImageAttributes imageAttr = new ImageAttributes();
                    ColorMap map = new ColorMap();
                    map.OldColor = Color.FromArgb(0xff, 0, 0xff, 0);
                    map.NewColor = Color.FromArgb(0, 0, 0, 0);
                    ColorMap[] mapArray2 = new ColorMap[] { map };
                    imageAttr.SetRemapTable(mapArray2, ColorAdjustType.Bitmap);
                    float num = 0.5f;
                    if ((watermarkTransparency >= 1) && (watermarkTransparency <= 10))
                    {
                        num = ((float)watermarkTransparency) / 10f;
                    }
                    float[][] numArray2 = new float[5][];
                    float[] numArray3 = new float[5];
                    numArray3[0] = 1f;
                    numArray2[0] = numArray3;
                    numArray3 = new float[5];
                    numArray3[1] = 1f;
                    numArray2[1] = numArray3;
                    numArray3 = new float[5];
                    numArray3[2] = 1f;
                    numArray2[2] = numArray3;
                    numArray3 = new float[5];
                    numArray3[3] = num;
                    numArray2[3] = numArray3;
                    numArray3 = new float[5];
                    numArray3[4] = 1f;
                    numArray2[4] = numArray3;
                    float[][] newColorMatrix = numArray2;
                    ColorMatrix matrix = new ColorMatrix(newColorMatrix);
                    imageAttr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    int x = 0;
                    int y = 0;
                    switch (watermarkStatus)
                    {
                        case 1:
                            x = (int)(image.Width * 0.01f);
                            y = (int)(image.Height * 0.01f);
                            break;

                        case 2:
                            x = ((int)(image.Width * 0.5f)) - (image2.Width / 2);
                            y = (int)(image.Height * 0.01f);
                            break;

                        case 3:
                            x = ((int)(image.Width * 0.99f)) - image2.Width;
                            y = (int)(image.Height * 0.01f);
                            break;

                        case 4:
                            x = (int)(image.Width * 0.01f);
                            y = ((int)(image.Height * 0.5f)) - (image2.Height / 2);
                            break;

                        case 5:
                            x = ((int)(image.Width * 0.5f)) - (image2.Width / 2);
                            y = ((int)(image.Height * 0.5f)) - (image2.Height / 2);
                            break;

                        case 6:
                            x = ((int)(image.Width * 0.99f)) - image2.Width;
                            y = ((int)(image.Height * 0.5f)) - (image2.Height / 2);
                            break;

                        case 7:
                            x = (int)(image.Width * 0.01f);
                            y = ((int)(image.Height * 0.99f)) - image2.Height;
                            break;

                        case 8:
                            x = ((int)(image.Width * 0.5f)) - (image2.Width / 2);
                            y = ((int)(image.Height * 0.99f)) - image2.Height;
                            break;

                        case 9:
                            x = ((int)(image.Width * 0.99f)) - image2.Width;
                            y = ((int)(image.Height * 0.99f)) - image2.Height;
                            break;
                    }
                    graphics.InterpolationMode = InterpolationMode.High;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.DrawImage(image2, new Rectangle(x, y, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel, imageAttr);
                    ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo encoder = null;
                    foreach (ImageCodecInfo info2 in imageEncoders)
                    {
                        if (info2.MimeType.IndexOf("jpeg") > -1)
                        {
                            encoder = info2;
                        }
                    }
                    EncoderParameters encoderParams = new EncoderParameters();
                    long[] numArray = new long[1];
                    if ((quality < 0) || (quality > 100))
                    {
                        quality = 80;
                    }
                    numArray[0] = quality;
                    EncoderParameter parameter = new EncoderParameter(Encoder.Quality, numArray);
                    encoderParams.Param[0] = parameter;
                    if (encoder != null)
                    {
                        image.Save(imgPath, encoder, encoderParams);
                    }
                    else
                    {
                        image.Save(imgPath);
                    }
                    graphics.Dispose();
                    image.Dispose();
                    image2.Dispose();
                    imageAttr.Dispose();
                }
            }
        }

        public static void AddImageSignText(string imgPath, string watermarkText, int watermarkStatus, string Fontclor, string fontname, float fontsize)
        {
            Image image = Image.FromStream(new MemoryStream(File.ReadAllBytes(imgPath)));
            Graphics graphics = Graphics.FromImage(image);
            Font font = new Font(fontname, fontsize, FontStyle.Regular, GraphicsUnit.Pixel);
            SizeF ef = graphics.MeasureString(watermarkText, font);
            float x = 0f;
            float y = 0f;
            switch (watermarkStatus)
            {
                case 1:
                    x = image.Width * 0.01f;
                    y = image.Height * 0.01f;
                    break;

                case 2:
                    x = (image.Width * 0.5f) - (ef.Width / 2f);
                    y = image.Height * 0.01f;
                    break;

                case 3:
                    x = (image.Width * 0.99f) - ef.Width;
                    y = image.Height * 0.01f;
                    break;

                case 4:
                    x = image.Width * 0.01f;
                    y = (image.Height * 0.5f) - (ef.Height / 2f);
                    break;

                case 5:
                    x = (image.Width * 0.5f) - (ef.Width / 2f);
                    y = (image.Height * 0.5f) - (ef.Height / 2f);
                    break;

                case 6:
                    x = (image.Width * 0.99f) - ef.Width;
                    y = (image.Height * 0.5f) - (ef.Height / 2f);
                    break;

                case 7:
                    x = image.Width * 0.01f;
                    y = (image.Height * 0.99f) - ef.Height;
                    break;

                case 8:
                    x = (image.Width * 0.5f) - (ef.Width / 2f);
                    y = (image.Height * 0.99f) - ef.Height;
                    break;

                case 9:
                    x = (image.Width * 0.99f) - ef.Width;
                    y = (image.Height * 0.99f) - ef.Height;
                    break;
            }
            SolidBrush brush = new SolidBrush(Utils.ToColor(Fontclor));
            graphics.DrawString(watermarkText, font, new SolidBrush(Color.Black), x, y);
            graphics.DrawString(watermarkText, font, brush, (float)(x + 1f), (float)(y + 1f));
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo encoder = null;
            foreach (ImageCodecInfo info2 in imageEncoders)
            {
                if (info2.MimeType.IndexOf("jpeg") > -1)
                {
                    encoder = info2;
                }
            }
            EncoderParameters encoderParams = new EncoderParameters();
            long[] numArray = new long[] { 100L };
            EncoderParameter parameter = new EncoderParameter(Encoder.Quality, numArray);
            encoderParams.Param[0] = parameter;
            if (encoder != null)
            {
                image.Save(imgPath, encoder, encoderParams);
            }
            else
            {
                image.Save(imgPath);
            }
            graphics.Dispose();
            image.Dispose();
        }

        public static void AddImageSignText(string imgPath, string watermarkText, int watermarkStatus, string Fontclor, string fontname, float fontsize, int alpha)
        {
            Image image = Image.FromStream(new MemoryStream(File.ReadAllBytes(imgPath)));
            Graphics graphics = Graphics.FromImage(image);
            Font font = new Font(fontname, fontsize, FontStyle.Regular, GraphicsUnit.Pixel);
            SizeF ef = graphics.MeasureString(watermarkText, font);
            float num = 0f;
            float num2 = 0f;
            switch (watermarkStatus)
            {
                case 1:
                    num = image.Width * 0.01f;
                    num2 = image.Height * 0.01f;
                    break;

                case 2:
                    num = (image.Width * 0.5f) - (ef.Width / 2f);
                    num2 = image.Height * 0.01f;
                    break;

                case 3:
                    num = (image.Width * 0.99f) - ef.Width;
                    num2 = image.Height * 0.01f;
                    break;

                case 4:
                    num = image.Width * 0.01f;
                    num2 = (image.Height * 0.5f) - (ef.Height / 2f);
                    break;

                case 5:
                    num = (image.Width * 0.5f) - (ef.Width / 2f);
                    num2 = (image.Height * 0.5f) - (ef.Height / 2f);
                    break;

                case 6:
                    num = (image.Width * 0.99f) - ef.Width;
                    num2 = (image.Height * 0.5f) - (ef.Height / 2f);
                    break;

                case 7:
                    num = image.Width * 0.01f;
                    num2 = (image.Height * 0.99f) - ef.Height;
                    break;

                case 8:
                    num = (image.Width * 0.5f) - (ef.Width / 2f);
                    num2 = (image.Height * 0.99f) - ef.Height;
                    break;

                case 9:
                    num = (image.Width * 0.99f) - ef.Width;
                    num2 = (image.Height * 0.99f) - ef.Height;
                    break;
            }
            Color baseColor = Utils.ToColor(Fontclor);
            SolidBrush brush = new SolidBrush(Color.FromArgb(Convert.ToInt32((int)((0x100 * alpha) / 10)), baseColor));
            graphics.DrawString(watermarkText, font, brush, (float)(num + 1f), (float)(num2 + 1f));
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo encoder = null;
            foreach (ImageCodecInfo info2 in imageEncoders)
            {
                if (info2.MimeType.IndexOf("jpeg") > -1)
                {
                    encoder = info2;
                }
            }
            EncoderParameters encoderParams = new EncoderParameters();
            long[] numArray = new long[] { 100L };
            EncoderParameter parameter = new EncoderParameter(Encoder.Quality, numArray);
            encoderParams.Param[0] = parameter;
            if (encoder != null)
            {
                image.Save(imgPath, encoder, encoderParams);
            }
            else
            {
                image.Save(imgPath);
            }
            graphics.Dispose();
            image.Dispose();
        }

        public static void CreateThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            Image image = Image.FromFile(originalImagePath);
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num5 = image.Width;
            int num6 = image.Height;
            switch (mode)
            {
                case "W":
                    num2 = (image.Height * width) / image.Width;
                    break;

                case "H":
                    num = (image.Width * height) / image.Height;
                    break;

                case "Cut":
                    if ((((double)image.Width) / ((double)image.Height)) > (((double)num) / ((double)num2)))
                    {
                        num6 = image.Height;
                        num5 = (image.Height * num) / num2;
                        y = 0;
                        x = (image.Width - num5) / 2;
                    }
                    else
                    {
                        num5 = image.Width;
                        num6 = (image.Width * height) / num;
                        x = 0;
                        y = (image.Height - num6) / 2;
                    }
                    break;
            }
            Image image2 = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num5, num6), GraphicsUnit.Pixel);
            long[] numArray = new long[] { 100L };
            EncoderParameters encoderParams = new EncoderParameters();
            EncoderParameter parameter = new EncoderParameter(Encoder.Quality, numArray);
            encoderParams.Param[0] = parameter;
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo encoder = null;
            for (int i = 0; i < imageEncoders.Length; i++)
            {
                if (imageEncoders[i].FormatDescription.Equals("JPEG"))
                {
                    encoder = imageEncoders[i];
                    break;
                }
            }
            try
            {
                if (encoder != null)
                {
                    image2.Save(thumbnailPath, encoder, encoderParams);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
            }
        }

        public static void CreateThumbnailAuto(string originalImagePath, string thumbnailPath, int width, int height)
        {
            Image image = Image.FromFile(originalImagePath);
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num5 = image.Width;
            int num6 = image.Height;
            string str = string.Empty;
            if ((((double)num5) / ((double)num6)) > 1.0)
            {
                str = "W";
            }
            else if ((((double)num5) / ((double)num6)) == 1.0)
            {
                str = "HW";
            }
            else
            {
                str = "H";
            }
            if (num2 <= 20)
            {
                str = "H";
            }
            if ((width > num5) && (height > num6))
            {
                num = num5;
                num2 = num6;
                str = "No";
            }
            switch (str)
            {
                case "W":
                    num2 = (image.Height * width) / image.Width;
                    break;

                case "H":
                    num = (image.Width * height) / image.Height;
                    break;

                case "Cut":
                    if ((((double)image.Width) / ((double)image.Height)) > (((double)num) / ((double)num2)))
                    {
                        num6 = image.Height;
                        num5 = (image.Height * num) / num2;
                        y = 0;
                        x = (image.Width - num5) / 2;
                    }
                    else
                    {
                        num5 = image.Width;
                        num6 = (image.Width * height) / num;
                        x = 0;
                        y = (image.Height - num6) / 2;
                    }
                    break;
            }
            Size size = smethod_0(num, num2, num5, num6);
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num5, num6), GraphicsUnit.Pixel);
            graphics.Dispose();
            EncoderParameters encoderParams = new EncoderParameters();
            long[] numArray = new long[] { 100L };
            EncoderParameter parameter = new EncoderParameter(Encoder.Quality, numArray);
            encoderParams.Param[0] = parameter;
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo encoder = null;
            for (int i = 0; i < imageEncoders.Length; i++)
            {
                if (imageEncoders[i].FormatDescription.Equals("JPEG"))
                {
                    encoder = imageEncoders[i];
                    break;
                }
            }
            try
            {
                if (encoder != null)
                {
                    bitmap.Save(thumbnailPath, encoder, encoderParams);
                }
                else
                {
                    bitmap.Save(thumbnailPath, ImageFormat.Jpeg);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                image.Dispose();
                bitmap.Dispose();
                graphics.Dispose();
            }
        }

        public static int CreateThumbnailAutoAlbum(string originalImagePath, string thumbnailPath, int width, int height)
        {
            Image image = Image.FromFile(originalImagePath);
            if ((image.Width < 60) || (image.Height < 60))
            {
                return 0;
            }
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num4 = image.Width;
            int num3 = image.Height;
            string str = string.Empty;
            if ((((double)num4) / ((double)num3)) > 1.0)
            {
                str = "W";
            }
            else if ((((double)num4) / ((double)num3)) == 1.0)
            {
                str = "HW";
            }
            else
            {
                str = "H";
            }
            switch (str)
            {
                case "W":
                    num2 = (image.Height * width) / image.Width;
                    break;

                case "H":
                    num = (image.Width * height) / image.Height;
                    break;

                case "Cut":
                    if ((((double)image.Width) / ((double)image.Height)) > (((double)num) / ((double)num2)))
                    {
                        num3 = image.Height;
                        num4 = (image.Height * num) / num2;
                        y = 0;
                        x = (image.Width - num4) / 2;
                    }
                    else
                    {
                        num4 = image.Width;
                        num3 = (image.Width * height) / num;
                        x = 0;
                        y = (image.Height - num3) / 2;
                    }
                    break;
            }
            Image image2 = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.White);
            graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num4, num3), GraphicsUnit.Pixel);
            try
            {
                image2.Save(thumbnailPath, ImageFormat.Jpeg);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
            }
            return 1;
        }

        public static void CreateThumbnailAutoOnly(string originalImagePath, string thumbnailPath, int width, int height)
        {
            new FileInfo(originalImagePath).CopyTo(thumbnailPath);
        }

        public static void CreateWater(string originalPath, string generatePath, string addText, string position, string fontType, float fontSize, string fontColor)
        {
            Image image = Image.FromFile(originalPath);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            int[] numArray1 = new int[] { 
                0x3e8, 800, 700, 650, 600, 560, 540, 500, 450, 400, 380, 360, 340, 320, 300, 280, 
                260, 240, 220, 200, 180, 160, 140, 120, 100, 80, 0x48, 0x40, 0x30, 0x20, 0x1c, 0x1a, 
                0x18, 20, 0x1c, 0x10, 14, 12, 10, 8, 6, 4, 2
             };
            Font font = null;
            SizeF ef = new SizeF();
            for (int i = 0; i < 7; i++)
            {
                font = new Font(fontType, fontSize, FontStyle.Bold);
                ef = graphics.MeasureString(addText, font);
                if (((ushort)ef.Width) < ((ushort)image.Width))
                {
                    break;
                }
            }
            float x = 0f;
            float y = 0f;
            string str = position;
            switch (str)
            {
                case null:
                    break;

                case "TOP_LEFT":
                    x = (image.Width * 0.1f) + (ef.Width / 2f);
                    y = image.Height * 0.1f;
                    break;

                case "TOP_RIGHT":
                    x = (image.Width * 0.99f) - (ef.Width / 2f);
                    y = image.Height * 0.01f;
                    break;

                case "BOTTOM_RIGHT":
                    x = (image.Width * 0.99f) - (ef.Width / 2f);
                    y = (image.Height * 0.99f) - ef.Height;
                    break;

                default:
                    if (!(str == "BOTTOM_LEFT"))
                    {
                        if (str == "CENTER")
                        {
                            x = (image.Width * 0.01f) + ef.Width;
                            y = (image.Height * 0.99f) + ef.Width;
                        }
                    }
                    else
                    {
                        x = (image.Width * 0.01f) + (ef.Width / 2f);
                        y = (image.Height * 0.99f) + (ef.Width / 2f);
                    }
                    break;
            }
            Brush brush = new SolidBrush(Utils.ToColor(fontColor));
            graphics.DrawString(addText, font, brush, x, y);
            graphics.Dispose();
            image.Save(generatePath);
            image.Dispose();
        }

        public static void CreateWaterPic(string originalPath, string generatePath, string waterSourcePath, string position)
        {
            Image image = Image.FromFile(originalPath);
            Image image2 = Image.FromFile(waterSourcePath);
            Graphics graphics = Graphics.FromImage(image);
            int x = 0;
            int y = 0;
            string str = position;
            switch (str)
            {
                case null:
                    break;

                case "TOP_LEFT":
                    x = 0;
                    y = 0;
                    goto Label_00AD;

                case "TOP_RIGHT":
                    x = image.Width - image2.Width;
                    y = 0;
                    goto Label_00AD;

                default:
                    if (!(str == "BOTTOM_RIGHT"))
                    {
                        if (!(str == "BOTTOM_LEFT"))
                        {
                            break;
                        }
                        x = 0;
                        y = image.Height - image2.Height;
                    }
                    else
                    {
                        x = image.Width - image2.Width;
                        y = image.Height - image2.Height;
                    }
                    goto Label_00AD;
            }
            x = 0;
            y = 0;
        Label_00AD:
            graphics.DrawImage(image2, new Rectangle(x, y, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel);
            graphics.Dispose();
            image.Save(generatePath);
            image.Dispose();
        }

        public static string ImgsExprotWithDomain(string Detail, string agentid)
        {
            string str = "http://" + ShopSettings.siteDomain;
            string str2 = Detail;
            string[] strArray = Detail.Replace("<", "^").Split(new char[] { '^' });
            for (int i = 0; i < strArray.Length; i++)
            {
                string str5 = strArray[i].ToString();
                if ((str5.Length > 14) && (str5.Substring(0, 3).ToString().ToLower() == "img"))
                {
                    string[] strArray2 = strArray[i].Replace(" ", "⊙").Split(new char[] { '⊙' });
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 10)
                        {
                            string str4 = strArray2[j].Substring(5, 4);
                            if (!(str4.ToLower() == "http"))
                            {
                            }
                            if ((str4.ToLower().Length > 0) && (str4.ToLower() == "/img"))
                            {
                                try
                                {
                                    string str9 = strArray2[j].Substring(strArray2[j].LastIndexOf('/') + 1);
                                    if (j > 0)
                                    {
                                        Detail = str2;
                                    }
                                    try
                                    {
                                        if (j > 0)
                                        {
                                            Detail = str2;
                                        }
                                        if ((agentid.ToLower() == "admin") || (agentid.ToLower() == ""))
                                        {
                                            str2 = Detail.Replace(strArray2[j].ToString(), "src=\"" + str + "/ImgUpload/" + str9);
                                        }
                                        else
                                        {
                                            str2 = Detail.Replace(strArray2[j].ToString(), "src=\"" + str + "/ImgUpload/Agent/" + agentid + "/" + str9);
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                }
            }
            return str2;
        }

        private static Size smethod_0(int int_0, int int_1, int int_2, int int_3)
        {
            double num = 0.0;
            double num2 = 0.0;
            double num3 = Convert.ToDouble(int_2);
            double num4 = Convert.ToDouble(int_3);
            double num5 = Convert.ToDouble(int_0);
            double num6 = Convert.ToDouble(int_1);
            if ((num3 < num5) && (num4 < num6))
            {
                num = num3;
                num2 = num4;
            }
            else if ((num3 / num4) > (num5 / num6))
            {
                num = int_0;
                num2 = (num * num4) / num3;
            }
            else
            {
                num2 = int_1;
                num = (num2 * num3) / num4;
            }
            return new Size(Convert.ToInt32(num), Convert.ToInt32(num2));
        }

        public static bool TextWater(string ImgFile, string TextFont, int Alpha, float widthFont, float hScale, string fontType, string fontColor, float fontSize, string position)
        {
            try
            {
                Color color;
                FileStream input = new FileStream(ImgFile, FileMode.Open);
                BinaryReader reader = new BinaryReader(input);
                byte[] buffer = reader.ReadBytes((int)input.Length);
                reader.Close();
                input.Close();
                MemoryStream stream = new MemoryStream(buffer);
                Image image = Image.FromStream(stream);
                int width = image.Width;
                int height = image.Height;
                Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                bitmap.SetResolution(72f, 72f);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.FromName("white"));
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel);
                Image.FromFile(ImgFile);
                int[] numArray1 = new int[] { 
                    0x3e8, 800, 700, 650, 600, 560, 540, 500, 450, 400, 380, 360, 340, 320, 300, 280, 
                    260, 240, 220, 200, 180, 160, 140, 120, 100, 80, 0x48, 0x40, 0x30, 0x20, 0x1c, 0x1a, 
                    0x18, 20, 0x1c, 0x10, 14, 12, 10, 8, 6, 4, 2
                 };
                Font font = null;
                SizeF ef = new SizeF();
                for (int i = 0; i < 0x2b; i++)
                {
                    font = new Font(fontType, fontSize, FontStyle.Bold);
                    ef = graphics.MeasureString(TextFont, font);
                    if (((ushort)ef.Width) < (((ushort)width) * widthFont))
                    {
                        break;
                    }
                }
                float num4 = ef.Height;
                float num5 = ef.Width;
                int num6 = (int)(height * hScale);
                float single1 = (height - num6) - (ef.Height / 2f);
                StringFormat format = new StringFormat();
                string key = position;
                if (key != null)
                {
                    int num7;
                    if (Class5.dictionary_0 == null)
                    {
                        Dictionary<string, int> dictionary1 = new Dictionary<string, int>(9);
                        dictionary1.Add("1", 0);
                        dictionary1.Add("2", 1);
                        dictionary1.Add("3", 2);
                        dictionary1.Add("4", 3);
                        dictionary1.Add("5", 4);
                        dictionary1.Add("6", 5);
                        dictionary1.Add("7", 6);
                        dictionary1.Add("8", 7);
                        dictionary1.Add("9", 8);
                        Class5.dictionary_0 = dictionary1;
                    }
                    if (Class5.dictionary_0.TryGetValue(key, out num7))
                    {
                        switch (num7)
                        {
                            case 0:
                                format.Alignment = StringAlignment.Near;
                                format.LineAlignment = StringAlignment.Near;
                                goto Label_02D9;

                            case 1:
                                format.Alignment = StringAlignment.Center;
                                format.LineAlignment = StringAlignment.Near;
                                goto Label_02D9;

                            case 2:
                                format.Alignment = StringAlignment.Far;
                                format.LineAlignment = StringAlignment.Near;
                                goto Label_02D9;

                            case 3:
                                format.Alignment = StringAlignment.Near;
                                format.LineAlignment = StringAlignment.Center;
                                goto Label_02D9;

                            case 4:
                                format.Alignment = StringAlignment.Center;
                                format.LineAlignment = StringAlignment.Center;
                                goto Label_02D9;

                            case 5:
                                format.Alignment = StringAlignment.Far;
                                format.LineAlignment = StringAlignment.Center;
                                goto Label_02D9;

                            case 6:
                                format.Alignment = StringAlignment.Near;
                                format.LineAlignment = StringAlignment.Far;
                                goto Label_02D9;

                            case 7:
                                format.Alignment = StringAlignment.Center;
                                format.LineAlignment = StringAlignment.Far;
                                goto Label_02D9;

                            case 8:
                                format.Alignment = StringAlignment.Far;
                                format.LineAlignment = StringAlignment.Far;
                                goto Label_02D9;
                        }
                    }
                }
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
            Label_02D9:
                color = Utils.ToColor(fontColor);
                SolidBrush brush = new SolidBrush(Color.FromArgb(Alpha, color));
                graphics.DrawString(TextFont, font, brush, new RectangleF(0f, 0f, num5, num4), format);
                bitmap.Save(ImgFile, ImageFormat.Jpeg);
                graphics.Dispose();
                image.Dispose();
                bitmap.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
