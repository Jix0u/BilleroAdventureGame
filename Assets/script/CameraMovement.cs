using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform p;
    public float smoothing=0.3F;
    private Vector3 velocity = Vector3.one;
    public Vector2 maxpos;
    public Vector2 minpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (transform.position != p.position)
        { 
            var pposition = new Vector3(p.position.x, p.position.y, transform.position.z);
            pposition.x = Mathf.Clamp(pposition.x, minpos.x, maxpos.x);
            pposition.y = Mathf.Clamp(pposition.y, minpos.y, maxpos.y);
            transform.position = Vector3.SmoothDamp(transform.position, pposition, ref velocity, smoothing);
        }
    }
}
