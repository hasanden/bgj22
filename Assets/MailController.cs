using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailController : MonoBehaviour
{

    public GameObject[] mailList;
    public GameObject[] buttonList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ActivateMail1()
    {
        foreach(GameObject g in mailList)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in buttonList)
        {
            g.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        buttonList[0].GetComponent<Image>().color = new Color(0, 1, 0, 0.4f);
        mailList[0].SetActive(true);
    }
    public void ActivateMail2()
    {
        foreach (GameObject g in mailList)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in buttonList)
        {
            g.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        buttonList[1].GetComponent<Image>().color = new Color(0, 1, 0, 0.4f);
        mailList[1].SetActive(true);
    }
    public void ActivateMail3()
    {
        foreach (GameObject g in mailList)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in buttonList)
        {
            g.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        buttonList[2].GetComponent<Image>().color = new Color(0, 1, 0, 0.4f);
        mailList[2].SetActive(true);
    }
    public void ActivateMail4()
    {
        foreach (GameObject g in mailList)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in buttonList)
        {
            g.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        buttonList[3].GetComponent<Image>().color = new Color(0, 1, 0, 0.4f);
        mailList[3].SetActive(true);
    }

}
