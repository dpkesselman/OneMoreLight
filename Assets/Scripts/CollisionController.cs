using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public AudioSource tickles;

    
    void Start()
    {
        tickles = GetComponent<AudioSource>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            tickles.Play();
        }
    }

}
