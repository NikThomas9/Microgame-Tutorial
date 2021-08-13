using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameManager : MonoBehaviour
{    
    [SerializeField] private GameObject strawberry;
    private float difficultyTimer;

    public int collected;
    public int numToSpawn;
    public bool gameOver;

    public Vector2 Min;
    public Vector2 Max;
    
    // Start is called before the first frame update
    void Start()
    {
        numToSpawn = 1 + GameController.Instance.gameDifficulty;

        gameOver = false;
        
        difficultyTimer = 12 - (2 * GameController.Instance.gameDifficulty);

        for (int i = 0; i < numToSpawn; i++)
        {
            float x = UnityEngine.Random.Range(Min.x, Max.x);
            float y = UnityEngine.Random.Range(Min.y, Max.y);
            Vector2 randomPos = new Vector2(x, y);
            Instantiate(strawberry, randomPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (collected >= numToSpawn)
        {
            collected = 0;
            GameController.Instance.WinGame();
        }

        if (GameController.Instance.gameTime >= difficultyTimer && gameOver == false)
        {
            gameOver = true;
            GameController.Instance.LoseGame();
        }
    }
}
