using UnityEngine;

public class ShowGoMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject GoMainMenuButton;

    private float ShowMenuTime = 3.5f;
    void Start()
    {
        EventManager.Instance.EventVictory += InvokeShowMenu;
        EventManager.Instance.EventDefeat += InvokeShowMenu;
    }

    private void OnDestroy()
    {
        EventManager.Instance.EventVictory -= InvokeShowMenu;
        EventManager.Instance.EventDefeat -= InvokeShowMenu;
    }

    private void InvokeShowMenu()
    {
        Invoke("ShowButton", ShowMenuTime);
    }
    private void ShowButton()
    {
        GoMainMenuButton.SetActive(true);
    }
}
