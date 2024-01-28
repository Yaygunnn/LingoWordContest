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
        SetLetterNumber();
    }

    public string GetWord()
    {
        return word;
    }

    private void SetLetterNumber()
    {
        this.LetterNumber = word.Length;
    }

}
