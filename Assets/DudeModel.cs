using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeModel : MonoBehaviour
{
    private GameObject rHand;
    private bool isAnimating = false;

    void Update()
    {
        if (Input.GetKeyDown("space")) isAnimating = !isAnimating;
        Animator anim = GetComponent<Animator>();
        if (isAnimating)
        {
            anim.enabled = true;
            anim.Play("Dude Walk");
        }
        else
        {
            anim.enabled = false;
            anim.StopPlayback();
        }
    }
}
