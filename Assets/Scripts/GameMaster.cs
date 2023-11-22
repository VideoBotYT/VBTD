using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private bool gameEnd = false;

    // Update is called once per frame
    void Update()
    {
        if (gameEnd)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnd = true;
        Debug.LogWarning("Game Over");
    }
}
