using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    [SerializeField] private float screenShakeTime;
    private float screenShakeCounter;

    public IEnumerator ScreenShakeCo()
    {
        CinemachineBasicMultiChannelPerlin noise = GetComponent<CinemachineBasicMultiChannelPerlin>();
        noise.AmplitudeGain = amplitude;
        noise.FrequencyGain = frequency;
        yield return new WaitForSeconds(screenShakeTime);
        noise.AmplitudeGain = 0;
        noise.FrequencyGain = 0;
    }
}
