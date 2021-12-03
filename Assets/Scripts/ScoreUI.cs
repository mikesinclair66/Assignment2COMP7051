using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text text;
    public GameMaster gm;
    void Update()
    {
        text.text = "Score: " + gm.score;
    }
}
