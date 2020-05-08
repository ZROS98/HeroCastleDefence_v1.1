using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingTag : MonoBehaviour
{
    //[SerializeField] private Transform _spawnPoint2;
    void Awake()
    {
        if (gameObject.CompareTag("Untagged"))
        {
            if (GameObject.FindGameObjectsWithTag("Player1").Length == 0)
            {
                Debug.Log("Tag Player1 added");
                gameObject.tag = "Player1";
                if (gameObject.CompareTag("Player1"))
                {
                    //gameObject.transform.position = new Vector3(25,1,85);
                }
            }
            else if(GameObject.FindGameObjectsWithTag("Player1").Length == 1)
            {
                Debug.Log("Tag Player2 added");
                gameObject.tag = "Player2";
                gameObject.transform.position = new Vector3(75, 1, 16);
            }
        }
    }

    private void Start()
    {
        
    }

//    private void Update()
//    {
//        if (gameObject.CompareTag("Player2"))
//        {
//            Debug.Log("Try to change to spawnPoint");
//            gameObject.transform.position = new Vector3(75,1,16);
//            Debug.Log("PositionChanged");
//        }
//    }
}
