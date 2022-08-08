using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChinemaSceneController : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera overhead;

    private int default_value;
    [SerializeField] private int max_value = 50;

    private void Awake()
    {
        default_value = overhead.Priority;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Attattayo");
        if (!other.gameObject.CompareTag("Player"))
        {
            overhead.Priority = max_value;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            overhead.Priority = default_value;
        }
    }
}
