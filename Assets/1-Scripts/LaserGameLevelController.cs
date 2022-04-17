using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGameLevelController : MonoBehaviour
{
    public GameObject[] levels;

    public static LaserGameLevelController Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateLevel(int index)
    {
        foreach(GameObject g in levels)
        {
            g.SetActive(false);
        }

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Laser"))
        {
            Destroy(g);
        }

        levels[index].SetActive(true);

        CameraController.Instance.ActivateLaserCamera();
    }

}
