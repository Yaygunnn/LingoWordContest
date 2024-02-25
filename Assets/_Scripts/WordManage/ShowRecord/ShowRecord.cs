using UnityEngine;
public static class ShowRecord 
{
    public static void ShowCellAccordingToRecord(LetterCellController cellController, int x, int y)
    {
        if (IsInRecord(y))
        {
            S_CharRecord data = WordRecorder.Instance.GetCellRecord(y, x);
            cellController.SetLetterCellFast(data.cellState, data.letter);
            return;
        }
        else
        {
            WriteCorrectWord(cellController, x);
        }
        
    }

    private static bool IsInRecord(int y)
    {
        if(y<WordRecorder.Instance.GetRecordLength())
        {
            return true;
        }
        return false;
    }

    private static void WriteCorrectWord(LetterCellController cellController ,int x)
    {
        cellController.SetLetterCellFast(E_CellState.Standart, WordData.Instance.GetWord()[x]);
    }
    
}
