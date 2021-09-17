using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddChicken : MonoBehaviour
{
    [SerializeField] private GameObject chickenPrefab;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ChickenList chickenList;
    [SerializeField] private TMP_InputField inputField;



    public void OnAddChicken()
    {
        gameManager.playerPrefabs.Add(chickenPrefab);
        if (inputField.text == "")
        {
            gameManager.playerNames.Add("Chicken");
        }
        else
        {
            gameManager.playerNames.Add(inputField.text);
        }
        
        chickenList.AddedChicken();
    }

}
