using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGameController : MonoBehaviour
{
    public float rotationSpeed;

    private bool controllingMirror;
    private Vector3 initialClickPos;
    private Vector3 initialRot;
    private GameObject controlledMirror;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Mirror"))
                {
                    controllingMirror = true;
                    controlledMirror = hit.transform.gameObject;
                    initialClickPos = Input.mousePosition;
                    initialRot = controlledMirror.transform.rotation.eulerAngles;
                }
            }
        }

        if(Input.GetMouseButton(0))
        {
            if(controllingMirror)
            {
                float dif = Input.mousePosition.x - initialClickPos.x;
                controlledMirror.transform.rotation = Quaternion.Euler(initialRot.x, initialRot.y, initialRot.z + dif * rotationSpeed );
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            controllingMirror = false;
        }
    }
}
