using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject minimap;


    public void OnStart()
    {

        for (int i = 0; i < gameManager.playerPrefabs.Count; i++)
        {
            var player = Instantiate(gameManager.playerPrefabs[i]);
            player.GetComponent<Entity>().nameTMP.text = gameManager.playerNames[i];
        }
        gameManager.AddPlayers();
        gameManager.gameIsRunning = true;
        minimap.SetActive(false);
        menu.SetActive(false);
    }
}
