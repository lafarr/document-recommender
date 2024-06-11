class Program 
{
    static async System.Threading.Tasks.Task Main(string[] args) 
    {
        string randomUrl = "https://en.wikipedia.org/wiki/Special:Random";
        Webpage[] webpages = new Webpage[11];
        for (int i = 0; i < 9; i++) 
        {
            webpages[i] = await Webpage.BuildWebpageAsync(randomUrl);
        }
        webpages[9] = await Webpage.BuildWebpageAsync("https://en.wikipedia.org/wiki/Software_engineering");
        string? userUrl = System.Console.ReadLine();
        if (userUrl is null)
            return;
        webpages[10] = await Webpage.BuildWebpageAsync(userUrl);
        var matrix = TfidfVectorizer.Vectorize(webpages);
        var tfidfVector = matrix[10];
        var trueMatrix = new double[10][]; 
        for (int i = 0; i < 10; ++i)
        {
            trueMatrix[i] = matrix[i];
        }

        System.Console.WriteLine($"We recommend {Recommender.RecommendWebpage(webpages, tfidfVector, trueMatrix)}");
    }
}
