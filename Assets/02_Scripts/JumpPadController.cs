using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadController : MonoBehaviour
{
    //public Vector3 jumpCoef;
    public charMove cm;
    public float JumpCoef;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enchy")
        {
            cm.jumpHeight = JumpCoef;


            cm.playerSpeed = JumpCoef / 1.9f;
            Debug.Log("You currently have more power.");
            SoundManager.Instance.PlaySound(SoundType.TypeBoost);
            other.GetComponent<Renderer>().material.color =gameObject.GetComponent<Renderer>().material.color;


            Destroy(gameObject);
        }
    }
}

