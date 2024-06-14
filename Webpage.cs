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

    internal Webpage(string url, HtmlAgilityPack.HtmlDocument doc)
    {
        Title = doc.DocumentNode.SelectSingleNode("//title").InnerText;
        HtmlAgilityPack.HtmlNode body = doc.DocumentNode.SelectSingleNode("//body");
        Url = url;
        BodyText = body.InnerText.Trim();
        WordCounts = new Counter(BodyText);
    }
}
