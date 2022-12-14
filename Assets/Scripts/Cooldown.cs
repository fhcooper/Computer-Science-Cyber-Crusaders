using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : StateMachineBehaviour
{
    Rigidbody2D rb;
    Transform player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        
        Vector2 bossPosition = rb.transform.position;
        float playerProximity = player.position.x - rb.position.x;


        if (playerProximity >= -6.0f && playerProximity <= 6.0f)
        {
            //possibly instant attack initiation
            animator.SetTrigger("InRange");
        }
        else if (playerProximity < -6.0f || playerProximity > 6.0f)
        {
            animator.SetTrigger("OutRange");
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("InRange");
        animator.ResetTrigger("OutRange");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
