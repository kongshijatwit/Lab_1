using UnityEngine;

public class Character
{
    public string health;  // Set this value to "High" or "Low"
    public string enemy_distance; // This can be "Close", or "Far"

    public Character(string health, string enemy_distance)
    {
        this.health = health;
        this.enemy_distance = enemy_distance;
    }

    public void MakeDecision()
    {
        // Implement the decision tree here. Use if...else statements.
        // Print the decision with Console.WriteLine()
        if (enemy_distance == "Close")
        {
            if (health == "Low")
            {
                Debug.Log("Retreat");
                return;
            }
        }
        else if (enemy_distance == "Far")
        {
            if (health == "Low" || health == "High")
            {
                Debug.Log("Attack");
                return;
            }
        }
        Debug.Log("Defend");
    }
}
