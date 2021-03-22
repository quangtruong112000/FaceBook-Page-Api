using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TranQuangTruong_5951071114
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var req = WebRequest.Create("https://graph.facebook.com/utc2hcmc/posts?access_token=EAAAAZAw4FxQIBACBm9vuTinKlJ5IuSiibCXt51ZAHFd5Yk81kXMcioMx51LOIInj60O2c3dsAiMZCYZApReIDLLNk2La4uAmXm1Xm2zD9SS7TmN5e6ZBW2ZBRVfKH319keeM6gPe5or9afU0QhOolMdEogf06gtT0TEHYZBDL4KkwZDZD");
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            Stream stream = res.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string stringres = reader.ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(stringres);
            var results = new List<Info>();
            foreach (var item in json.data)
            {
                results.Add(new Info
                {
                    Time = item.created_time,
                    Content = item.message,
                    Link = item.actions[0].link,
                });
            }
            string s = "";
            for (int i = 0; i < 3; i++)
            {
                s += "<b>Bài" + (i + 1) + ": </b>" + "</br>";
                s += "<b>Ngày đăng: </b>" + results[i].Time + "</br>";
                s += "<b>Nội dung: </b>" + results[i].Content + "</br>";
                s += "<b>Link: </b>" + results[i].Link + "</br>";
            }
            lblresult.Text = s;
        }
    }
}