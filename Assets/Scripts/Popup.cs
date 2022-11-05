using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public int waitTime = 10;
    public Button close;
    public Image timeBar;

    private void Start() {
        close.onClick.AddListener(() => {
            Debug.Log("addd");
            StartCoroutine(AnimateClose());
        });
    }
    public virtual IEnumerator AnimateClose()
    {
        foreach (AnimationClip animationClip in gameObject.GetComponent<Animator>().runtimeAnimatorController.animationClips)
        {
            if (animationClip.name == "Close")
            {
                GetComponent<Animator>().Play(animationClip.name);
                yield return new WaitForSeconds(animationClip.length);
            }
        }
        Destroy(gameObject);
    }

    public virtual IEnumerator AnimateStart()
    {
        foreach (AnimationClip animationClip in gameObject.GetComponent<Animator>().runtimeAnimatorController.animationClips)
        {
            Debug.Log(animationClip.name);
            if (animationClip.name == "Start")
            {
                Debug.Log(animationClip.length);
                GetComponent<Animator>().Play(animationClip.name);
                yield return new WaitForSeconds(animationClip.length);
            }
        }
    }
}
