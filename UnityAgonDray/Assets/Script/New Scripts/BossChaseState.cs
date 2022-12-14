using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChaseState : StateMachineBehaviour
{
    //NavMeshAgent agent;
    private CharacterController enemyCC;
    Transform player;
    float chaseRange = 14;

    private float enemySpeed = 1.5f;
    private float gravity = 1f;

    private Vector3 velocity;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent = animator.GetComponent<NavMeshAgent>();
        //agent.speed = 3.5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = player.transform.position - animator.transform.position;
        direction.Normalize();
        direction.y = 0;
        Quaternion fastLook = Quaternion.LookRotation(direction);
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, fastLook, Time.deltaTime * 3);
        velocity = direction * enemySpeed;

        
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > chaseRange)
        {
            animator.SetBool("isChasing", false);
        }
        if (distance < 3)
        {
            animator.SetBool("isAttacking", true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
