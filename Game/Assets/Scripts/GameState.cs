using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    //Global Properties
    private int _money;

    private static GameState instance;

    public static GameState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameState").AddComponent<GameState>();
            }

            return instance;
        }
    }

    public void OnApplicationQuit()
    {
        instance = null;
    }

    public void StartState()
    {
        print("Creating a new game state");

        Application.LoadLevel("test");
    }

    public int Money
    {
        get { return _money; }
        set { _money = value; }
    }

}
