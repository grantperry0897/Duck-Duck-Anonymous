using UnityEngine;

public class GooseLook : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        transform.LookAt(player.position);
    }
}