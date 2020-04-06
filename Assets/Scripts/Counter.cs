using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public References prefabReferences;
    /*public*/int stackedTophats;

    void Update() 
    {
        stackedTophats = prefabReferences.attach.stackedTophats;
        GetComponent<Text>().text = "" + stackedTophats;
    }
}
