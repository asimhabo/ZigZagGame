using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    CharacterControl character;
    // Start is called before the first frame update
    void Start()
    {
        character = FindObjectOfType<CharacterControl>();
        StartGame();
    }

    void StartGame()
    {
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
            return;
        character.Run();
        if (character.falling)
        {
            Invoke("RestartGame", 1);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
