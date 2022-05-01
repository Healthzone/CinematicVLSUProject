using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyboxesAtRuntime : MonoBehaviour
{


    public Material[] skyboxes;

    public MeshRenderer WarpCone;


    public void StartChangeSkybox (int index)
    {
        StartCoroutine(ChangeSkybox(index));
    }


    IEnumerator ChangeSkybox(int index)
    {

        RenderSettings.skybox = skyboxes[index];
        WarpCone.sharedMaterial.SetFloat("_Alpha", 1);
        DynamicGI.UpdateEnvironment();
        yield return 1;
    }
}
