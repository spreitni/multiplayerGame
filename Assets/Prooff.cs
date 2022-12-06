using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Prooff : MonoBehaviour
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
        ammoleftproof = ammoleftproof - Time.deltaTime;
        ProofOf.text = ammoleftproof.ToString("F0");
       
    }
}
