using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D rigid;
    private Vector3 change;
    private Animator animator;
    public FloatV curHe;
    public Signal playerS;
    public VectorV start;
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = start.initial;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack")&&currentState!=PlayerState.attack && currentState!=PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationandMove();
        }
    
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.3f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationandMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    public void Knock(float time, float damage)
    {
        Debug.Log(curHe.initial);
        curHe.runTime -= damage;
        playerS.Raise();
        if (curHe.runTime > 0) {
            StartCoroutine(KnockCoroutine(time));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
           
    }

    void MoveCharacter()
    {
        change.Normalize();
        rigid.MovePosition(
            transform.position + change.normalized * speed * Time.deltaTime
        );
    }

    private IEnumerator KnockCoroutine(float time)
    {
        if (rigid != null )
        {
            yield return new WaitForSeconds(time);
            rigid.velocity = new Vector3();
            currentState = PlayerState.idle;
            rigid.velocity = new Vector3();
        }
    }
}
