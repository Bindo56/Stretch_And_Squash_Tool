using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace StretchRig
{
    [AddComponentMenu("Animation Rigging/Stretch Constraint")]
    public class StretchConstraint : RigConstraint<StretchJob, StretchData, StretchBinder>
    {

        private Vector3 m_StartPos;
        private Quaternion m_StartRot;
        private bool m_HasStarted = false;
        void Start()
        {
            if (data.tip != null)
            {
                m_StartPos = data.tip.position;
                m_StartRot = data.tip.rotation;
                m_HasStarted = true;
            }
        }

        [ContextMenu("Reset IK Handle")]
        public void ResetToStart()
        {
            if (data.tip == null) return;

            if (m_HasStarted)
            {
                data.tip.position = m_StartPos;
                data.tip.rotation = m_StartRot;
              //  Debug.Log($"{name}: Reset Tip to start position.");
            }
            else
            {
                Debug.LogWarning("Game is Not started");
            }
        }

        void OnValidate()
        {
            if (data.upper != null && data.tip != null)
                data.restLength = Vector3.Distance(data.upper.position, data.tip.position); //remove this line if you don't want auto rest length update in editor
        }

        [ContextMenu("Recalculate Rest Length")]
        void Recalculate()
        {
            if (data.upper != null && data.tip != null)
            {
                data.restLength = Vector3.Distance(data.upper.position, data.tip.position);
                Debug.Log($"{name}: Rest length updated = {data.restLength:F3}");
            }
        }

    }
}
