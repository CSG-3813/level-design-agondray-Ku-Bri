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

    public LayerMask Player;
    public GameObject lastHit;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AudioManager.instance.Stop("ChaseMusic");
        AudioManager.instance.Play("GoblinHiss");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 2.5f;
        timer = 0;
      
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
        //float dot = Vector3.Dot(agent.transform.forward, (player.position - agent.transform.position).normalized);
        if (distance < chaseRange /*&& dot > 1f*/)
        {
            AudioManager.instance.Play("ChaseMusic");
            animator.SetBool("isChasing", true);

        }
        else
        {
            animator.SetBool("isChasing", false);
        }
        //Debug.Log("Player in Range");
        //var ray = new Ray(agent.transform.position, agent.transform.forward);
        //RaycastHit hit;
        /*if (Physics.Raycast(ray, out hit))
        {
            lastHit = hit.transform.gameObject;
            if (lastHit.CompareTag("Player"))
            {
                Debug.Log("We found Target!");
                AudioManager.instance.Play("ChaseMusic");
                animator.SetBool("isChasing", true);
            }
        }
        else if(lastHit.CompareTag("Player"))
        {
            //Debug.Log("I found something else with name");
            animator.SetBool("isChasing", false);

        }
    }*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
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
