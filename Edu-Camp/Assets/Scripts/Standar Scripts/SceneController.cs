using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    Animator SceneAnimator;
    string sceneAnimatorTag = "SceneAnimator";
    int last_scene_entered = 0;

    void Start()
    {
        SceneAnimator = GameObject.FindGameObjectWithTag(sceneAnimatorTag).GetComponent<Animator>();
    }

    IEnumerator LoadSceneWithAnimation(string sceneName)
    {
        last_scene_entered = SceneManager.GetActiveScene().buildIndex;

        SceneAnimator.SetTrigger("CloseSceneEvent");
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }
    
    public void goToScene(string sceneName)
    {
        StartCoroutine(LoadSceneWithAnimation(sceneName));
    }

    public void go_to_after_scene()
    {
        SceneManager.LoadScene(last_scene_entered);
    }
}
