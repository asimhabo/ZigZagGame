using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 differenceVector;
    public Transform character;
    // Start is called before the first frame update
    void Start()
    {
        differenceVector = transform.position - character.position;
    }


    private void LateUpdate()
    {
        transform.position = character.position + differenceVector;
    }
}
