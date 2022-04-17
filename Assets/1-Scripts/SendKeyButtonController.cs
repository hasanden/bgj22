using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendKeyButtonController : MonoBehaviour
{
    public GameObject endGameUI;

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
            endGameUI.SetActive(true);
        }
        else
        {
            AudioController.Instance.PlayIDHKey();
        }
    }
}
