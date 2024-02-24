using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class CreateEndGameGrid : MonoBehaviour
{
    public static CreateEndGameGrid Instance;

    [SerializeField] private LetterCellController letterCellController;

    [SerializeField] private float Spacing;

    private bool IsVictory;

    private void Awake()
    {
        Instance = this;

        ShowCellPrefab(false);
    }

    private void Start()
    {
        EventManager.Instance.EventVictory += CreateEndGridVictory;
        EventManager.Instance.EventDefeat += CreateEndGridDefeat;
    }

    private void OnDestroy()
    {
        EventManager.Instance.EventVictory -= CreateEndGridVictory;
        EventManager.Instance.EventDefeat -= CreateEndGridDefeat;
    }

    private void CreateEndGridVictory()
    {
        IsVictory = true;
        CreateEndGrid();
    }

    private void CreateEndGridDefeat()
    {
        IsVictory= false;
        CreateEndGrid();
    }
    private void CreateEndGrid()
    {
        ShowCellPrefab(true);

        GridData gridData = GetGridData();
        
        GridCreation.CreateGrid(gridData);
    }

    private GridData GetGridData()
    {
        GridData gridData = new GridData();

        gridData.CellPrefab = letterCellController;

        gridData.HorizontalLength = WordData.Instance.LetterNumber;

        gridData.VerticalLength = CalculateLength();

        gridData.Spacing = Spacing;

        gridData.SendGridData = Empty;

        return gridData;
    }

    private void ShowCellPrefab(bool show)
    {
        letterCellController.gameObject.SetActive(show);
    }

    private int CalculateLength()
    {
        int length = WordRecorder.Instance.GetRecordLength();
        if(!IsVictory)
        {
            length++;
        }
        return length;
    }

    private void Empty(LetterCellController i, int y, int z)
    {
    }
}
