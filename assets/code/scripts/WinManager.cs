using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WinManager : MonoBehaviour
{
    //creates a global referance to this WinManager so other scripts can call WinManager.Instance.LevelWon();
    public static WinManager Instance;
    public static event Action OnLevelWon;

    void Awake()
    {
        if (Instance == null)//prevents duplicates
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }   
            
        else
            Destroy(gameObject);
    }

    public void LevelWon()      //add to this every time you want the win process to do smth new, like freeze the game, remove all enemies, play a sound, etc.
    {
        Debug.Log("[WinManager] LevelWon() called");
        OnLevelWon?.Invoke();
    }

    //bug testing
    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            LevelWon();
        }
    }
}


//structure rn is trigger happens -> LevelWon -> OnLevelWon fires
//this is beneficial as now the level won event can be added to, as opposed to the win condition directly triggering the OnLevelWon event.