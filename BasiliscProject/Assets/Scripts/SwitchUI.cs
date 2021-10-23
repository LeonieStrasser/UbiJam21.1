using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thisObject;
    public GameObject nextObject;

    public void ChangeUI()
    {
        if(thisObject != null)
        {
            thisObject.SetActive(false);
        }

        if (nextObject != null)
        {
            nextObject.SetActive(true);
        }
    }
}
