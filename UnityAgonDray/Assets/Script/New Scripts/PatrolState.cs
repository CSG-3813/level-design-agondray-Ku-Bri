using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    float timer;
    List<Transform> waypoints = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    float chaseRange = 8;

    //Animator anim;

   /* public SphereCollider collider;
    public float FOV = 90f;
    public LayerMask LineOfSightLayers;
   */
    /*public float viewRadius = 15;
    public float viewAngle = 90;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    
    bool m_PlayerInRange;
    bool m_IsPatrol;
    Vector3 m_PlayerPosition;
    */
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AudioManager.instance.Stop("ChaseMusic");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 2.5f;
        timer = 0;
        //collider = agent.GetComponent<SphereCollider>();
        //anim = animator;
        GameObject go = GameObject.FindGameObjectWithTag("Waypoints");
        foreach (Transform t in go.transform)
        {
            waypoints.Add(t);
        }
        agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
        }
        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("isPatrolling", false);
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange /*&& CheckLineOfSight(player)*/)
        {
            AudioManager.instance.Play("ChaseMusic");
            animator.SetBool("isChasing", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }


   /*  void OnTriggerEnter(Collider other)
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
   */

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
