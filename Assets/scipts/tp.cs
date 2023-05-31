using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tp : MonoBehaviour {

    [SerializeField] private Transform target;
    public bool tpwithoffset;
    
    public Transform GetDestination()
    {
        return target;
    }
}
