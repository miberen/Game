using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    private delegate void MainMenuDelegate();
    private MainMenuDelegate menuDelegate;

    private float screenHeight;
    private float screenWidth;
    private float buttonHeight;
    private float buttonWidth;

	// Use this for initialization
	void Start () {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        buttonWidth = 150.0f;
        buttonHeight = 30.0f;

        menuDelegate = TopMenu;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        menuDelegate();
    }

    private void TopMenu()
    {
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect((screenWidth / 2) - (buttonWidth / 2), (screenHeight / 2) - (buttonHeight / 2) - 80, buttonWidth, buttonHeight), "Menu");

        if (GUI.Button(new Rect((screenWidth / 2) - (buttonWidth / 2), (screenHeight / 2) - (buttonHeight / 2) - 40, buttonWidth, buttonHeight), "Start New Game"))
        {
            menuDelegate = NewGameMenu;
        }

        if (GUI.Button(new Rect((screenWidth / 2) - (buttonWidth / 2), (screenHeight / 2) - (buttonHeight / 2), buttonWidth, buttonHeight), "Options"))
        {
            //StartGame();
        }

        if (GUI.Button(new Rect((screenWidth / 2) - (buttonWidth / 2), (screenHeight / 2) - (buttonHeight / 2) + 40, buttonWidth, buttonHeight), "Quit Game"))
        {
            Application.Quit();
        }
    }

    private void NewGameMenu()
    {
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect((screenWidth / 2) - (buttonWidth / 2), (screenHeight / 2) - (buttonHeight / 2) - 40, buttonWidth, buttonHeight), "New Game");

        if (GUI.Button(new Rect((screenWidth / 2) - (buttonWidth / 2), (screenHeight / 2) - (buttonHeight / 2), buttonWidth, buttonHeight), "Start"))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        print("Starting game");

        DontDestroyOnLoad(GameState.Instance);
        GameState.Instance.StartState();
    }
}
