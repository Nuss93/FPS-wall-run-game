using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public int currentWeapon = 1;

    private PlayerController _playerScript;
    // Start is called before the first frame update
    void Start()
    {
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (_playerScript == null)
            Debug.LogError("Player script null");
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     changeWeapon(1);
        //     Debug.Log(currentWeapon);
        // }
        // else if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     changeWeapon(2);
        //     Debug.Log(currentWeapon);
        // }
    }
}
