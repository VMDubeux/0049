using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTester : MonoBehaviour
{
    private Action _myAction;

    void Start()
    {
        _myAction = DebugANumber;
        _myAction += DebugAString;
        _myAction?.Invoke();
    }

    void Update()
    {
        
    }

    private void DebugANumber() 
    {
        Debug.Log("5");
    }

    private void DebugAString() 
    {
        Debug.Log("Hello World!");
    }
}
