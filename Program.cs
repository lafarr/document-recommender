class Program 
{
    static async System.Threading.Tasks.Task Main(string[] args) 
    {
        string randomUrl = "https://en.wikipedia.org/wiki/Special:Random";
        Webpage[] webpages = new Webpage[101];
        for (int i = 0; i < 100; i++) 
        {
            webpages[i] = await Webpage.BuildWebpageAsync(randomUrl);
        }
        webpages[99] = await Webpage.BuildWebpageAsync("https://en.wikipedia.org/wiki/Software_engineering");
        string? userUrl = System.Console.ReadLine();
        if (userUrl is null)
            return;
        webpages[100] = await Webpage.BuildWebpageAsync(userUrl);
        var matrix = TfidfVectorizer.Vectorize(webpages);
        var tfidfVector = matrix[100];
        var trueMatrix = new double[100][]; 
        for (int i = 0; i < 100; ++i)
        {
            trueMatrix[i] = matrix[i];
        }

        System.Console.WriteLine($"We recommend {Recommender.RecommendWebpage(webpages, tfidfVector, trueMatrix)}");
    }
}
