using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace StretchRig
{
    [System.Serializable]
    public struct StretchData : IAnimationJobData
    {
        public Transform upper;
        public Transform lower;
        public Transform tip;


        [SyncSceneToStream] public float intensity;
        [SyncSceneToStream] public float minStretch;
        [SyncSceneToStream] public float maxStretch;

        [SyncSceneToStream] public float enableStretch;
        [SyncSceneToStream] public float enableSquash;
        [SyncSceneToStream] public float ChengeAxisOfStretch_Squash; // 0=X, 1=Y, 2=Z

        public float restLength; 

        [SyncSceneToStream] public float squashAmount;
        [SyncSceneToStream] public float stretchDistribution;

        public bool IsValid()
        {
            return upper != null && lower != null && tip != null;
        }

        public void SetDefaultValues()
        {
            intensity = 1f;
            minStretch = 0.8f;
            maxStretch = 1.4f;

            enableStretch = 1f; // 1.0 = True
            enableSquash = 1f;  // 1.0 = True
            ChengeAxisOfStretch_Squash = 1f;   // 1.0 = Y Axis

            squashAmount = 1f;
            stretchDistribution = 0.5f;
        }
    }
}
