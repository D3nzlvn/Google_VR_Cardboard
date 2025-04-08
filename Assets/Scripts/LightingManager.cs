using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    // Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    // Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;
    [SerializeField] private float CycleDurationInMinutes = 10f; // Duration in minutes for the full day/night cycle

    private float timePerCycleInSeconds;

    private void Start()
    {
        // Convert cycle duration from minutes to seconds
        timePerCycleInSeconds = CycleDurationInMinutes * 60f;
    }

    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            // Adjust TimeOfDay based on the cycle duration
            TimeOfDay += (Time.deltaTime / timePerCycleInSeconds) * 24f; // Scale to 24-hour cycle
            TimeOfDay %= 24; // Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        // Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        // If the directional light is set then rotate and set its color
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }

    // Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        // Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        // Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}