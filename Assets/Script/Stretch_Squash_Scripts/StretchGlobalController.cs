using UnityEngine;
using StretchRig;

public class StretchGlobalController : MonoBehaviour
{
    [Header("Assign All Stretch Constraint Rig Here")]
    public StretchConstraint[] allRigs;

    [Header("Global Settings")]
    [Range(0f, 1f)] public float intensity = 1f;
    [Range(0f, 1f)] public float squashAmount = 1f;       // Volume control
    [Range(0f, 1f)] public float stretchDistribution = 1f; // Even/Uneven

    [Header("Limits")]
    public float minStretch = 0.8f;
    public float maxStretch = 1.4f;

    [Header("Toggles")]
    public bool enableStretch = true;
    public bool enableSquash = true;

    [Header("Axis (0 = X, 1 = Y, 2 = Z)")]
    public int ChengeAxisOfStretch_Squash = 1;


    void OnValidate()
    {
        SyncValues();
    }

    void Update()
    {
        SyncValues();
    }

    void SyncValues()
    {
        if (allRigs == null) return;

        foreach (var limb in allRigs)
        {
            if (limb == null) continue;

            var data = limb.data;

            data.intensity = intensity;
            data.squashAmount = squashAmount;
            data.stretchDistribution = stretchDistribution;

            data.minStretch = minStretch;
            data.maxStretch = maxStretch;

            data.enableStretch = enableStretch ? 1f : 0f; //enableStretch;
            data.enableSquash = enableSquash ? 1f : 0f; //enableSquash;

            data.ChengeAxisOfStretch_Squash = ChengeAxisOfStretch_Squash;

            limb.data = data;
        }
    }


    [ContextMenu("Reset All Positions")]
    public void ResetAllPositions()
    {
        if (allRigs == null) return;
        foreach (var limb in allRigs)
        {
            if (limb != null) limb.ResetToStart();
        }
    }
}