using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDamage : MonoBehaviour
{
    [SerializeField] public Player_Game Player_Game;
    public int dmg = 10;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Damage");
            Player_Game.Damage(dmg);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Damage");
            Player_Game.Damage(dmg);
        }
    }
}
