using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public static Player_Manager _PLAYER_MANAGER;
    [SerializeField] int live = 100;
    [SerializeField] bool godMode = false;
    [SerializeField] float time_goodMode = 1f;
    private void Awake()
    {
        if (_PLAYER_MANAGER != null && _PLAYER_MANAGER != this)
        {
            Destroy(_PLAYER_MANAGER);
        }
        else
        {
            _PLAYER_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }
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
}

