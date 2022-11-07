using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    //[SerializeField] public Rigidbody rb;
    //[SerializeField] public Transform[] platformPosition;
    //[SerializeField] private float platformSpeed = 10;
    //private int currentPosition = 0;
    //private int nextPosition = 1;
    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}
    //void Update()
    //{
    //    MovePlatform();
    //}    
    //void MovePlatform()
    //{
    //    if (Vector3.Distance(rb.position, platformPosition[nextPosition].position) <= 0)
    //    {
    //        currentPosition = nextPosition;
    //        nextPosition++;
    //    }
    //    if (nextPosition > platformPosition.Length - 1)
    //    {
    //        nextPosition = 0;
    //    }
    //    rb.MovePosition(Vector3.MoveTowards(rb.position, platformPosition[nextPosition].position, platformSpeed * Time.deltaTime));
    //}
}
