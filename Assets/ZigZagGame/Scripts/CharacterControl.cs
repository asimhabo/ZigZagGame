using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterControl : MonoBehaviour
{
    public float moveSpeed;
    bool lookingRight = true;
    public Animator animController;
    int score, highScore;
    public Text scoreTxt, hScoreTxt;
    public bool falling;
    float elapsedTime;
    public AudioClip clip;
    AudioSource audioSource;
    public Text info; 
    public GameObject particlePrafab;
    public Transform rayOrigin;


    public void Start()
    {
        Load();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Load()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        hScoreTxt.text = highScore.ToString();
    }

    // Update is called once per frame
    public void Run()
    {
        // TouchToTurn();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Turn();
        }

        Move();


        Debug.DrawRay(rayOrigin.position, Vector3.down * 1000, Color.red);
        if (!Physics.Raycast(rayOrigin.position, Vector3.down))
        {
            SetFallAnimation();
            falling = true;
        }

    }

    private void Move()
    {
        // transform.position += transform.forward * moveSpeed * Time.deltaTime;

        if ((elapsedTime +=Time.deltaTime) > 5)
        {
            elapsedTime = 0;
            moveSpeed += 0.3f;
            animController.speed += moveSpeed * 0.1f;
        }

         transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        SetRunAnimation();
    }

    private void Turn(float dir)
    {
            transform.Rotate(Vector3.up, dir);
    }


    private void SetRunAnimation()
    {

        animController.SetTrigger("run");
    }

    private void SetFallAnimation()
    {
        animController.SetTrigger("falling");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "crystal")
        {
            MakeScore();
            audioSource.PlayOneShot(clip);
            CreateParticle();
            Destroy(other.gameObject);
        }
    }

    private void MakeScore()
    {
        score++;
        scoreTxt.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            hScoreTxt.text = highScore.ToString();
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("highScore", highScore);
    }

    private void CreateParticle()
    {
        GameObject paticle = Instantiate(particlePrafab, transform);
        Destroy(paticle, 1);
    }


    private void TouchToTurn()
    {
        //float firstTouchX=0;
        //float lastTouchX=0;
        if (Input.touches.Length>0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    Turn();
                    //firstTouchX = Input.GetTouch(0).position.x;
                    break;
                //case TouchPhase.Moved:
                //    lastTouchX = Input.GetTouch(0).position.x;
                //    break;
                //case TouchPhase.Ended:
                //    if (lastTouchX - firstTouchX > 40)
                //    {
                //        if (transform.eulerAngles.y < 0)
                //            Turn(90);
                //    }

                //    else if (lastTouchX - firstTouchX < -40)
                //        if (transform.eulerAngles.y > 0)
                //            Turn(-90);
                //    break;
            }
        }
    }

    private void Turn()
    {
        if (lookingRight)
        {
            transform.Rotate(Vector3.up, -90);
        }
        else
            transform.Rotate(Vector3.up, 90);
        lookingRight = !lookingRight;
    }
}
