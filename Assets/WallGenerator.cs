using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public int brickNumber;
    public int brickLineNumber;
    public GameObject brickPrefab;
    public int currentBrickLine;
    public float lastBrickPosition;
    public float brickOffset;
    public float brickLineHeight;
    public List<GameObject> bricks = new List<GameObject>();
    void Start()
    {
        StartCoroutine(WaitFrame());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitFrame()
    {
        currentBrickLine = 0;

        for (int j = 0; j < brickLineNumber; j++)
        {
            if (j % 2 == 0)
            {
                lastBrickPosition = transform.position.z;
            }
            else
            {
                lastBrickPosition = transform.position.z + brickOffset / 2;
            }

            for (int i = 0; i < brickNumber; i++)
            {
                GameObject clon;
                clon = Instantiate(brickPrefab);
                clon.transform.position = new Vector3(brickPrefab.transform.position.x, brickPrefab.transform.position.y + j * brickLineHeight, lastBrickPosition += brickOffset);
                bricks.Add(clon);
                yield return null;                
            }            
        }
        //StartCoroutine(WaitToMakeKinematicFalse());
    }

    IEnumerator WaitToMakeKinematicFalse()
    {
        yield return new WaitForSeconds(1);
        foreach (GameObject clon in bricks)
        {           
            Rigidbody rb = clon.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.freezeRotation = false;
        }
    }

}
