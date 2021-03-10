using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slots : MonoBehaviour
{
    private Inventory1 inventory;
    public int i;
    // Start is called before the first frame update
    private void Start()
    {
        inventory= GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory1>();
    }
    private void Awake()
    {
        Debug.Log(transform.childCount);
    }
    // Update is called once per frame
    private void Update()
    {
        if (transform.childCount <= 0)
        {
            //Debug.Log(transform.childCount);
            inventory.isFull[i] = false;
        }
    }
   
    public void Drop()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<spawn>().SpawnDrop();
            GameObject.Destroy(child.gameObject);
        }
    }
}
