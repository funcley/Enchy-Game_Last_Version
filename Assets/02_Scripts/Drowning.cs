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
    private Color tempColor;
    public GameObject YouDied;
    //public BoxCollider level;




    void OnTriggerEnter(Collider other)
    {
        //level = GameObject.FindWithTag("Level");
       
       
        if (other.tag == "Enchy")
        {
            Debug.Log("Enchy touched"); 
            
            
            SoundManager.Instance.PlaySound(SoundType.TypeLose);
    
            tempColor = new Color(1,1,1,0f);
            /*var transparentobj = other.GetComponent<SpriteRenderer>().color;
            transparentobj.a = 0.5f;
            other.GetComponent<SpriteRenderer>().color = transparentobj;*/
            other.GetComponent<Renderer>().material.color = tempColor;

            Destroy(GameObject.FindWithTag("EnchyChild"));
            GameObject[] steps = GameObject. FindGameObjectsWithTag("Step");
                for(int i=0; i< steps. Length; i++)
                {
                    Destroy(steps[i].GetComponent<BoxCollider>());
                }
            //Destroy(level.GetComponentInChildren<BoxCollider>());
            //Destroy(level.GetComponentInChildren<Rigidbody>());
            Debug.Log("boxies");
            
            
                explosion.transform.position = other.transform.position;
                explosion.SetActive((true));
                cMove.gravityValue += 12;
                
                /*void Update()
                {
                    float x = other.transform.position.x * Mathf.Sin(Time.time * 78) * 8881f;
                    float y = other.transform.position.y;
                    float z = other.transform.position.z * Mathf.Sin(Time.time * 99999f) * 09999999f;;
                    other.transform.up = new Vector3 (x,y,z);
                }*/


            

                

            
            StartCoroutine(LerpPosition(positionToMoveTo, 5));

            IEnumerator LerpPosition(Vector3 targetPosition, float duration)
            {
                yield return new WaitForSeconds(8);
                YouDied.SetActive(true);
                SoundManager.Instance.PlaySound(SoundType.TypeYoulose);
                yield return new WaitForSeconds(1);
                //Destroy(GameObject.FindWithTag("YouDied"));
                
                yield return new WaitForSeconds(8);
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
                //
                
                //PopupPanel.transform.position = targetPosition;
                Destroy(GameObject.FindWithTag("Enchy"));
            }



        }
    }
}

    

