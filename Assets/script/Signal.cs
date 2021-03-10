using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{
    public List<SignalListener> listener = new List<SignalListener>();

    public void Raise()
    {
        for(int i=0; i<listener.Count; i++) {
            listener[i].OnSignalR();
        }

    }

    public void Reg(SignalListener s)
    {
        listener.Add(s);
    }
    public void DeReg(SignalListener s)
    {
        listener.Remove(s);
    }
}
