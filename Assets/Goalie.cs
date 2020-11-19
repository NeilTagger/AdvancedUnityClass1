using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Goalie : MonoBehaviour
{
    public bool IsPlayer1Goal;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (IsPlayer1Goal)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Player1Scored();
                audioSource.PlayOneShot(audioSource.clip, 0.5f);
                audioSource.panStereo = -1;
            }

            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Player2Scored();
                audioSource.panStereo = 1;
                audioSource.PlayOneShot(audioSource.clip, 0.5f);

            }
        }
    }
}
