using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject cat;
    Vector2 offset;

    void Start()
    {
        offset = new Vector2(8.5f, 4f);
    }
    // Update is called once per frame
    void Update () {
        transform.position = cat.transform.position - cat.transform.forward * offset.x;
        gameObject.transform.LookAt(cat.transform);
        transform.position = transform.position + Vector3.up * offset.y;

    }
}
