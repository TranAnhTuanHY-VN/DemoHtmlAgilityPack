using System.Net;

namespace ReadHTMLClassLibrary
{
    public static class ReadHTML
    {
        public static string? Send(string url, string node)
        {
            try
            {
                if (!String.IsNullOrEmpty(url) && !String.IsNullOrEmpty(node))
                {
                    WebClient webClient = new WebClient();
                    webClient.Encoding = System.Text.Encoding.UTF8;
                    string html = webClient.DownloadString(url);
                    if (!String.IsNullOrEmpty(html))
                    {
                        HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument.LoadHtml(html);
                        if (htmlDocument != null)
                        {
                            HtmlAgilityPack.HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode(node);
                            if (htmlNode != null)
                            {
                                string innerText = htmlNode.InnerText;
                                if (innerText != null)
                                {
                                    return innerText;
                                }
                            }
                        }
                    }
                }
                return null;
            }
            catch
            {

                return null;
            }
        }

        public static List<string> SendList(string url, string node)
        {
            try
            {
                if (!String.IsNullOrEmpty(url) && !String.IsNullOrEmpty(node))
                {
                    WebClient webClient = new WebClient();
                    webClient.Encoding = System.Text.Encoding.UTF8;
                    string html = webClient.DownloadString(url);
                    if (!String.IsNullOrEmpty(html))
                    {
                        HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument.LoadHtml(html);
                        if (htmlDocument != null)
                        {
                            HtmlAgilityPack.HtmlNodeCollection htmlNodes = htmlDocument.DocumentNode.SelectNodes(node);
                            if (htmlNodes != null && htmlNodes.Count > 0)
                            {
                                List<string> listNode = new List<string>();
                                foreach (var item in htmlNodes)
                                {
                                    string innerText = item.InnerText;
                                    if (!String.IsNullOrEmpty(innerText))
                                    {
                                        listNode.Add(innerText);
                                    }
                                }
                                return listNode;
                            }
                        }
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}