using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordSelectorController : MonoBehaviour
{
    public static WordSelectorController Instance { get; private set; }
    [SerializeField] private WordSelectorModel model;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventManager.Instance.EventSelectLetterNumber += TyrToSelectWord;
    }

    private void TyrToSelectWord(int letternumber)
    {
        if(ControlFilePath(letternumber))
        {
            string[] lines = File.ReadAllLines(model.FilePaths[letternumber]);
            
            if(StringHasWords(lines))
            {
                string word = SelectRandomWord(lines);
                SendWordData( word);
                FireEventWordSelected();
            }
        }
    }

    private void SendWordData( string word)
    {
        WordData.Instance.SetWord(word);
    } 
    private string SelectRandomWord(string[] words)
    {
        return words[Random.Range(0, words.Length)];
    }
    private void OnDisable()
    {
        EventManager.Instance.EventSelectLetterNumber -= TyrToSelectWord;
    }

    private bool StringHasWords(string[] lines)
    {
        if(lines.Length>0)
        {
            return true;
        }
        Debug.Log("No words in filepath");
        return false;
    }
    private bool ControlFilePath(int letternumber)
    {
        if (!model.FilePaths.ContainsKey(letternumber))
        {
            Debug.Log("No letter number in dictionary");
            return false;
        }

        if (File.Exists(model.FilePaths[letternumber])) 
        {
            return true;
        }
        Debug.Log("No File Path In Dictionary");
        return false;
    }

    private void FireEventWordSelected()
    {
        EventManager.Instance.WordSelected();
    }
}
