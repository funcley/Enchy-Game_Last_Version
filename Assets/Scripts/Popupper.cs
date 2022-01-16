using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popupper : MonoBehaviour
{
    public GameObject PopupPanel;
    public void ShowPanel()
    {
        
        
        PopupPanel.SetActive(!PopupPanel.activeSelf);
        
    }

    public void CLosePanel()
    {

        PopupPanel.SetActive(false);
    }

}
