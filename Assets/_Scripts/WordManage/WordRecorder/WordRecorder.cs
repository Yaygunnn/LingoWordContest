using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordRecorder 
{
    private static WordRecorder instance;

    public static WordRecorder Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WordRecorder();
            }
            return instance;
        }
    }

    private WordRecorderModel model = new WordRecorderModel();

    public void RecordWordAndCellState(string word , E_CellState[] cellStates)
    {
        S_CharRecord[] record = new S_CharRecord[word.Length];

        for(int i = 0; i < word.Length; i++)
        {
            record[i].letter = word[i];
            record[i].cellState = cellStates[i];
        }

        model.record.Add(record);
        Debug.Log(model.record.Count);
    }
    
}
