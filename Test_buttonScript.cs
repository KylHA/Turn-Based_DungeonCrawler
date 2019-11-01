using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_buttonScript : MonoBehaviour
{
    Encounter_reached reached;

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
        reached.Encounter=true;
    }
}
