using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public bool gameIsRunning;
    [NonSerialized] public List<GameObject> playerPrefabs;
    [SerializeField] private List<GameObject> players;
    public List<string> playerNames;

    public ScoreHolder scoreHolder;
    [SerializeField] VictoryScreen victoryScreen;

    void Awake()
    {
        playerPrefabs = new List<GameObject>();
    }

    void Update()
    {
        if (gameIsRunning)
        {
            scoreHolder.GetPlayers(players);
            CheckAlivePlayers();
        }
    }

    public void AddPlayers()
    {
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(player);
        }
        SetPlayerName();
    }

    void SetPlayerName()
    {
        for (int i = 0; i < players.Count; i++)
        {
            var player = players[i];
            player.name = playerNames[i];
        }
    }
    void CheckAlivePlayers()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            gameIsRunning = false;
            var winner = GameObject.FindGameObjectWithTag("Player");
            victoryScreen.Win(winner.name, winner.GetComponent<Entity>().kills);
        }
    }


    /*void Awake()
    {
        if (GameObject.FindObjectOfType<Entity>())
        {
            gameIsRunning = true;
            AddPlayers();
        }
        else 
        {
            gameIsRunning = false;
        }
    }
    void Start()
    {
        if (gameIsRunning)
        {
            AddPlayers();
            scoreHolder.GetPlayers(players);
        }
    }
    */

}
