class Calculations
{
    /// <summary>
    /// Calculates the tf-idf of a given word
    /// </summary>
    /// <param name="word">The word to calculate tf-idf for</param>
    /// <param name="wordCounts">An instance of <c>Counter</c> containing the word counts of the current document</param>
    /// <param name="corpusWordcounts">An instance of <c>Counter[]</c> containing the word counts of all documents in the corpus</param>
    /// <returns> 
    /// A tf-idf calculation, equal to (count of word in document / number of words in document) * log(number of documents / number of documents containing word)
    /// </returns>
    public static double CalculateTfidf(string word, Counter wordCounts, Counter[] corpusWordCounts)
    {
        double totalWordCount = 0;
        foreach (Node<string> n in wordCounts.Table)
        {
            var node = n;
            while (node is not null)
            {
                totalWordCount += n.Count;
                node = node.Next;
            }
        }
        double tf = wordCounts.GetCount(word) / totalWordCount;

        double countInCorpus = 0;
        foreach (Counter documentCounter in corpusWordCounts)
        {
            countInCorpus += documentCounter.GetCount(word);
        }
        double idf = System.Math.Log(corpusWordCounts.Length / countInCorpus);

        return tf * idf;
    }

    public static double CosineSimilarity(double[] vec, double[] otherVec)
    {
        System.Collections.Generic.List<double> firstVec = new System.Collections.Generic.List<double>(vec);
        System.Collections.Generic.List<double> secondVec = new System.Collections.Generic.List<double>(otherVec);

        double dotProduct = 0;
        for (int i = 0; i < vec.Length; ++i)
        {
            dotProduct += firstVec[i] * secondVec[i];
        }

        double firstNorm = 0;
        foreach (double d in vec)
        {
            firstNorm += System.Math.Pow(d, 2);
        }
        firstNorm = System.Math.Sqrt(firstNorm);

        double secondNorm = 0;
        foreach (double d in otherVec)
        {
            secondNorm += System.Math.Pow(d, 2);
        }
        secondNorm = System.Math.Sqrt(secondNorm);

        return dotProduct / (firstNorm * secondNorm);
    }
}
