using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMaker : MonoBehaviour
{

    public Transform lastBlock;
    public Transform character;
    public GameObject blockPrefab;
    float offset = 0.70711f;
    Vector3 lastPos;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = lastBlock.position;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        InvokeRepeating("CreateWall", 0, Time.deltaTime);
    }



    void CreateWall()
    {
        float diff = lastPos.z - character.position.z;
        if (diff > cam.orthographicSize*2 +3) return;

        int chance = Random.Range(1, 11);
        GameObject newBlock = Instantiate(blockPrefab, transform);

     
        if (chance %3 == 0)
            newBlock.transform.GetChild(0).gameObject.SetActive(true);

        if (chance < 5) 
        {
            newBlock.transform.position = new Vector3(lastPos.x + offset, 0, lastPos.z + offset);
        }
        else
            newBlock.transform.position = new Vector3(lastPos.x - offset, 0, lastPos.z + offset);

        lastPos = newBlock.transform.position;
    }
}
