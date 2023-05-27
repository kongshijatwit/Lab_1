using UnityEngine;

public class GameController: MonoBehaviour
{
    public static int playerScore = 0;
    public static int npcScore = 0;

    void OnGUI()
    {
        GUIStyle scoreStyle = new GUIStyle();
        scoreStyle.fontSize = 24;
        scoreStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 200, 50), "Player Score: " + playerScore, scoreStyle);
        GUI.Label(new Rect(10, 50, 200, 50), "NPC Score: " + npcScore, scoreStyle);
    }
}
