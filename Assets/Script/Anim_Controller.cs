using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Anim_Controller : MonoBehaviour
{

    [SerializeField] Animator anim;

    [Header("Rig Control")]
    [SerializeField] RigBuilder rigBuilder;


    private readonly string[] danceBools =
{
      //  "Dance1",
        "Dance2",
/*        "Dance3",
        "Dance4"*/
    };

    public void PlayWalk()
    {
        ResetAllBools();
        anim.SetBool("Walk", true);

        SetRigLayer(false);
        StartCoroutine(StopWalk());
    }

    IEnumerator StopWalk()
    {
        yield return new WaitForSeconds(3f);
        ResetAllBools();
        SetRigLayer(true);
    }
    public void PlayRandomDance()
    {
        ResetAllBools();

        int random = Random.Range(0, danceBools.Length);
        anim.SetBool(danceBools[random], true);

        SetRigLayer(false);
    }

    public void OnAnimationEnded()
    {
        ResetAllBools();
        SetRigLayer(true);
    }
    void ResetAllBools()
    {
        anim.SetBool("Walk", false);

        foreach (var d in danceBools)
            anim.SetBool(d, false);
    }

    void SetRigLayer(bool enable)
    {
        rigBuilder.layers[0].active = enable;
        rigBuilder.layers[1].active = enable;
      //  rigBuilder.Build();
    }

}
