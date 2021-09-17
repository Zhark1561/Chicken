using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public List<int> playerKills;
    public List<GameObject> players;

    void Update()
    {
        if (playerKills.Count != players.Count)
        {
            foreach (GameObject player in players)
            {
                playerKills.Add(player.GetComponent<Entity>().kills);
            }
        }
        if (playerKills.Count == players.Count && players.Count != 0)
        {
            for (int i = 0; i < playerKills.Count; i++)
            {
                if (players[i] != null)
                {
                    playerKills[i] = players[i].GetComponent<Entity>().kills;
                }
            }
        }
    }

    public void GetPlayers(List<GameObject> players)
    {
        this.players = players;
    }
}
