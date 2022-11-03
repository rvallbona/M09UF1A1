using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJump : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hola");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().PlatformJump();
        }
    }
}
