﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LazerPointer : MonoBehaviour
{
	public SteamVR_Input_Sources handType;
	public SteamVR_Behaviour_Pose controllerPose;
	public SteamVR_Action_Boolean teleportAction;

	public GameObject laserPrefab;
    public Transform cameraRigTransform;
    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask; // Only objects on this layer can be teleported to

    private GameObject laser; // 2
	private Transform laserTransform; // 3
	private Vector3 hitPoint; // 4
    private bool shouldTeleport;

    // Start is called before the first frame update
    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;
        // 1
        reticle = Instantiate(teleportReticlePrefab);
        // 2
        teleportReticleTransform = reticle.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 1
        if (teleportAction.GetState(handType))
        {
            RaycastHit hit;

            // 2
            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100, teleportMask))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                // 1
                reticle.SetActive(true);
                // 2
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                // 3
                shouldTeleport = true;
            }
        }
        else // 3
        {
            laser.SetActive(false);
            reticle.SetActive(false);
        }

        if (teleportAction.GetStateUp(handType) && shouldTeleport)
        {
            Teleport();
        }
    }
	
	private void ShowLaser(RaycastHit hit)
	{
		// 1
		laser.SetActive(true);
		// 2
		laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
		// 3
		laserTransform.LookAt(hitPoint);
		// 4
		laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
	}

    private void Teleport()
    {
        // 1
        shouldTeleport = false;
        // 2
        reticle.SetActive(false);
        // 3
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        // 4
        difference.y = 0;
        // 5
        cameraRigTransform.position = hitPoint + difference;
    }
}
