using UnityEngine.SceneManagement;
using UnityEngine;

public class Exit : MonoBehaviour
{
 
void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            SceneManager.LoadScene(0);
        }
    }
}
