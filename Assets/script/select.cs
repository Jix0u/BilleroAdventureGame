using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class select : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("heyoo");

        Debug.Log("bruh heyyoooo");
            transform.GetComponent<slots>().Drop();
        
    }
}
