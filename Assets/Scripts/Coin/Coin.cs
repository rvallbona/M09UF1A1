using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Player_Game Player_Game;
    public int value = 1;
    GameObject coin;
    private void Start()
    {
        coin = this.gameObject;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Coin");
            Player_Game.Coin(value);
            Destroy(coin);
        }
    }
}
