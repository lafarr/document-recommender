class Program 
{
    static async System.Threading.Tasks.Task Main(string[] args) 
    {
        string randomUrl = "https://en.wikipedia.org/wiki/Special:Random";
        Webpage[] webpages = new Webpage[101];
        for (int i = 0; i < 10; i++) 
        {
            webpages[i] = await WebpageFactory.BuildWebpageAsync(randomUrl);
        }
        webpages[99] = await WebpageFactory.BuildWebpageAsync("https://en.wikipedia.org/wiki/Software_engineering");
        string? userUrl = System.Console.ReadLine();
        if (userUrl is null)
            return;
        webpages[100] = await WebpageFactory.BuildWebpageAsync(userUrl);
        double[][] matrix = TfidfVectorizer.Vectorize(webpages);
        double[] tfidfVector = matrix[100];
        double[][] trueMatrix = new double[100][]; 
        for (int i = 0; i < 100; ++i)
        {
            trueMatrix[i] = matrix[i];
        }

        System.Console.WriteLine($"We recommend {Recommender.RecommendWebpage(webpages, tfidfVector, trueMatrix)}");
    }
}
