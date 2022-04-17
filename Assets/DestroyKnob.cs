using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyKnob : MonoBehaviour
{

    public GameObject knob;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KnobDestroyer()
    {
        knob.SetActive(false);
    }

}
