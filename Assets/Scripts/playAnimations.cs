using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimations : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            myAnimationController.SetBool("playPluma", true);
        }
    }

        private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            myAnimationController.SetBool("playPluma", false);
        }
    }
}
