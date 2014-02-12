using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace The_Wet_Zone.ViewModels
{

    public class userID {
        public string UID { get; set; }
    
    }

    public class UserInfo
    {
        string uid;

        public string Userid
        {
            get { return uid; }
            set { uid = value; }
        }

    }

    public class cleanString
    {
        private string valReplace = "<!-- www.1freehosting.com Analytics Code -->\r\n<noscript><a title=\"Free hosting\" href=\"http://www.1freehosting.com\" rel=\"nofollow\">Free hosting</a><a title=\"Web host free\" href=\"http://www.1freehosting.com\" rel=\"nofollow\">Web host free</a><a title=\"Free websites hosting\" href=\"http://www.1freehosting.com/free-website-and-hosting.html\" rel=\"nofollow\">Free websites hosting</a><a title=\"Pagerank SEO analytic\" href=\"http://www.1pagerank.com\">Pagerank SEO analytic</a></noscript>\r\n<script type=\"text/javascript\">\r\n\r\n  var _gaq = _gaq || [];\r\n  _gaq.push(['_setAccount', 'UA-21588661-2']);\r\n  _gaq.push(['_setDomainName', window.location.host]);\r\n  _gaq.push(['_setAllowLinker', true]);\r\n  _gaq.push(['_trackPageview']);\r\n\r\n  (function() {\r\n    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;\r\n    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';\r\n    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);\r\n\r\n    var fga = document.createElement('script'); fga.type = 'text/javascript'; fga.async = true;\r\n    fga.src = ('https:' == document.location.protocol ? 'https://www' : 'http://www') + '.1freehosting.com/cdn/ga.js';\r\n    var fs = document.getElementsByTagName('script')[0]; fs.parentNode.insertBefore(fga, fs);\r\n\r\n  })();\r\n</script>\r\n<!-- End Of Analytics Code -->";
        
        public string clear(string val)
        {
            val = val.Replace(this.valReplace,"");
            return val;
        }
    }

    public class result
    {
        public int total { get; set; }
    }

    public class iconsHelpTry
    {
        public int idicon { get; set; }
        public string icon { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class states
    {
        public int idstate { get; set; }
        public string state { get; set; }
        public int idcountry { get; set; }
    }

    public class types
    {
        public int idtype { get; set; }
        public string type { get; set; }
        public string description { get; set; }
    }

    public class tipsInfoTry
    {
        public int idtip { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string description { get; set; }
    }

    public class countryTry
    {
        public int idcountry { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string nationality { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double zoom { get; set; }
    }

    public class placeTry
    {
        public int idplace { get; set; }
        public string photo { get; set; }
        public string title { get; set; }
        public string descripcion { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
        public int idstate { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int idtype { get; set; }
        public string fullAddress { get; set; }
    }

    public class FirstTime {
        bool activate;

        public bool Activate
        {
            get { return activate; }
            set { activate = value; }
        }
    }
}