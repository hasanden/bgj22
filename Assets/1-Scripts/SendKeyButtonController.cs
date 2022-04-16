using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendKeyButtonController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SendKey()
    {
        if(ConsoleController.Instance.hasEncryptionKey)
        {
            //ending
        }
        else
        {
            AudioController.Instance.PlayIDHKey();
        }
    }
}
