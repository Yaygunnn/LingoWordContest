using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagerView : MonoBehaviour
{

    [SerializeField] private KeyManagerViewModel viewModel;
    private void OnEnable()
    {
        KeyManagerController.Instance.WritingChanged += ShowWriting;
    }

    private void OnDisable()
    {
        KeyManagerController.Instance.WritingChanged -= ShowWriting;
    }

    private void ShowWriting(string writing)
    {
        viewModel.textMeshProUGUI.text = writing;
        print(writing);
    }

    private void Update()
    {
        SetImageTransform();
    }
    private void SetImageTransform()
    {
        float width = Screen.width * viewModel.widthPercentage;
        float height = Screen.height * viewModel.heightPercentage;

        viewModel.rectTransform.sizeDelta = new Vector2(width, height);

        Vector2 pos = new Vector2(0, 0);

        pos.x = Screen.width / 2 + viewModel.LeftOffset * Screen.width;
        float keyboardTopY = viewModel.KeyboardModel.bottomOffset * Screen.height + viewModel.KeyboardModel.heightPercentage * Screen.height;
        pos.y = viewModel.bottomOffset * Screen.height + height / 2 + keyboardTopY;

        viewModel.rectTransform.position = pos;
    }
}
