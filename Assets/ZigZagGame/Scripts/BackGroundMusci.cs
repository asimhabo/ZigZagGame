using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusci : MonoBehaviour
{
    private static BackGroundMusci backGroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        if (backGroundMusic == null)
        {
            backGroundMusic = this;
        }
        else if (backGroundMusic != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(backGroundMusic);
    }
    
}
