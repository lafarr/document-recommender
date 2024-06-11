static class Recommender
{
    public static string RecommendWebpage(Webpage[] webpages, double[] userTfidfVector, double[][] corpusTfidfMatrix)
    {
        int bestIndex = -1;
        double bestScore = -1; // -1 is the smallest number cosine similarity will return
        for (int i = 0; i < corpusTfidfMatrix.Length; ++i)
        {
            double similarity = Calculations.CosineSimilarity(userTfidfVector, corpusTfidfMatrix[i]);
            System.Console.WriteLine($"Webpage {webpages[i].Title} has similarity score of {similarity}");
            if (similarity >= bestScore)
            {
                bestScore = similarity;
                bestIndex = i;
            }
        }
        return webpages[bestIndex].Title;
    }
}
