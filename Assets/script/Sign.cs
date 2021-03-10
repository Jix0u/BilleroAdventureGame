using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject dialogueB;
    public TextMeshProUGUI dia;
    public string dialogue;
    public bool flag;
    public Signal clueOn;
    public Signal clueOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        { 
            dialogueB.SetActive(true);
            dia.text = dialogue;
        }
        else
        {
            dialogueB.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clueOn.Raise();
            flag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clueOff.Raise();
            flag = false;
        }
    }
}
