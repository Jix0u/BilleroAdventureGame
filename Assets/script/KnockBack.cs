using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private float impact;
    [SerializeField] private float time;
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("breakable") && gameObject.CompareTag("Player"))
        {
            collision.GetComponent<pot>().Break();
        }
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D whatever = collision.GetComponent<Rigidbody2D>();
            if (whatever != null)
            {
                Vector3 force = (whatever.transform.position - transform.position).normalized * impact;
                whatever.AddForce(force, ForceMode2D.Impulse);
                if (collision.gameObject.CompareTag("Enemy") && collision.isTrigger)
                {
                    whatever.GetComponent<Enemy>().curState = EnemyState.stagger;
                    collision.GetComponent<Enemy>().Knock(whatever, time, damage);

                }
                if (collision.gameObject.CompareTag("Player"))
                {
                    if (collision.gameObject.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        whatever.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        collision.GetComponent<PlayerMovement>().Knock(time, damage);
                        StartCoroutine(DelayP());

                    }


                }
            }
        }
    }
    private IEnumerator DelayP()
    {
        yield return new WaitForSeconds(2);
    }
}
