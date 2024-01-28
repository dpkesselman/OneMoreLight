using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public AudioSource tickles;
    public SpriteRenderer mySpriteRenderer;
    public Sprite temp;
    
    void Start()
    {
        tickles = GetComponent<AudioSource>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log("Enter");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log("Stay");
            tickles.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            temp = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = mySpriteRenderer.sprite;
            mySpriteRenderer.sprite = temp;
            Debug.Log("Exit");
        }   
    }
}
