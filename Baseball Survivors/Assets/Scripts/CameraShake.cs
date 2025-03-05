using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] CinemachineCamera vCam;
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    [SerializeField] private float screenShakeTime;
    private float screenShakeCounter;
    private bool isShaking;

    public IEnumerator ScreenShakeCo()
    {
        isShaking = true;
        CinemachineBasicMultiChannelPerlin noise = vCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
        noise.AmplitudeGain = amplitude;
        noise.FrequencyGain = frequency;
        yield return new WaitForSeconds(screenShakeTime);
        noise.AmplitudeGain = 0;
        noise.FrequencyGain = 0;
        isShaking = false;
    }

    public void StopCameraShake()
    {
        CinemachineBasicMultiChannelPerlin noise = vCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
        noise.AmplitudeGain = 0;
        noise.FrequencyGain = 0;
        isShaking = false;
    }
}
