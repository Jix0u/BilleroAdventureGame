using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    stagger,
    walk,
    attack
}
public class Enemy : MonoBehaviour
{
    public EnemyState curState;
    public FloatV maxH;
    public float health;
    public string ename;
    public int attack;
    public int speed;

    private void Awake()
    {
        health = maxH.initial;
    }

    private void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(Dead());
        }
    }
    private IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
    public void Knock(Rigidbody2D rg, float time, float damage)
    {
        StartCoroutine(KnockCoroutine(rg, time));
        Damage(damage);
    }
    private IEnumerator KnockCoroutine(Rigidbody2D rg, float time)
    {
        if(rg!=null)
        {
            yield return new WaitForSeconds(time);
            rg.velocity = new Vector3();
            rg.GetComponent<Enemy>().curState = EnemyState.idle;
            rg.velocity = new Vector3();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

