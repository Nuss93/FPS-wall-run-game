using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingScript : MonoBehaviour
{
    [SerializeField] PlayerWeapons currentWeapon;

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;

    private void Start()
    {
        
    }
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0)){
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }


    void StartGrapple()
    {
        RaycastHit hit;
        if(Physics.Raycast( origin: camera.position, direction: camera.forward, out hit, maxDistance, whatIsGrappable))
        {
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
        lr.positionCount = 0;
        Destroy(joint);
    }
}
