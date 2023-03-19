using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class Timer : MonoBehaviourPunCallbacks
{
    public TMPro.TMP_Text ProofOf;
    public float ammoleftproof = 120;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*ammoleftproof = ammoleftproof - Time.deltaTime;
        ProofOf.text = ammoleftproof.ToString("F0");*/
       string monthVar = System.DateTime.Now.ToString();
       ProofOf.text = monthVar;
    }
}
