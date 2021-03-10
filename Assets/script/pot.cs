using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{
    private Animator an;

    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Break()
    {
        an.SetBool("Break", true);
        StartCoroutine(Bre());
    }
    IEnumerator Bre()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}
