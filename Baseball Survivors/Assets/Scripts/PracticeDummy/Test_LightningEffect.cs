using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Test_LightningEffect : MonoBehaviour
{
    [SerializeField] private GameObject lightningWindowLight;
    [SerializeField] private GameObject lightningCastingLight;
    [SerializeField] private GameObject globalVolumeRef;
    private Light2D globalVolume;
    private bool lightningEffectStarted;

    private void Awake()
    {
        globalVolume = globalVolumeRef.GetComponent<Light2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            StartCoroutine(LightningCo());
        }
    }

    IEnumerator LightningCo()
    {
        if(!lightningEffectStarted)
            lightningEffectStarted = true;

        float defaultGlobalVol = globalVolume.intensity;

        //Light up
        lightningWindowLight.SetActive(true);
        lightningCastingLight.SetActive(true);
        AudioManager.instance.PlaySFX(3);
        globalVolume.intensity = .8f;
        yield return new WaitForSeconds(0.2f);

        //Dark(normal)
        lightningWindowLight.SetActive(false);
        lightningCastingLight.SetActive(false);
        globalVolume.intensity = defaultGlobalVol;
        yield return new WaitForSeconds(0.1f);

        //Light up
        lightningWindowLight.SetActive(true);
        lightningCastingLight.SetActive(true);
        globalVolume.intensity = .8f;
        yield return new WaitForSeconds(0.2f);

        ////Dark(normal)
        //lightning.SetActive(false);
        //globalVolume.intensity = defaultGlobalVol;       
        //yield return new WaitForSeconds(1f);

        ////Light up
        //lightning.SetActive(true);
        //globalVolume.intensity = .8f;
        //yield return new WaitForSeconds(0.6f);

        //Dark(normal)
        lightningWindowLight.SetActive(false);
        lightningCastingLight.SetActive(false);
        globalVolume.intensity = defaultGlobalVol;

        lightningEffectStarted = false;
    }
}
