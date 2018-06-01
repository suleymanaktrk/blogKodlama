using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace blogKodlama
{
    public static class cExtensions
    {

        public static bool IsEmail(this string Text)
        {
            try
            {
                MailAddress m = new MailAddress(Text);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ToEN(this string Text)
        {
            Text = Regex.Replace(Text, "ş", "s");
            Text = Regex.Replace(Text, "ı", "i");
            Text = Regex.Replace(Text, "ö", "o");
            Text = Regex.Replace(Text, "ü", "u");
            Text = Regex.Replace(Text, "ç", "c");
            Text = Regex.Replace(Text, "ğ", "g");
            Text = Regex.Replace(Text, "Ş", "S");
            Text = Regex.Replace(Text, "İ", "I");
            Text = Regex.Replace(Text, "Ö", "O");
            Text = Regex.Replace(Text, "Ü", "U");
            Text = Regex.Replace(Text, "Ç", "C");
            Text = Regex.Replace(Text, "Ğ", "G");

            return Text;
        }

        public static string ToURL(this string Text)
        {
            string title = Text;
            title = title.Trim();
            title = title.Trim('-');
            title = title.ToLower();

            char[] chars = @"$%#@!*?;:~`’+=()[]{}|\'<>,/^&™"".".ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (title.Contains(strChar))
                    title = title.Replace(strChar, string.Empty);
            }

            title = title.Replace(" ", "-");
            title = title.Replace("--", "-");
            title = title.Replace("---", "-");
            title = title.Replace("----", "-");
            title = title.Replace("-----", "-");
            title = title.Replace("----", "-");
            title = title.Replace("---", "-");
            title = title.Replace("--", "-");
            title = title.Replace("ü", "u");
            title = title.Replace("ğ", "g");
            title = title.Replace("ş", "s");
            title = title.Replace("ö", "o");
            title = title.Replace("ç", "c");
            title = title.Replace("ı", "i");
            title = title.Replace("İ", "I");
            title = title.Replace("Ü", "U");
            title = title.Replace("Ö", "O");

            title = title.Trim();
            title = title.Trim('-');


            return title;
        }

        public static int ToReverse(this int CurrentValue)
        {
            if (CurrentValue == 1)
                return 0;
            else
                return 1;
        }

        public static bool ToBool(this object Value)
        {
            if (Convert.ToInt32(Value) == 1)
                return true;
            else
                return false;
        }

        public static string ToMD5(this string ClearText)
        {
            byte[] ByteData = Encoding.ASCII.GetBytes(ClearText);
            MD5 oMd5 = MD5.Create();
            byte[] HashData = oMd5.ComputeHash(ByteData);
            StringBuilder oSb = new StringBuilder();

            for (int x = 0; x < HashData.Length; x++)
            {
                oSb.Append(HashData[x].ToString("x2"));
            }

            return oSb.ToString();
        }

        public static bool IsTextBoxEmptyOrNull(this string Text)
        {

            if (String.IsNullOrEmpty(Text))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public static bool AreAllTextboxIsEmptyOrNull(this Panel ID)
        {
            bool ok = false;
            foreach (Control item in ID.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    if (txt.Text.isVeriNuLL())
                        ok = true;
                    else
                        ok = false;

                }
                if (item is HtmlInputText)
                {
                    HtmlInputText inptx = (HtmlInputText)item;
                    if (inptx.Value.isVeriNuLL())
                        ok = true;
                    else
                        ok = false;
                }

            }
            if (ok)
                return true;
            else
                return false;
        }

        public static bool ZipCode(this string Text)
        {
            bool zipdogrumu = Regex.IsMatch(Text, "[a-zA-Z0-9]$");

            if (zipdogrumu)  //"^[0-9A-Za-z ]+$" 
            {
                if (Text.Length < 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public static string GrowfirstCharacter(this string Tex)
        {
            string yeniKelime = "";
            if (Tex.Contains(" "))
            {
                string[] words = Tex.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    yeniKelime += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1, words[i].Length - 1).ToLower() + " ";
                }

                Tex = yeniKelime.TrimEnd(' ');
            }
            else
            {
                Tex = Tex.Substring(0, 1).ToUpper() + Tex.Substring(1, Tex.Length - 1).ToLower();
            }

            return Tex;
        }

        public static bool OnlyLetters(this string Text, int MaxLen)
        {
            if (!String.IsNullOrEmpty(Text))
            {
                bool uyuyomu = Regex.IsMatch(Text, "^[a-zA-ZöÖçÇİışŞÜü\\s]+$");
                if (uyuyomu)
                {
                    if (Text.Length <= MaxLen)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool OnlyLettersAndNumbers(this string Text, int MaxLen)
        {
            if (!String.IsNullOrEmpty(Text))
            {
                bool uyuyomu = Regex.IsMatch(Text, "^[a-zA-Z0-9öÖçÇİışŞÜü\\s]+$");
                if (uyuyomu)
                {
                    if (Text.Length < MaxLen)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                } 
            }
            else
            {
                return false;  
            }
        }

        public static bool isNumara(this string Numara, int MaxLen)
        {
            if (!String.IsNullOrEmpty(Numara))
            {
                bool uyuyomu = Regex.IsMatch(Numara, "^[0-9]+$");

                if (uyuyomu)
                {
                    if (Numara.Length <= MaxLen)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                } 
            }
            else
            {
                return false;
            }

        }
        public static bool isNumara(this string Numara)
        {
            if (!String.IsNullOrEmpty(Numara))
            {
                bool uyuyomu = Regex.IsMatch(Numara, "^[0-9]+$");
                if (uyuyomu)
                    return true;
                else
                    return false; 
            }
            else
            {
                return false;
            }

        }

        public static bool isValidTC(this string TCKimlik)
        {
            if (TCKimlik.Length == 11)
            {
                try
                {
                    int lastHane = Convert.ToInt32(TCKimlik.Substring(10));
                    if (lastHane % 2 != 1)
                    {
                        string ilk10Hane = TCKimlik.Substring(0, 10);
                        int toplam = 0;
                        foreach (char item in ilk10Hane)
                        {
                            toplam += Convert.ToInt32(item.ToString());
                        }
                        if (toplam % 10 == lastHane)
                            return true;
                        else
                            return false;

                    }
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public static bool IsDate(this object Text)
        {
            try
            {

                DateTime dt = Convert.ToDateTime(Text);

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public static bool IsPhone(this string Text)
        {
            bool sabit = Regex.IsMatch(Text, "[+][9]{1}[0]{1}[0-9]{10}$");
            bool cep = Regex.IsMatch(Text, "[+][9]{1}[0]{1}[5]{1}[0-9]{9}$");

            if (sabit || cep)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static ArrayList GetSelectedItems(this Repeater rpt, string chkBoxId)
        {
            var selectedValues = new ArrayList();
            for (int i = 0; i < rpt.Items.Count; i++)
            {
                var chkBox = rpt.Items[i].FindControl(chkBoxId) as HtmlInputCheckBox;

                if (chkBox != null && chkBox.Checked)
                {

                    //string[] degerlen = chkBox.Attributes["class"].Split(' ');
                    selectedValues.Add(chkBox.Value);
                }

            }
            return selectedValues;
        }

        public static ArrayList GetSectionItems(this Repeater rpt, string chkBoxId)
        {
            var selectedValues = new ArrayList();
            for (int i = 0; i < rpt.Items.Count; i++)
            {
                var chkBox = rpt.Items[i].FindControl(chkBoxId) as HtmlInputCheckBox;

                if (chkBox != null && chkBox.Checked)
                {

                    //string[] degerlen = chkBox.Attributes["class"].Split(' ');
                    selectedValues.Add(chkBox.Value);
                }

            }
            return selectedValues;
        }

        public static bool fileHasFile(this FileUpload id)
        {

            if (id.HasFile)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool veriBagla(this Repeater rpt, IEnumerable veri)
        {
            var col = veri as ICollection;
            if (veri != null && col.Count > 0)
            {
                rpt.DataSource = veri;
                rpt.DataBind();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void BindVeri(this Repeater rpt, IEnumerable veri)
        {
            var col = veri as ICollection;
            if (veri != null && col.Count > 0)
            {
                rpt.DataSource = veri;
                rpt.DataBind();
            }
        }

        public static void BindVeri(this DropDownList drp, IEnumerable veri, string Text, string Value, int zeroVal, string zeroText)
        {
            var col = veri as ICollection;
            if (veri != null && col.Count > 0)
            {
                drp.DataTextField = Text;
                drp.DataValueField = Value;
                drp.DataSource = veri;
                drp.DataBind();
                drp.Items.Insert(zeroVal, zeroText);
            }
        }

        public static bool isVeriNuLL(this IEnumerable veri)
        {
            var col = veri as ICollection;
            if (veri != null && col.Count > 0)
                return false;
            else
                return true;
        }


        public static bool InputTemizle(this Panel id)
        {
            try
            {
                foreach (var item in id.Controls)
                {
                    if (item is TextBox) //TextBox için TextBox At!
                    {
                        TextBox yeni = (TextBox)item;
                        yeni.Text = "";
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Herhangi bir dropdownlist'e DropDownList.Gun() şeklinde DataSource baglanır
        public static bool Gun(this DropDownList drpGun)
        {
            List<ListItem> gunler = new List<ListItem>();
            DateTime bugun = DateTime.Now;

            for (int i = 1; i <= DateTime.DaysInMonth(bugun.Year, bugun.Month)+1; i++)
            {
                if (i == 1)
                {
                    gunler.Add(new ListItem { Text = "Gün", Value = "sec" });
                }
                else
                {
                    gunler.Add(new ListItem { Text = (i - 1).ToString(), Value = (i - 1).ToString() });
                }

            }
            drpGun.DataSource = gunler;
            drpGun.DataBind();

            return true;
        }

        //Herhangi bir dropdownlist'e DropDownList.Ay() şeklinde  DataSource baglanır
        public static bool Ay(this DropDownList drpAy)
        {
            List<ListItem> aylar = new List<ListItem>();
            string[] ay = new string[] { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };
            for (int i = 0; i < ay.Length + 1; i++)
            {
                if (i == 0)
                {
                    aylar.Add(new ListItem { Text = "Ay", Value = "sec" });
                }
                else
                {
                    aylar.Add(new ListItem { Text = ay[i - 1].ToString(), Value = i.ToString() });
                }
            }
            drpAy.DataTextField = "Text";
            drpAy.DataValueField = "Value";
            drpAy.DataSource = aylar;
            drpAy.DataBind();
            return true;
        }

        //Herhangi bir dropdownlist'e DropDownList.Yil() şeklinde  DataSource baglanır
        public static bool Yil(this DropDownList drpYil)
        {
            List<ListItem> yillar = new List<ListItem>();
            for (int i = (DateTime.Now.Year - 18); i > 1930; i--)
            {
                if (i == (DateTime.Now.Year - 18))
                {
                    yillar.Add(new ListItem { Text = "Yıl", Value = "sec" });
                }
                else
                {
                    yillar.Add(new ListItem { Text = (i + 1).ToString(), Value = (i + 1).ToString() });
                }

            }
            drpYil.DataSource = yillar;
            drpYil.DataBind();
            return true;

        }

        //Eklenen Kontrole CssClass Ekler. ( var olan üzerine ekler.)
        public static void AddCSSClass(this WebControl control, string cssClass)
        {
            control.CssClass += " " + cssClass;
        }

        public static bool isDecimal(this string text)
        {
            try
            {
                Convert.ToDecimal(text);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }


    }
}