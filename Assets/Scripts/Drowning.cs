using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Drowning : MonoBehaviour
{
   
    // Start is called before the first frame update
       
    public GameObject explosion;
    public ParticleSystem[] effects;
    public GameObject PopupPanel;
    public charMove cMove;
    public float speed = 1.0F;
    private float startTime;
    private Vector3 scale;
    public Vector3 positionToMoveTo;





    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enchy")
        {
            Debug.Log("Enchy touched");

            explosion.transform.position = other.transform.position;
            explosion.SetActive((true));
            cMove.gravityValue += 12;
            Destroy(other.GetComponent<CapsuleCollider>());



            StartCoroutine(LerpPosition(positionToMoveTo, 5));

            IEnumerator LerpPosition(Vector3 targetPosition, float duration)
            {
                yield return new WaitForSeconds(5);
                scale = new Vector3(1f, 1f, 1f);
                float time = 0;
                while (time < duration)
                {
                    PopupPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
                    PopupPanel.SetActive(true);
                    PopupPanel.GetComponent<RectTransform>().localScale =
                        Vector3.Lerp(Vector3.zero, scale, time / duration);
                    time += Time.deltaTime;
                    yield return null;
                }
                //PopupPanel.transform.position = targetPosition;
                Destroy(GameObject.FindWithTag("Enchy"));
            }

            

        }
    }
}

    

