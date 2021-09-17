using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChickenList : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI chickenCount;
    int chickenCountInt = 0;


    void Update()
    {
        if (gameManager.playerPrefabs == null)
        {
            chickenCount.text = "Chickens: 0";
        }
        else
        {
            chickenCount.text = $"Chickens: {gameManager.playerPrefabs.Count}";
        }
        
    }

    public void AddedChicken()
    {
        var chickenUI = new GameObject("Text");
        chickenUI.transform.SetParent(this.gameObject.transform);
        chickenUI.transform.localEulerAngles =  Vector3.zero;
        chickenUI.transform.position = new Vector3(-60f, 40f, 55f - (chickenCountInt*10));
        chickenUI.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        var chickenText = chickenUI.AddComponent<TextMeshProUGUI>();
        chickenText.color = Color.black;
        chickenText.text = gameManager.playerNames[chickenCountInt];
        chickenCountInt++;
    }

}
