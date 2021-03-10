using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageH : MonoBehaviour
{
    public Image []hearts;
    public Sprite full;
    public Sprite half;
    public Sprite empty;
    public Sprite threefourth;
    public Sprite quarter;
    public FloatV container;
    public FloatV playerH;

    void Start()
    {
        InitHearts();
    }
    // Start is called before the first frame update
    public void InitHearts()
    {
        for(int i = 0; i<container.initial; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = full;
        }
    }

    // Update is called once per frame
    public void UpdateHearts()
    {
        Debug.Log(playerH);
        float temp = playerH.runTime / 4;
        for (int i = 0; i < container.initial; i++)
        {
            float currHeart = Mathf.Ceil(temp - 1);
            if (i <= temp - 1)
            {
                //FullHeart
                hearts[i].sprite = full;
            }
            else if (i >= temp)
            {
                //emptyHeart
                hearts[i].sprite = empty;
            }
            else if (i == currHeart && (temp % 1) == .50)
            {
                //Half full heart
                hearts[i].sprite = half;
            }
            else if (i == currHeart && (temp % 1) == .25)
            {
                //1/4 heart
                hearts[i].sprite = quarter;
            }
            else 
            {
                //3/4 heart
                hearts[i].sprite = threefourth;
            }
        }
    }
}
