using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cappy : MonoBehaviour
{
    private float timer;
    private float speedCappy;
    Rigidbody rb;
    public GameObject player;
    public void Start()
    {
        timer = 0;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void FixedUpdate()
    {
        timer = Time.deltaTime;
        rb.MovePosition(new Vector3(rb.position.x, 1, speedCappy * Time.deltaTime));
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Cappy");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            other.gameObject.GetComponent<PlayerController>().CappyJump();
        }
    }
}
