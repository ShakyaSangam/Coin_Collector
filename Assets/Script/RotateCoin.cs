using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    private Vector3 vec3;
    // Update is called once per frame
    void Update()
    {
        vec3 = new Vector3(45.0f, 0.0f, 0.0f);
        transform.Rotate(vec3 * Time.deltaTime);
    }
}
