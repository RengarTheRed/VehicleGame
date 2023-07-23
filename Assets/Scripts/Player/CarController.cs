using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial followed https://www.youtube.com/watch?v=Z4HA8zJhGEk
public class CarControler : MonoBehaviour
{
    //Input Variables
    private float _horizontalInput = 0;
    private float _verticalInput = 0;
    private bool _isBraking;
    
    //Car Variables
    private float _enginePower = 1000;
    private float _brakeForce = 30000;
    private float _currentBraking;
    private float _steeringAngle;
    private float _maxSteeringAngle = 30;

    //Wheel Collider
    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider backLeftCollider;
    [SerializeField] private WheelCollider backRightCollider;
    
    //Wheel Transform
    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform backLeftTransform;
    [SerializeField] private Transform backRightTransform;
    private void FixedUpdate()
    {
        ReadInput();
        ApplyEngine();
        ApplySteering();
        RotateTyres();
    }

    private void ReadInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _isBraking = Input.GetKey(KeyCode.Space);
    }

    private void ApplyEngine()
    {
        backLeftCollider.motorTorque = _verticalInput * _enginePower;
        backRightCollider.motorTorque = _verticalInput * _enginePower;
        frontLeftCollider.motorTorque = _verticalInput * _enginePower;
        frontRightCollider.motorTorque = _verticalInput * _enginePower;
        
        if (_isBraking)
        {
            _currentBraking = _brakeForce;
        }
        else
        {
            _currentBraking = 0;
        }
        ApplyBraking();
    }

    private void ApplyBraking()
    {
        frontLeftCollider.brakeTorque = _currentBraking;
        frontRightCollider.brakeTorque = _currentBraking;
        backLeftCollider.brakeTorque = _currentBraking;
        backRightCollider.brakeTorque = _currentBraking;
    }

    private void ApplySteering()
    {
        _steeringAngle = _maxSteeringAngle * _horizontalInput;
        frontLeftCollider.steerAngle = _steeringAngle;
        frontRightCollider.steerAngle = _steeringAngle;
    }

    private void RotateTyres()
    {
        UpdateSingleWheel(frontLeftCollider, frontLeftTransform);
        UpdateSingleWheel(frontRightCollider, frontRightTransform);
        UpdateSingleWheel(backLeftCollider, backLeftTransform);
        UpdateSingleWheel(backRightCollider, backRightTransform);
    }

    private void UpdateSingleWheel(WheelCollider wCollide, Transform wTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wCollide.GetWorldPose(out pos, out rot);
        wTransform.rotation = rot;
        wTransform.position = pos;
    }
}