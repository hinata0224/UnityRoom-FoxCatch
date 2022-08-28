using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartfoxRestart : MonoBehaviour
{
    [SerializeField] private Transform startPos;

    [SerializeField] private GameObject fox;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == fox)
        {
            fox.transform.position = startPos.position;
        }
    }
}
