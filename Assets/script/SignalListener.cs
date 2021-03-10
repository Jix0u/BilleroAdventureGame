using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent e;
    public void OnSignalR()
    {
        e.Invoke();
    }

    private void OnEnable()
    {
        if(this!=null)
        signal.Reg(this);
    }
    private void OnDisable()
    {
        if(this!=null)
        signal.DeReg(this);
    }
}
