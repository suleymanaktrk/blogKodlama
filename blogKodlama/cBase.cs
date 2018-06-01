using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;

namespace blogKodlama
{
    public class cBase : System.Web.UI.Page
    {

        //public static SqlConnection Conn = new SqlConnection(@"Data Source=31.210.66.74;Initial Catalog=siteler;User ID=sa;Password=_9800JOqDpbfI_;pooling=true;max pool size=1000000");
        //public sitelerEntities db = new sitelerEntities ();


        public dbBlogEntities db = new dbBlogEntities();
        public cBase()
        {
            //if (Conn.State == ConnectionState.Closed) Conn.Open();
        }
        

        /// <summary>
        /// Refresh Current Page
        /// </summary>
        public static void RefreshPage()
        {
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
        }

        public static void Git(string url) {
            HttpContext.Current.Response.Redirect(url,false);
        }

        public static void Yaz(string Text)
        {
            HttpContext.Current.Response.Write(Text);
        }

        public static string Query(string Text)
        {
            return HttpContext.Current.Request.QueryString[Text];
        }

        public static int Sayi(string Text)
        {
            return Convert.ToInt32(Text);
        }

        public static string CleanHTML(string Text)
        {
            Regex objRegExp = new Regex("<(.|\n)+?>");
            return objRegExp.Replace(Text, String.Empty);
        }

        public static bool IsNumeric(string text)
        {
            if (text == null)
                return false;
            else
                return Regex.IsMatch(text, "^\\d+$");
        }

        public static bool IsEmail(string inputEmail)
        {
            if (inputEmail == null)
                return false;
            else
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(inputEmail))
                    return true;
                else
                    return false;
            }
        }

        public static bool ResizeImage(string imagepath, int w, int h)
        {
            try
            {
                System.Drawing.Image resmimiz = byteArrayToImage(File.ReadAllBytes(HttpContext.Current.Server.MapPath(imagepath)));
                Bitmap b = new Bitmap(w, h);
                Graphics g = Graphics.FromImage((System.Drawing.Image)b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(resmimiz, 0, 0, w, h);
                g.Dispose();

                b.Save(HttpContext.Current.Server.MapPath(imagepath));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string URLStringTemizle(string Text)
        {
            string strTitle = Text.ToString();
            strTitle = strTitle.Trim();
            strTitle = strTitle.Trim('-');
            strTitle = strTitle.ToLower();
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                    strTitle = strTitle.Replace(strChar, string.Empty);
            }
            strTitle = strTitle.Replace(" ", "-");
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("-----", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Trim();
            strTitle = strTitle.Trim('-');
            return strTitle;
        }

        public static string AramaKelime(string Text)
        {
            string strTitle = Text.ToString().Replace("\"", "&quot;");
            strTitle = strTitle.Trim();
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'’<>,/^&\"".".ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                    strTitle = strTitle.Replace(strChar, string.Empty);
            }
            strTitle = strTitle.Trim();
            return strTitle;
        }


        public static string GenerateURL(object Title)
        {
            string strTitle = Title.ToString();
            strTitle = strTitle.Trim();
            strTitle = strTitle.Trim('-');
            strTitle = strTitle.ToLower();
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                    strTitle = strTitle.Replace(strChar, string.Empty);
            }
            strTitle = strTitle.Replace(" ", "-");
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("-----", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("ü", "u");
            strTitle = strTitle.Replace("ğ", "g");
            strTitle = strTitle.Replace("ş", "s");
            strTitle = strTitle.Replace("ö", "o");
            strTitle = strTitle.Replace("ç", "c");
            strTitle = strTitle.Replace("ı", "i");
            strTitle = strTitle.Trim();
            strTitle = strTitle.Trim('-');
            return strTitle;
        }


        public static int YeniDegerAl(int CurrentDeger)
        {
            if (CurrentDeger == 1)
                return 0;
            else
                return 1;
        }


        public static string CreateRandomValue(int Length, bool CharactersB, bool CharactersS, bool Numbers, bool SpecialCharacters)
        {
            string characters_b = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string characters_s = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string special_characters = "-_*+/";
            string allowedChars = String.Empty;

            if (CharactersB)
                allowedChars += characters_b;

            if (CharactersS)
                allowedChars += characters_s;

            if (Numbers)
                allowedChars += numbers;

            if (SpecialCharacters)
                allowedChars += special_characters;

            char[] chars = new char[Length];
            Random rd = new Random();

            for (int i = 0; i < Length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        public static string CreateRandomValue(int Length)
        {
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] chars = new char[Length];
            Random rd = new Random();

            for (int i = 0; i < Length; i++)
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];

            return new string(chars);
        }


        private static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public string GetSHA1(string SHA1Data)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            string HashedPassword = SHA1Data;
            byte[] hashbytes = Encoding.GetEncoding("ISO-8859-9").GetBytes(HashedPassword);
            byte[] inputbytes = sha.ComputeHash(hashbytes);

            return GetHexaDecimal(inputbytes);
        }

        public string GetHexaDecimal(byte[] bytes)
        {
            StringBuilder s = new StringBuilder();
            int length = bytes.Length;

            for (int n = 0; n <= length - 1; n++)
            {
                s.Append(String.Format("{0,2:x}", bytes[n]).Replace(" ", "0"));
            }

            return s.ToString();
        }

        public static void RemoveDuplicates(DataTable tbl, DataColumn[] keyColumns)
        {
            int rowNdx = 0;
            while (rowNdx < tbl.Rows.Count - 1)
            {
                DataRow[] dups = FindDups(tbl, rowNdx, keyColumns);
                if (dups.Length > 0)
                    foreach (DataRow dup in dups)
                        tbl.Rows.Remove(dup);
                else
                    rowNdx++;
            }
        }

        private static DataRow[] FindDups(DataTable tbl, int sourceNdx, DataColumn[] keyColumns)
        {
            ArrayList retVal = new ArrayList();
            DataRow sourceRow = tbl.Rows[sourceNdx];
            for (int i = sourceNdx + 1; i < tbl.Rows.Count; i++)
            {
                DataRow targetRow = tbl.Rows[i];
                if (IsDup(sourceRow, targetRow, keyColumns))
                    retVal.Add(targetRow);
            }
            return (DataRow[])retVal.ToArray(typeof(DataRow));
        }

        private static bool IsDup(DataRow sourceRow, DataRow targetRow, DataColumn[] keyColumns)
        {
            bool retVal = true;
            foreach (DataColumn column in keyColumns)
            {
                retVal = retVal && sourceRow[column].Equals(targetRow[column]);
                if (!retVal) break;
            }
            return retVal;
        }

        public static DataTable SrtDataTable(DataTable dt, string sort)
        {
            DataTable newDT = dt.Clone();
            int rowCount = dt.Rows.Count;

            DataRow[] foundRows = dt.Select(null, sort);
            for (int i = 0; i < rowCount; i++)
            {
                object[] arr = new object[dt.Columns.Count];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    arr[j] = foundRows[i][j];
                }
                DataRow data_row = newDT.NewRow();
                data_row.ItemArray = arr;
                newDT.Rows.Add(data_row);
            }

            dt.Rows.Clear();

            for (int i = 0; i < newDT.Rows.Count; i++)
            {
                object[] arr = new object[dt.Columns.Count];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    arr[j] = newDT.Rows[i][j];
                }

                DataRow data_row = dt.NewRow();
                data_row.ItemArray = arr;
                dt.Rows.Add(data_row);
            }
            return dt;
        }

        //------------süleyman eklemeler-----------

        //istemci ip adresini elde eder.
        public static string IPGetir()

        {

            string IPAdres = string.Empty;

            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)

                IPAdres = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();

            else

         if (HttpContext.Current.Request.UserHostAddress.Length != 0)

                IPAdres = HttpContext.Current.Request.UserHostAddress;



            return IPAdres;

        }

        public static string GetUserIP()
        {
            var ip = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
                      && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                     ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                     : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (ip.Contains(","))
                ip = ip.Split(',').First().Trim();
            return ip;
        }

        public static string DenemYaptim(){
            return "Deneme";
        }


    }
}