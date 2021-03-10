using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorV : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initial;
    public Vector2 defaultV;

    public void OnAfterDeserialize()
    {
        initial = defaultV;
    }
    public void OnBeforeSerialize()
    {

    }
}
