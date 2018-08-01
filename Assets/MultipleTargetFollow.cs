using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetFollow : MonoBehaviour {

	[SerializeField] List<Transform> targets;
	[SerializeField] float smoothTime = .5f;
	[SerializeField] float minCameraSize = 4f;
	[SerializeField] float maxCameraSize = 7f;
	[SerializeField] float maxBoundsDistance = 25f;

	Vector3 offset;
	Vector3 velocity;

	Camera camera;
    

	void Start(){
		offset = new Vector3(0, 0, transform.position.z);
		camera = GetComponent<Camera>();
		
	}

	void LateUpdate()
    {
        if (targets.Count == 0) { return; }
        Move();
		Zoom();
    }

    private void Zoom()
    {
        float aspectRatio = (float) Screen.width / (float) Screen.height;
        print(aspectRatio);
		float newSize = Mathf.Lerp(minCameraSize, maxCameraSize / aspectRatio * 2, GetGreatestDistance() / maxBoundsDistance);
		camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, newSize, Time.deltaTime);
	}

    private float GetGreatestDistance()
    {
        var bounds = GetBoundsofTargets();
		return bounds.size.x;
    }

    private Bounds GetBoundsofTargets()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
		return bounds;
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        print(transform.position + " to " + newPosition);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    public void AddTarget(Transform target){
		targets.Add(target);
	}

    private Vector3 GetCenterPoint()
    {
        if (targets.Count == 1){
			return targets[0].position;
		}
		var bounds = GetBoundsofTargets();
		return bounds.center;
    }
}
