using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smooth = 5f;

    //[SerializeField] private Transform _PosTarget;
    //[SerializeField] private float _turnSpeed; 

    //public Vector3 offset = new Vector3(0, 8, -5);

    private Vector3 vel = Vector3.zero;

   
    void LateUpdate()
    {
        Vector3 targetPosition = _target.TransformPoint(new Vector3(0, 2, -1));

        var vectorPosition = _target.position;
        vectorPosition.y += 6f;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, _smooth * Time.deltaTime);
        transform.forward = Vector3.SmoothDamp(transform.forward, _target.forward, ref vel, _smooth * Time.deltaTime);

        Camera.main.transform.LookAt(vectorPosition);


        //transform.position = Vector3.Lerp(transform.position, _target.position + offset, Time.deltaTime * _smooth);

        //Vector3 dir = _PosTarget.position - transform.position;
        //dir.y = 0;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), _turnSpeed * Time.deltaTime);
        //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //_PosTarget.position = ray.GetPoint(15);
    }
}
