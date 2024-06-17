using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
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

    }
}
