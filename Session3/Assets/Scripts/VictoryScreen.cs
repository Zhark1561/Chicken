using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public void Win(string winnersName, int score)
    {
        text.text = $"Winner: {winnersName} \n Kills: {score}";
    }

}
