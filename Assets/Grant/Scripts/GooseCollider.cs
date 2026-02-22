using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GooseCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        // Goose chases player 
        if (collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}