public class WordData 
{
    private static WordData instance;
    public static WordData Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new WordData();
            }
            return instance;
        }
    }

    public int LetterNumber { get; private set; }

    private string word;

    public void SetWord(string word)
    {
        this.word = word;
    }

    public string GetWord()
    {
        return word;
    }

    public void SetLetterNumber(int letterNumber)
    {
        this.LetterNumber = letterNumber;
    }

}
