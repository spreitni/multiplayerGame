using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ExitNutton : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
   public void OnButtonPress(){
      Debug.Log("quitting game");
      Application.Quit();
   }
}
