using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawn : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject explosion;
    public ParticleSystem[] effects;
    public GameObject PopupPanel;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enchy")
        {
            Debug.Log("Enchy touched");
            Instantiate(explosion, transform.position, transform.rotation);
            foreach (var effect in effects)
            {
                effect.transform.parent = null;
                effect.Stop();
                Destroy(effect.gameObject, 1.0f);
            }

            //Destroy(gameObject);
            //PopupPanel.SetActive(!PopupPanel.activeSelf);
            PopupPanel.SetActive(true);

        }
        
            

    }
}
