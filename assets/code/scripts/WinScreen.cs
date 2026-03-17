using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject winPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        WinManager.OnLevelWon += ShowWinScreen;
    }

    void OnDisable()
    {
        WinManager.OnLevelWon -= ShowWinScreen;
    }
    void ShowWinScreen()
    {
        winPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
