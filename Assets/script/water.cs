using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class water : MonoBehaviour, IPointerClickHandler
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
        if (ChangeTile.GetCurtool() != "water")
        {
            myImageComponent.sprite = original;
        }
    }
    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {
        if (ChangeTile.GetCurtool() == "water")
        {
            ChangeTile.count = 0;
            myImageComponent.sprite = original;
            ChangeTile.SetCurtool("none");
            return;
        }
        ChangeTile.count = 0;
        ChangeTile.SetCurtool("water");
        myImageComponent.sprite = highlight;

        
    }
}
