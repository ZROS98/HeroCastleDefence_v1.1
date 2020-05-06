using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingTag : MonoBehaviour
{ 
    void Start()
    {
        if (gameObject.CompareTag("Untagged"))
        {
            if (GameObject.FindGameObjectsWithTag("Player1").Length == 0)
            {
                Debug.Log("Tag Player1 added");
                gameObject.tag = "Player1";
            }
            else if(GameObject.FindGameObjectsWithTag("Player1").Length == 1)
            {
                Debug.Log("Tag Player2 added");
                gameObject.tag = "Player2";
            }
        }
    }

}
