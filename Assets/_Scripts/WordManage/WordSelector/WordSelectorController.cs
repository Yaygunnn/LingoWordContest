using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        EventManager.Instance.EventSelectLetterNumber += SelectWord;
    }

    public void SelectWord(int letternumber)
    {
        if (!model.FilePaths.ContainsKey(letternumber))
        {
            Debug.Log("NoFilePathInDictionary");
            return;
        }
    }

    private void OnDisable()
    {
        EventManager.Instance.EventSelectLetterNumber -= SelectWord;
    }
}
