using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenInvisible : MonoBehaviour
{
    Transform character;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        character = GameObject.Find("Character").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float diff =  character.position.z - transform.position.z;
        if (diff > cam.orthographicSize)
            Destroy(gameObject);
    }
}
