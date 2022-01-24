using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlock : MonoBehaviour
{

    
    public GameObject ShortLaser;
    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LaserBlocker")
        {
              
            ShortLaser.SetActive(!ShortLaser.activeSelf);
            gameObject.SetActive(false);
        }
    }
}
