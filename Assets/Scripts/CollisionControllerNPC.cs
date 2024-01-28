using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControllerNPC : MonoBehaviour
{
    public GameObject NPCsad;
    public GameObject NPChappy;
    //public SpriteRenderer mySpriteRenderer;
    //public Sprite changeSpriteTo;

    void Start()
    {
        NPCsad.gameObject.SetActive(true);
        NPChappy.gameObject.SetActive(false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           NPCsad.SetActive(false);
           NPChappy.SetActive(true);
        }   
    }
}
