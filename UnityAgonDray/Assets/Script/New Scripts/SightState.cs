using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SightState : StateMachineBehaviour
{
    NavMeshAgent agent;

    Transform player;

    Animator anim;

    public SphereCollider collider;
    public float FOV = 90f;
    public LayerMask LineOfSightLayers;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        collider = agent.GetComponent<SphereCollider>();
        anim = animator;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
  //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        //
    //}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (CheckLineOfSight(player))
            {
                anim.SetBool("isChasing", true);
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("isPatrolling", true);
        }
    }

    bool CheckLineOfSight(Transform player)
    {
        Vector3 Direction = (player.transform.position - agent.transform.position).normalized;
        if (Vector3.Dot(agent.transform.forward, Direction) >= Mathf.Cos(FOV))
        {
            RaycastHit Hit;
            if (Physics.Raycast(agent.transform.position, Direction, out Hit, collider.radius, LineOfSightLayers))
            {
                if (Hit.transform != null)
                {
                    return true;
                }
            }
        }
        return false;
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
