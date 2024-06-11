static class TfidfVectorizer
{
    public static double[][] Vectorize(Webpage[] webpages)
    {
        Counter[] docs = new Counter[webpages.Length];
        for (int i = 0; i < webpages.Length; ++i)
        {
            docs[i] = webpages[i].WordCounts;
        }

        System.Collections.Generic.HashSet<string> uniqueWords = new System.Collections.Generic.HashSet<string>();
        foreach (Counter documentCounter in docs)
        {
            foreach (Node<string> wordNode in documentCounter.Table)
            {
                uniqueWords.Add(wordNode.Value);
            }
        }

        double[][] tfidfMatrix = new double[docs.Length][];
        for (int i = 0; i < docs.Length; ++i)
        {
            int j = 0;
            tfidfMatrix[i] = new double[uniqueWords.Count];
            foreach (string word in uniqueWords)
            {
                var x = Calculations.CalculateTfidf(word, docs[i], docs);
                tfidfMatrix[i][j] = x;
                ++j;
            }
        }
        return tfidfMatrix;
    }
}
