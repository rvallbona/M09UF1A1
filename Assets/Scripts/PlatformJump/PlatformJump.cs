using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJump : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hola");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            other.gameObject.GetComponent<PlayerController>().PlatformJump();
        }
    }
}
