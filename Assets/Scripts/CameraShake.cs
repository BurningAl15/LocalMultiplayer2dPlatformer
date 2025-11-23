using System;
using UnityEngine;
using Unity.Cinemachine;

[Serializable]
public class CameraShakeData
{
    public CinemachineComponentBase _cinemachineComponent;
    public float _shakeTimer;
}

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    public CameraShakeData cameraShakeData_p1;
    public CameraShakeData cameraShakeData_p2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (cameraShakeData_p1._shakeTimer > 0f)
        {
            cameraShakeData_p1._shakeTimer -= Time.deltaTime;
            if (cameraShakeData_p1._shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    cameraShakeData_p1._cinemachineComponent.GetComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.AmplitudeGain = 0f;
            }
        }
        
        if (cameraShakeData_p2._shakeTimer > 0f)
        {
            cameraShakeData_p2._shakeTimer -= Time.deltaTime;
            if (cameraShakeData_p2._shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    cameraShakeData_p2._cinemachineComponent.GetComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.AmplitudeGain = 0f;
            }
        }
    }

    public void ShakeCamera_p1(float intensity, float time)
    {
        CinemachineComponentBase baseComponent = cameraShakeData_p1._cinemachineComponent;
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
            baseComponent.GetComponent<CinemachineBasicMultiChannelPerlin>();
        
        cinemachineBasicMultiChannelPerlin.AmplitudeGain = intensity;
        cameraShakeData_p1._shakeTimer = time;
    }

    public void ShakeCamera_p2(float intensity, float time)
    {
        CinemachineComponentBase baseComponent = cameraShakeData_p2._cinemachineComponent;
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
            baseComponent.GetComponent<CinemachineBasicMultiChannelPerlin>();
        
        cinemachineBasicMultiChannelPerlin.AmplitudeGain = intensity;
        cameraShakeData_p2._shakeTimer = time;
    }
}
