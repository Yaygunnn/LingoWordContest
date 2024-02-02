using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordCheckController : MonoBehaviour
{
    public static WordCheckController Instance;

    private WordCheckModel model=new WordCheckModel();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventManager.Instance.EventWordInputGiven += CheckWord;
        EventManager.Instance.SetFuncRecieveWordAnswer(GetWordAnswer);
    }

    private void OnDisable()
    {
        EventManager.Instance.EventWordInputGiven -= CheckWord;
        EventManager.Instance.UnSetFuncRecieveWordAnswer(GetWordAnswer);
    }

    private E_WordAnswer GetWordAnswer()
    {
        return model.wordAnswer;
    }
    private void CheckWord(string word)
    {
        model.wordAnswer = CheckAnswer(word);
        model.e_CellStates = SetCellStates(word);
        EventManager.Instance.WordRecieved(word);
    }
    private E_WordAnswer CheckAnswer(string tryWord)
    {
        if (!IsValidTry(tryWord))
        {
            return E_WordAnswer.Fail;
        }

        if (tryWord == WordData.Instance.GetWord())
        {
            return E_WordAnswer.Correct;
        }

        model.PreviousWordTrys.Add(tryWord);
        return E_WordAnswer.TryAgain;

    }

    private bool IsValidTry(string tryWord)
    {
        if(!WordData.Instance.WordList.Contains(tryWord))
        {
            return false;
        }
        if(model.PreviousWordTrys.Contains(tryWord))
        {
            return false;
        }
        return true;
    }

    private E_CellState[] SetCellStates(string tryWord)
    {   
        E_CellState[] LetterCellStates = new E_CellState[model.e_CellStates.Length];

        if(model.wordAnswer==E_WordAnswer.Fail)
        {
            for(int i = 0; i<model.e_CellStates.Length; i++)
            {
                LetterCellStates[i] = E_CellState.False;
            }
            return LetterCellStates;
        }
        List<char> charList = WordData.Instance.GetWord().ToList();
        List<int> UnknownLetters = Enumerable.Range(0, tryWord.Length).ToList();
        List<int> RemoveList = new List<int>();

        foreach (int letter in UnknownLetters)
        {
            if (tryWord[letter] == WordData.Instance.GetWord()[letter])
            {
                LetterCellStates[letter] = E_CellState.True;
                charList.Remove(tryWord[letter]);
                RemoveList.Add(letter);
            }
        }

        UnknownLetters = UnknownLetters.Except(RemoveList).ToList();

        foreach (int letter in UnknownLetters)
        {
            if (charList.Contains(tryWord[letter]))
            {
                LetterCellStates[letter] = E_CellState.MissPlaced;
                charList.Remove(tryWord[letter]);
            }
            else
            {
                LetterCellStates[letter] = E_CellState.Standart;
            }

        }
        return LetterCellStates;
    }

    public E_CellState[] RecieveVisualInfo()
    {
        return model.e_CellStates;
    }


}
