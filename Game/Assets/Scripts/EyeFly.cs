using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFly : StateMachineBehaviour
{
    public float speed = 5f;
    public float attackRange = 1f;
    private Transform player;
    Rigidbody2D rb;
    private FlyingEyeEnemy flyingEyeEnemy;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        flyingEyeEnemy = animator.GetComponent<FlyingEyeEnemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        flyingEyeEnemy.LookAtPlayer();
        var target = new Vector2(player.position.x, player.position.y);
        var newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
