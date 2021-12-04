using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Note: most of the logic for the console was taken from: https://youtu.be/VzOEM-4A2OM
public class ConsoleController : MonoBehaviour
{
    bool showConsole;

    string input;

    public static ConsoleCommand CHANGE_BACKGROUND;
    public static ConsoleCommand RESET_SCORE;

    public List<object> commandList;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            showConsole = !showConsole;
        }
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            Debug.Log("Enter pressed");
            if (showConsole) 
            {
                HandleInput();
                input = "";
            }
        }
    }

    private void Awake() 
    {
        CHANGE_BACKGROUND = new ConsoleCommand("change_background", "Change the background colour of the game", "change_background", () => {
            GameObject.Find("Background").GetComponent<Renderer>().material.color = Color.cyan;
        });
        RESET_SCORE = new ConsoleCommand("reset_score", "Reset the scoreboard", "reset_score", () => {
            Score score = GetComponent(typeof(Score)) as Score;
            score.leftScore = 0;
            score.rightScore = 0;
        });

        commandList = new List<object>
        {
            CHANGE_BACKGROUND,
            RESET_SCORE
        };
    }

    private void OnGUI() 
    {
        if (!showConsole) {return;}

        float y = 0f;
        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);

    }

    private void HandleInput()
    {
        for (int i = 0; i < commandList.Count; i++)
        {
            ConsoleCommandBase commandBase = commandList[i] as ConsoleCommandBase;
            if (input.Contains(commandBase.commandID))
            {
                if(commandList[i] as ConsoleCommand != null)
                {
                    (commandList[i] as ConsoleCommand).Invoke();
                }
            }
        }
    }
}
