using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[ExecuteAlways]
public class WarpSpeedEffectScript : MonoBehaviour
{
    [SerializeField]
    private VisualEffect warpSpeedVFX;

    [SerializeField]
    private MeshRenderer warpSpeedMeshRenderer;

    [SerializeField]
    private float rate = 0.02f;

    [SerializeField]
    private float delayShaderStart;

    private bool warpActive = false;

    

    public void ForceStopWarpVFX()
    {
        warpActive = false;
        warpSpeedVFX.Stop();
        warpSpeedVFX.SetFloat("WarpAmount", 0);

        warpSpeedMeshRenderer.sharedMaterial.SetFloat("_Active", 0);
        warpSpeedMeshRenderer.sharedMaterial.SetFloat("_Alpha", 0);
    }

    private void Start()
    {
        warpActive = false;
        warpSpeedVFX.Stop();
        warpSpeedVFX.SetFloat("WarpAmount", 0);

        warpSpeedMeshRenderer.sharedMaterial.SetFloat("_Active", 0);
        warpSpeedMeshRenderer.sharedMaterial.SetFloat("_Alpha", 0);
    }

    public void StopWarpVFX()
    {

    }

   public void StartWarpJump()
    {
        warpActive = !warpActive; 
        StartCoroutine(ActivateParticles());
        StartCoroutine(ActivateShader());
        Debug.Log("Запуск1");
    }

    IEnumerator ActivateParticles()
    {
        Debug.Log("Запуск");
        if (warpActive)
        {
            warpSpeedVFX.Play();

            float amount = warpSpeedVFX.GetFloat("WarpAmount");

            while (amount < 1 && warpActive)
            {
                amount += rate;
                warpSpeedVFX.SetFloat("WarpAmount", amount);
                yield return new WaitForSeconds(0.1f);
            }
        } 
        else
        {
            float amount = warpSpeedVFX.GetFloat("WarpAmount");
            while (amount > 0 && !warpActive)
            {
                amount -= rate;
                warpSpeedVFX.SetFloat("WarpAmount", amount);
                yield return new WaitForSeconds(0.1f);

                if (amount <= 0+rate)
                {
                    amount = 0;
                    warpSpeedVFX.SetFloat("WarpAmount", amount);
                    warpSpeedVFX.Stop();
                }
            }
        }
    }


    IEnumerator ActivateShader()
    {
        if (warpActive)
        {
            yield return new WaitForSeconds(delayShaderStart);
            float amount = warpSpeedMeshRenderer.sharedMaterial.GetFloat("_Active");

            while (amount < 1 && warpActive)
            {
                amount += rate;
                warpSpeedMeshRenderer.sharedMaterial.SetFloat("_Active", amount);
                warpSpeedMeshRenderer.sharedMaterial.SetFloat("_Alpha", amount*3);
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            float amount = warpSpeedMeshRenderer.sharedMaterial.GetFloat("_Active");
            while (amount > 0 && !warpActive)
            {
                amount -= rate;
                warpSpeedMeshRenderer.sharedMaterial.SetFloat("_Active", amount);
                warpSpeedMeshRenderer.sharedMaterial.SetFloat("_Alpha", amount * 3);
                yield return new WaitForSeconds(0.1f);

                if (amount <= 0 + rate)
                {
                    amount = 0;
                    warpSpeedMeshRenderer.sharedMaterial.SetFloat("_Active", amount);
                    warpSpeedMeshRenderer.sharedMaterial.SetFloat("_Alpha", amount * 3);
                }
            }
        }
    }
}
