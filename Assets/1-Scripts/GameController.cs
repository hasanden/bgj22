using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public enum GameStates
    {
        BeforeFirstPuzzle,
        FirstPuzzleStart,
        BeforeSecondPuzzle,
        SecondPuzzleStart
    }

    public UnityEvent gameStateChanged;

    public static GameController Instance;

    private static GameStates currentGameState;
    public GameStates GetCurrentGameState()
    {
        return currentGameState;
    }

    private void Awake()
    {
        Instance = this;

        if (gameStateChanged == null)
            gameStateChanged = new UnityEvent();

        currentGameState = GameStates.BeforeFirstPuzzle;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
