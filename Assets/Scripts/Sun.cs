using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private Transform level;
    [SerializeField] private float degreesPerSecond;

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(level);
        transform.GetChild(0).transform.LookAt(level);
        transform.RotateAround(level.position, Vector3.left, degreesPerSecond * Time.deltaTime);
    }
}
