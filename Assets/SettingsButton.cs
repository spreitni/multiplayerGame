using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SettingsButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
       int n;
   public void OnButtonPress(){
        n++;
        Debug.Log("Button clicked " + n + " times.");
   }
}
