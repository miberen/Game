using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    private delegate void MainMenuDelegate();
    private MainMenuDelegate menuDelegate;

    private float screenHeight;
    private float screenWidth;
    private float buttonHeight;
    private float buttonWidth;

    //New Game
    private float levelSize = 2.0f;

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
        GUI.Label(new Rect((screenWidth / 2) - (buttonWidth / 2), (screenHeight / 2) - (buttonHeight / 2) - 100, buttonWidth, buttonHeight), "New Game");


        GUI.Label(new Rect((screenWidth / 2) - (buttonWidth / 2) - (buttonWidth - 20), (screenHeight / 2) - (buttonHeight / 2) - 50, buttonWidth, buttonHeight), "Map Size");
        levelSize = GUI.HorizontalSlider(new Rect((screenWidth / 2) - (buttonWidth / 2), (screenHeight / 2) - (buttonHeight / 2) - 40, buttonWidth, buttonHeight), levelSize, 1.0f, 5.0f);
        levelSize = (int)levelSize;

        string levelSizeString;

        switch ((int)levelSize)
        {
            case 1:
                levelSizeString = "Tiny";
                break;
            case 2:
                levelSizeString = "Small";
                break;
            case 3:
                levelSizeString = "Medium";
                break;
            case 4:
                levelSizeString = "Large";
                break;
            case 5:
                levelSizeString = "Huge";
                break;
            default:
                levelSizeString = "Small";
                break;
        }

        GUI.Label(new Rect((screenWidth / 2) - (buttonWidth / 2) + (buttonWidth + 20), (screenHeight / 2) - (buttonHeight / 2) - 50, buttonWidth, buttonHeight), levelSizeString);


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
