using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class button : MonoBehaviour, IPointerClickHandler
{
    public Inventory1 inventory;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
    }
}
