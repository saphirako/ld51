using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    public void Start(){
        animator = GetComponent<Animator>();
    }

    public void Run(){
        animator.Play("PlayerRun");
    }

    public void Jump(){
        animator.Play("PlayerJump");
    }

    public void Slide(){
        animator.Play("Playerslide");
    }

}
