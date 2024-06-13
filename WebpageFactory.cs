static class WebpageFactory
{
    public static async System.Threading.Tasks.Task<Webpage> BuildWebpageAsync(string url)
    {
        System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        string html = await client.GetStringAsync(url);
        HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
        htmlDocument.LoadHtml(html);
        System.Console.WriteLine($"Processing {htmlDocument.DocumentNode.SelectSingleNode("//title").InnerText}");
        return new Webpage(url, htmlDocument);
    }
}
