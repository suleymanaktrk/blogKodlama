using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;


namespace blogKodlama
{
    public class cMember : cBase
    {
        public bool adminLogin(string username, string Password) //veri tabanında kullanıcı arar varsa true döndürür.
        {
            Password = Password.ToMD5();
            username = CleanHTML(username);
            var login = (from c in db.tbl_Users
                         where c.email == username && c.sifre == Password && c.is_active==1
                         select new
                         {
                             c.id,
                             c.email,
                             c.role

                         }).FirstOrDefault();

            if (login == null)
                return false;
            else
            {
                HttpContext.Current.Session["admin_login"] = true;
                HttpContext.Current.Session["admin_id"] = login.id;
                HttpContext.Current.Session["admin_username"] = login.email;
                HttpContext.Current.Session["role"] = login.role;
                return true;
            }
        }

        public bool adminIsLogged()
        {

            try
            {
                if (HttpContext.Current.Session["admin_login"] == null)
                {
                    if (HttpContext.Current.Request.Cookies["HK"] != null)
                    {
                        string cookie_content = HttpContext.Current.Request.Cookies["HK"].Value;

                        if (cookie_content != "")
                        {
                            cookie_content = cEncrytion.DecryptString(cookie_content);

                            if (cookie_content.Contains("-ls-"))
                                if (adminLogin(Regex.Split(cookie_content, "-ls-")[0], Regex.Split(cookie_content, "-ls-")[1]))
                                    return true;
                                else
                                    return false;
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    if (Convert.ToBoolean(HttpContext.Current.Session["admin_login"]))
                        return true;
                    else
                        return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}