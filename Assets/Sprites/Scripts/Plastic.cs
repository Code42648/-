using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plastic : MonoBehaviour
{
    public TMP_Text plasticText;
    private float plastic = 0;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Plastic")
        {
            Destroy(coll.gameObject);
            plasticText.text = plastic.ToString();
            plastic++;                                                                  
        }
    }
}