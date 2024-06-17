using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Text currentWeaponStats;
    private PlayerController _playerScript;
    private int currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        currentWeapon = _playerScript.currentWeapon;
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = _playerScript.currentWeapon;
        SetStats();
    }

    void SetStats()
    {
        if (currentWeapon == 1) currentWeaponStats.text = "Grappling mode";
        else currentWeaponStats.text = "Gun mode";
    }
}
