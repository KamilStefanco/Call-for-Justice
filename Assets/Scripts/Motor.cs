using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public int Speed = 5;
    Transform _anchor;

    void Start()
    {
        _anchor = GameObject.FindGameObjectWithTag("Anchor").transform;
    }
    void Update()
    {
        transform.RotateAround(_anchor.position, Vector3.forward, Speed * Time.deltaTime);
    }
}
