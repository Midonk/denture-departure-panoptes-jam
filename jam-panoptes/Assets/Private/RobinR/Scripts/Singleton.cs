using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<_INSTANCE_TYPE_> : MonoBehaviour
    where _INSTANCE_TYPE_ : Singleton<_INSTANCE_TYPE_>
{
    public static _INSTANCE_TYPE_ Instance;

    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this as _INSTANCE_TYPE_;
    }


}
