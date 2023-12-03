using System.Collections;
using UnityEngine;
public class SkyboxChanger : MonoBehaviour
{
    public Material morningMaterial;
    public Material sunsetMaterial;
    public Material nightMaterial;

    public float transitionDuration = 5.0f;

    private Material currentMaterial;

    private void Start()
    {
        currentMaterial = RenderSettings.skybox;

        // Start changing skybox materials
        StartCoroutine(ChangeSkyboxOverTime());
    }

    IEnumerator ChangeSkyboxOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(transitionDuration);

            // Choose next material
            if (currentMaterial == morningMaterial)
                currentMaterial = sunsetMaterial;
            else if (currentMaterial == sunsetMaterial)
                currentMaterial = nightMaterial;
            else
                currentMaterial = morningMaterial;

            RenderSettings.skybox = currentMaterial;
        }
    }
}
