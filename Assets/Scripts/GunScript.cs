using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    private PlayerController _playerScript;
    private int currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        currentWeapon = _playerScript.currentWeapon;

        if (_playerScript == null)
            Debug.LogError("Player script null");
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = _playerScript.currentWeapon;
        // if (currentWeapon == 2)
        // {
        //     if (joint) Destroy(joint);
        // }
        if (Input.GetMouseButtonDown(0) && currentWeapon == 2)
        {
            Shoot();
        }
        else if (Input.GetMouseButtonUp(0) && currentWeapon == 2)
        {

        }
    }
    public virtual void Shoot()
    {
        Debug.Log("pew");
    }
}
