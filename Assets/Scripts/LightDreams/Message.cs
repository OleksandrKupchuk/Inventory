using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{

    [SerializeField] private float timeToDestroy;

    void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
