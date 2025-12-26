using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace StretchRig
{
    public class StretchBinder : AnimationJobBinder<StretchJob, StretchData>
    {
        public override StretchJob Create(Animator animator, ref StretchData data, Component component)
        {
            StretchJob job = new StretchJob();

            job.upper = ReadWriteTransformHandle.Bind(animator, data.upper);
            job.lower = ReadWriteTransformHandle.Bind(animator, data.lower);
            job.tip = ReadOnlyTransformHandle.Bind(animator, data.tip);

            job.intensity = FloatProperty.Bind(animator, component, "m_Data.intensity");
            job.minStretch = FloatProperty.Bind(animator, component, "m_Data.minStretch");
            job.maxStretch = FloatProperty.Bind(animator, component, "m_Data.maxStretch");
            job.squashAmount = FloatProperty.Bind(animator, component, "m_Data.squashAmount");
            job.stretchDistribution = FloatProperty.Bind(animator, component, "m_Data.stretchDistribution");
            job.restLength = FloatProperty.Bind(animator, component, "m_Data.restLength");

            job.enableStretch = FloatProperty.Bind(animator, component, "m_Data.enableStretch");
            job.enableSquash = FloatProperty.Bind(animator, component, "m_Data.enableSquash");
            job.ChengeAxisOfStretch_Squash = FloatProperty.Bind(animator, component, "m_Data.ChengeAxisOfStretch_Squash");

            return job;
        }

        public override void Update(StretchJob job, ref StretchData data)
        {
            //UpdateJob(ref job, ref data);
        }
        public override void Destroy(StretchJob job) 
        { 
        }

        void UpdateJob(ref StretchJob job, ref StretchData data)
        {
          
            /*Debug.Log(data.intensity + " :intensity :BinderScript");
            Debug.Log(data.ChengeAxisOfStretch_Squash + " :axis  :BinderScript");
            Debug.Log(data.squashAmount + " :squashAmount  :BinderScript");
            Debug.Log(data.stretchDistribution + " :stretchDistribution  :BinderScript");*/
          //  Debug.Log(data.restLength + "restLength");
           /* Debug.Log(data.enableSquash + " :enableSquash  :BinderScript");
            Debug.Log(data.enableStretch + " :enableStretch :BinderScript");*/
          

        }
    }
}
