using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class seed : MonoBehaviour , IPointerClickHandler
{
    public Image myImageComponent;
    public Sprite highlight;
    public Sprite original;
    // Start is called before the first frame update
    void Start()
    {
        myImageComponent = GetComponent<Image>();
    }
    void Update()
    {
        if (ChangeTile.GetCurtool() != "seed")
        {
            myImageComponent.sprite = original;
        }
       
    }
    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {
        ChangeTile.count = 0;
        if (ChangeTile.GetCurtool() == "seed")
        {
            myImageComponent.sprite = original;
            ChangeTile.SetCurtool("none");
            return;
        }
        ChangeTile.SetCurtool("seed");
        myImageComponent.sprite = highlight;
    }
}
