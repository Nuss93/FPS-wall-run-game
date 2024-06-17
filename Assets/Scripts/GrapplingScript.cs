using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingScript : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    [SerializeField] Camera cam;
    [SerializeField] float fov;
    [SerializeField] float grapplfov;
    [SerializeField] float grapplfovTime;
    private PlayerController _playerScript;
    private int currentWeapon;

    private void Start()
    {
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        currentWeapon = _playerScript.currentWeapon;

        if (_playerScript == null)
            Debug.LogError("Player script null");
    }
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        currentWeapon = _playerScript.currentWeapon;
        if (currentWeapon == 2)
        {
            if (joint) Destroy(joint);
        }
        if (Input.GetMouseButtonDown(0) && currentWeapon == 1)
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0) && currentWeapon == 1)
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void OnDisable()
    {
        lr.positionCount = 0;
        if (joint) Destroy(joint);
    }


    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(origin: camera.position, direction: camera.forward, out hit, maxDistance, whatIsGrappable))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, grapplfov, grapplfovTime * Time.deltaTime);

            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            //The distance grapple will try to keep from grapple point.
            float distanceFromPoint = Vector3.Distance(a: player.position, b: grapplePoint);
            joint.maxDistance = distanceFromPoint * 0.3f;
            joint.minDistance = distanceFromPoint * 0.1f;

            //Adjust these values to fit your game.
            joint.spring = 7f;
            joint.damper = 6f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }
    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        lr.SetPosition(index: 0, gunTip.position);
        lr.SetPosition(index: 1, grapplePoint);
    }

    private Vector3 currentGrapplePosition;

    void StopGrapple()
    {
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, grapplfovTime * Time.deltaTime);
        lr.positionCount = 0;
        Destroy(joint);
    }
}
