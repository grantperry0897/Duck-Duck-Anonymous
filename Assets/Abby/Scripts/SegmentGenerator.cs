using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segmentArray;
        [SerializeField] int xPos;
        [SerializeField] int spawnTime;
        //[SerializeField] bool creatingSegment;
        [SerializeField] int segmentNumber;
        [SerializeField] private float segmentLifetime;
        [SerializeField] Transform player;
        private float spawnIndex = 20;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(7);
    }
    void Update()
    {
        /*if(creatingSegment == false)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGenerate(player));
        }
        */
         if (player.position.x < spawnIndex)
        {
            SegmentGenerate();
            spawnIndex -= 75;
        }


    }

    void SegmentGenerate()
    {
        segmentNumber = Random.Range(0,5);
        GameObject mapSegment = Instantiate(segmentArray[segmentNumber], new Vector3(xPos, 0,0), Quaternion.identity);
        xPos += -75;
    
        StartCoroutine(DestroySegment(mapSegment));
        
    }

    IEnumerator DestroySegment(GameObject mapSegment)
    {
        yield return new WaitForSeconds(20);
        Destroy(mapSegment);
    }
}
