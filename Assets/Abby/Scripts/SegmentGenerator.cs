using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segmentArray;
        [SerializeField] int xPos;
        [SerializeField] int spawnTime;
        [SerializeField] bool creatingSegment;
        [SerializeField] int segmentNumber;
        [SerializeField] private float segmentLifetime;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(7);
    }
    void Update()
    {
        if(creatingSegment == false)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGenerate());
        }
    
        
    }

    IEnumerator SegmentGenerate()
    {
        segmentNumber = Random.Range(0,5);
        GameObject mapSegment = Instantiate(segmentArray[segmentNumber], new Vector3(xPos, 0,0), Quaternion.identity);
        xPos += -75;
        yield return new WaitForSeconds(5);
        creatingSegment = false;
        StartCoroutine(DestroySegment(mapSegment));
    }

    private IEnumerator DestroySegment(GameObject mapSegment)
    {
        yield return new WaitForSeconds(20);
        Destroy(mapSegment);
    }
}
