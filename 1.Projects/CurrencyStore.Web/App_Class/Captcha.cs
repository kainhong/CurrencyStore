﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using CurrencyStore.Utility;

namespace CurrencyStore.Web.App_Class
{
    public class Captcha
    {
        public string VerifyCodeText
        {
            get;
            set;
        }
        public int Length
        {
            get;
            set;
        }
        public bool AddLowerLetter
        {
            get;
            set;
        }
        public bool AddUpperLetter
        {
            get;
            set;
        }
        public int FontSize
        {
            get;
            set;
        }
        public Color FontColor
        {
            get;
            set;
        }
        public string FontFamily
        {
            get;
            set;
        }
        public Color BackgroundColor
        {
            get;
            set;
        }
        public int ForeNoisePointCount
        {
            get;
            set;
        }
        public int RandomAngle
        {
            get;
            set;
        }
        public Captcha()
        {
            this.Length = 4;
            this.AddLowerLetter = false;
            this.AddUpperLetter = false;
            this.FontSize = 18;
            this.FontColor = this.GetRandomColor();
            this.FontFamily = "Verdana";
            this.BackgroundColor = Color.AliceBlue;
            this.ForeNoisePointCount = 3;
            this.RandomAngle = 45;
            this.GetText();
        }
        public Color GetRandomColor()
        {
            //为了在白色背景上显示，尽量生成深色
            int int_Red = ThreadSafeRandom.Next(256);
            int int_Green = ThreadSafeRandom.Next(256);
            int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;

            return Color.FromArgb(int_Red, int_Green, int_Blue);
        }
        private void GetText()
        {
            //没有外部输入验证码时随机生成
            if (String.IsNullOrEmpty(this.VerifyCodeText))
            {
                StringBuilder objStringBuilder = new StringBuilder();

                //加入数字1-9
                for (int i = 1; i <= 9; i++)
                {
                    objStringBuilder.Append(i.ToString());
                }

                //加入大写字母A-Z，不包括O
                if (this.AddUpperLetter)
                {
                    char temp = ' ';

                    for (int i = 0; i < 26; i++)
                    {
                        temp = Convert.ToChar(i + 65);

                        //如果生成的字母不是'O'
                        if (!temp.Equals('O'))
                        {
                            objStringBuilder.Append(temp);
                        }
                    }
                }

                //加入小写字母a-z，不包括o
                if (this.AddLowerLetter)
                {
                    char temp = ' ';

                    for (int i = 0; i < 26; i++)
                    {
                        temp = Convert.ToChar(i + 97);

                        //如果生成的字母不是'o'
                        if (!temp.Equals('o'))
                        {
                            objStringBuilder.Append(temp);
                        }
                    }
                }

                //生成验证码字符串
                {
                    int index = 0;

                    for (int i = 0; i < this.Length; i++)
                    {
                        index = ThreadSafeRandom.Next(0, objStringBuilder.Length);

                        this.VerifyCodeText += objStringBuilder[index];

                        objStringBuilder.Remove(index, 1);
                    }
                }
            }
        }
        private Bitmap GetImage()
        {
            Bitmap result = null;

            //创建绘图
            result = new Bitmap(this.VerifyCodeText.Length * 16, 25);

            using (Graphics objGraphics = Graphics.FromImage(result))
            {
                objGraphics.SmoothingMode = SmoothingMode.HighQuality;

                //清除整个绘图面并以指定背景色填充
                objGraphics.Clear(this.BackgroundColor);

                //创建画笔
                using (SolidBrush objSolidBrush = new SolidBrush(this.FontColor))
                {
                    this.AddForeNoisePoint(result);

                    this.AddBackgroundNoisePoint(result, objGraphics);

                    //文字居中
                    StringFormat objStringFormat = new StringFormat(StringFormatFlags.NoClip);

                    objStringFormat.Alignment = StringAlignment.Center;
                    objStringFormat.LineAlignment = StringAlignment.Center;

                    //字体样式
                    Font objFont = new Font(this.FontFamily, ThreadSafeRandom.Next(this.FontSize - 3, this.FontSize), FontStyle.Regular);

                    //验证码旋转，防止机器识别
                    char[] chars = this.VerifyCodeText.ToCharArray();

                    for (int i = 0; i < chars.Length; i++)
                    {
                        //转动的度数
                        float angle = ThreadSafeRandom.Next(-this.RandomAngle, this.RandomAngle);

                        objGraphics.TranslateTransform(12, 12);
                        objGraphics.RotateTransform(angle);
                        objGraphics.DrawString(chars[i].ToString(), objFont, objSolidBrush, -2, 2, objStringFormat);
                        objGraphics.RotateTransform(-angle);
                        objGraphics.TranslateTransform(2, -12);
                    }
                }
            }

            return result;
        }
        private void AddForeNoisePoint(Bitmap objBitmap)
        {
            for (int i = 0; i < objBitmap.Width * this.ForeNoisePointCount; i++)
            {
                objBitmap.SetPixel(ThreadSafeRandom.Next(objBitmap.Width),
                    ThreadSafeRandom.Next(objBitmap.Height), this.FontColor);
            }
        }
        private void AddBackgroundNoisePoint(Bitmap objBitmap, Graphics objGraphics)
        {
            using (Pen objPen = new Pen(Color.Azure, 0))
            {
                for (int i = 0; i < objBitmap.Width * 2; i++)
                {
                    objGraphics.DrawRectangle(objPen, ThreadSafeRandom.Next(objBitmap.Width),
                        ThreadSafeRandom.Next(objBitmap.Height), 1, 1);
                }
            }
        }
        public void Output(HttpResponse objHttpResponse)
        {
            using (Bitmap objBitmap = this.GetImage())
            {
                if (objBitmap != null)
                {
                    using (MemoryStream objMS = new MemoryStream())
                    {
                        objBitmap.Save(objMS, ImageFormat.Jpeg);

                        HttpContext.Current.Response.ClearContent();
                        HttpContext.Current.Response.ContentType = "image/Jpeg";
                        HttpContext.Current.Response.BinaryWrite(objMS.ToArray());
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                }
            }
        }
    }
}