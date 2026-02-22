#pragma warning disable CS0649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text textObject;
    // Start is called before the first frame update
    void Start()
    {
        Player score = new Player();
        int i = (int) Player.playerScore;
        textObject.SetText(i.ToString());
    }

}
