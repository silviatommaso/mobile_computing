using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectedObjects = new List<Collider2D>();
    public Collider2D col;


    //Rileva quanco un oggetto entra nella zona
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            detectedObjects.Add(collider);
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        detectedObjects.Remove(collider);
    }
}
