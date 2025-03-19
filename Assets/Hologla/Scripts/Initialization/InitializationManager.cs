using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializationManager : MonoBehaviour
{
    public bool isInitializing = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetInitialization(bool value)
    {
        isInitializing = value;
    }
}
