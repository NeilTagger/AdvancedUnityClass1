using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = transform.position;
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.pitch = (Random.Range(0.8f, 1f));
        if(transform.position.x > 0)
        {
            audioSource.panStereo = (1 - (transform.position.x/10));
        }
        if (transform.position.x < 0)
        {
            audioSource.panStereo = ( (transform.position.x / 10));
        }

        audioSource.PlayOneShot(audioSource.clip, 0.3f);
    }
}
