using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomMovement : MonoBehaviour
{
    public Vector2 camerachange;
    public Vector3 playerchange;
    private float time = 0;
    private CameraMovement c;
    public bool needText;
    public string placeName;
    public GameObject text;
    public TextMeshProUGUI placeText;
    // Start is called before the first frame update
    void Start()
    {
        c = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (c.smoothing !=0)
        {
            StartCoroutine(CameraSlow());
        }
    }

    private IEnumerator CameraSlow()
    {
        yield return new WaitForSeconds(1f);
        c.smoothing = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            c.smoothing = (float)0.1;
            c.minpos += camerachange;
            c.maxpos += camerachange;
            collision.transform.position += playerchange;
            if (needText)
            {
                StartCoroutine(placeNameCo());
            }

        }
          
    }
    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(2f);
        text.SetActive(false);

    }
}
