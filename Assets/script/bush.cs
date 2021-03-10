using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush : Enemy
{
    [SerializeField] private float radius;
    public Transform cur;
    public Transform target;
    public Rigidbody2D rg;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        curState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckD();
    }

    private void CheckD()
    {
        if(Vector3.Distance(target.position, cur.position) < radius && Vector3.Distance(target.position, cur.position)>1f) {
            if (curState == EnemyState.idle || curState == EnemyState.walk && curState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(cur.position, target.position, speed * Time.deltaTime);
                ChangeA(temp - transform.position);
                rg.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(target.position, cur.position) > radius)
        {
            anim.SetBool("wakeUp", false);
        }

    }
    private void ChangeA(Vector3 bro)
    {
        if (Mathf.Abs(bro.x) > Mathf.Abs(bro.y)){
            Debug.Log("big x");
            if (bro.x > 0)
            {
                Debug.Log("right");
                anim.SetFloat("moveX", 1);
                anim.SetFloat("moveY", 0);
            }
            else if (bro.x < 0)
            {
                Debug.Log("left");
                anim.SetFloat("moveX", -1);
                anim.SetFloat("moveY", 0);
            }
        }
        else if (Mathf.Abs(bro.x) < Mathf.Abs(bro.y)){
            Debug.Log("big y");
            if (bro.y > 0)
            {
                anim.SetFloat("moveX", 0);
                anim.SetFloat("moveY", 1);
            }
            else if (bro.y < 0)
            {
                anim.SetFloat("moveX", 0);
                anim.SetFloat("moveY", -1);
            }
        }

    }
    private void ChangeState(EnemyState newS){
        if (newS != curState) {
            curState = newS;
        }

    }
}
