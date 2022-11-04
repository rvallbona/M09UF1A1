using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Game : MonoBehaviour
{
    [SerializeField] int live = 100;
    [SerializeField] bool godMode = false;
    [SerializeField] float time_goodMode = 1f;
    [SerializeField] int money = 0;
    public void Damage(int dmg)
    {
        if (!godMode && live >= 0)
        {
            live -= dmg;
            StartCoroutine(God());
            if (live <= 0)
            {
                GameOver();
            }
        }
    }
    void GameOver()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0;
    }
    IEnumerator God()
    {
        godMode = true;
        yield return new WaitForSeconds(time_goodMode);
        godMode = false;
    }
    public void Coin(int value)
    {
        money += value;
    }
}

