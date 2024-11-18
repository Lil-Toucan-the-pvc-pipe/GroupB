using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIFunctions : MonoBehaviour
{
    public void ObjectOnOff(GameObject objectToChange)
    {
        if(objectToChange.activeInHierarchy)
            objectToChange.SetActive(false);
        else 
            objectToChange.SetActive(true);
    }


}
