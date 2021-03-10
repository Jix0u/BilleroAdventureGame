using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatV : ScriptableObject, ISerializationCallbackReceiver
{
    // Start is called before the first frame update
    public float initial;
    [HideInInspector]
    public float runTime;

    public void OnAfterDeserialize()
    {
        runTime = initial;
    }
    public void OnBeforeSerialize()
    {

    }

}
