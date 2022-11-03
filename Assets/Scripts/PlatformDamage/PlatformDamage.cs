using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDamage : MonoBehaviour
{
    [SerializeField]Player_Manager player_Manager;
    public int dmg = 10;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Damage");
            player_Manager.Damage(dmg);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Damage");
            player_Manager.Damage(dmg);
        }
    }
}
