using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cappy : MonoBehaviour
{
    private float timer;
    private float speedCappy = 100f;
    Rigidbody rb;
    public void Start()
    {
        timer = 0;
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        timer += Time.deltaTime;
        CappyStartStopDestroy();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            other.gameObject.GetComponent<PlayerController>().CappyJump();
            Destroy(this.gameObject);
        }
    }
    public void CappyStartStopDestroy()
    {
        if (timer <= 2)
        {
            Debug.Log("addforce");
            rb.AddForce(transform.forward * speedCappy * Time.deltaTime, ForceMode.Force);
        }
        if (timer >= 1.5f)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (timer >= 6)
        {
            Destroy(this.gameObject);
        }
    }
}
