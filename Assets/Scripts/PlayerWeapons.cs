using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    private PlayerController _playerScript;
    public GameObject gun;
    public GameObject grapplingHook;
    // Start is called before the first frame update
    public int currentWeapon = 1;
    void Start()
    {
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        currentWeapon = _playerScript.currentWeapon;

        grapplingHook.SetActive(true);
        gun.SetActive(false);

        if (_playerScript == null)
            Debug.LogError("Player script null");
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = _playerScript.currentWeapon;
        if (currentWeapon == 1 && !grapplingHook.activeSelf)
        {
            grapplingHook.SetActive(true);
            gun.SetActive(false);
        }
        if (currentWeapon == 2 && !gun.activeSelf)
        {
            grapplingHook.SetActive(false);
            gun.SetActive(true);
        }
    }

    void SetWeapon()
    {
        if (currentWeapon == 1)
        {
            grapplingHook.SetActive(true);
            gun.SetActive(false);
        }
    }
}

