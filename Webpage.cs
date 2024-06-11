class Webpage
{
    public string Url 
    {
        get; set;
    }

    public string Title
    {
        get; set;
    }

    public string? BodyText
    {
        get; set;
    }

    public Counter WordCounts
    {
        get; set;
    }

    private Webpage(string url, HtmlAgilityPack.HtmlDocument doc)
    {
        Title = doc.DocumentNode.SelectSingleNode("//title").InnerText;
        HtmlAgilityPack.HtmlNode body = doc.DocumentNode.SelectSingleNode("//body");
        Url = url;
        BodyText = body.InnerText.Trim();
        WordCounts = new Counter(BodyText);
    }

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
