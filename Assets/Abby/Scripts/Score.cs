using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using System.Data;
using Unity.VisualScripting;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text textObject;
    // Start is called before the first frame update
    void Start()
    {
        Player score = new Player();
        int i = Player.playerScore;
        textObject.SetText(i.ToString());
    }

}
