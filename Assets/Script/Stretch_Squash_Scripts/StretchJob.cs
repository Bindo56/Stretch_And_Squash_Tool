using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace StretchRig
{
    public struct StretchJob : IWeightedAnimationJob
    {
        public ReadWriteTransformHandle upper;
        public ReadWriteTransformHandle lower;
        public ReadOnlyTransformHandle tip;

        public FloatProperty jobWeight { get; set; }

        //usig FloatProperty for live editing in Editor
        public FloatProperty restLength;
        public FloatProperty intensity;
        public FloatProperty minStretch;
        public FloatProperty maxStretch;
        public FloatProperty squashAmount;
        public FloatProperty stretchDistribution;

        public FloatProperty enableStretch; // 1.0 = True, 0.0 = False
        public FloatProperty enableSquash;
        public FloatProperty ChengeAxisOfStretch_Squash;   // 0.0, 1.0, 2.0

        public void ProcessRootMotion(AnimationStream stream) { }

        public void ProcessAnimation(AnimationStream stream)
        {
            float w = jobWeight.Get(stream);

            float _enableStretch = enableStretch.Get(stream);

            if (w <= 0f || _enableStretch < 0.5f) 
            {
                upper.SetLocalScale(stream, Vector3.one);
                lower.SetLocalScale(stream, Vector3.one);
                return;
            }

            float _intensity = intensity.Get(stream);
            float _minStretch = minStretch.Get(stream);
            float _maxStretch = maxStretch.Get(stream);
            float _squashAmt = squashAmount.Get(stream);
            float _distrib = stretchDistribution.Get(stream);
            float _restLen = restLength.Get(stream);
            float _enableSquash = enableSquash.Get(stream);
            int _axis = Mathf.RoundToInt(ChengeAxisOfStretch_Squash.Get(stream));


            Vector3 upperPos = upper.GetPosition(stream);
            Vector3 tipPos = tip.GetPosition(stream);
            float currentDist = Vector3.Distance(upperPos, tipPos);

            if (_restLen <= Mathf.Epsilon) return;

            float rawRatio = currentDist / _restLen;  
            float finalRatio = Mathf.Lerp(1f, rawRatio, _intensity);
            finalRatio = Mathf.Clamp(finalRatio, _minStretch, _maxStretch);

            float volumePower = 0.5f * _squashAmt;
            float squash = (_enableSquash > 0.5f) ? 1f / Mathf.Pow(finalRatio, volumePower) : 1f;

            float upperStretch = Mathf.Lerp(1f, finalRatio, (1f - _distrib) * 2f);
            float lowerStretch = Mathf.Lerp(1f, finalRatio, _distrib * 2f);

            upperStretch = Mathf.Max(0.1f, upperStretch);
            lowerStretch = Mathf.Max(0.1f, lowerStretch);

            Vector3 upperScale, lowerScale;

            if (_axis == 0) // X 
            {
                upperScale = new Vector3(upperStretch, squash, squash);
                lowerScale = new Vector3(lowerStretch, squash, squash);
            }
            else if (_axis == 1) // Y 
            {
                upperScale = new Vector3(squash, upperStretch, squash);
                lowerScale = new Vector3(squash, lowerStretch, squash);
            }
            else // Z 
            {
                upperScale = new Vector3(squash, squash, upperStretch);
                lowerScale = new Vector3(squash, squash, lowerStretch);
            }

            upper.SetLocalScale(stream, upperScale);
            lower.SetLocalScale(stream, lowerScale);
        }
    }
}
