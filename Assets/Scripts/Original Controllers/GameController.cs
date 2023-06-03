using UnityEngine;

public class GameController: MonoBehaviour
{
    public static int playerScore = 0;
    public static int npcScore = 0;

    private void Start() 
    {
        Character char1 = new Character("High", "Close");
        Character char2 = new Character("Low", "Close");
        Character char3 = new Character("Medium", "Close");

        Character char4 = new Character("High", "Medium");
        Character char5 = new Character("Low", "Medium");
        Character char6 = new Character("Medium", "Medium");

        Character char7 = new Character("High", "Far");
        Character char8 = new Character("Low", "Far");
        Character char9 = new Character("Medium", "Far");


        char1.MakeDecision();
        char2.MakeDecision();
        char3.MakeDecision();
        Debug.Log("-----");
        char4.MakeDecision();
        char5.MakeDecision();
        char6.MakeDecision();
        Debug.Log("-----");
        char7.MakeDecision();
        char8.MakeDecision();
        char9.MakeDecision();
    }

    void OnGUI()
    {
        GUIStyle scoreStyle = new GUIStyle();
        scoreStyle.fontSize = 24;
        scoreStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 200, 50), "Player Score: " + playerScore, scoreStyle);
        GUI.Label(new Rect(10, 50, 200, 50), "NPC Score: " + npcScore, scoreStyle);
    }

    public void OnCubeGrabbed()
    {
        npcScore--;
    }
}
