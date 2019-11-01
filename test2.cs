using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
  Encounter_reached reached;

    // Start is called before the first frame update
    void Start()
    {
        reached=GameObject.Find("Control_Sprite").GetComponent<Encounter_reached>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        reached.Encounter=false;
        Debug.Log("Entered Test");
    }
}
