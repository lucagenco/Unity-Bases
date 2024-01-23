using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public int WoodCount;
    public int WoodMax;

    public int EnnemiKilled;
    public int EnnemiMaxKilled;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void CheckWin()
    {
        if (WoodCount >= WoodMax && EnnemiKilled >= EnnemiMaxKilled)
        {
            SceneManager.LoadScene("Scenes/Win");
        }
    }
}
