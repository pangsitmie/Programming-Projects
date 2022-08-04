using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }
    IEnumerator LoadLevel(int levelindex)
    {
        //start the animation
        transition.SetTrigger("Start");
        //wait for certain time of second
        yield return new WaitForSeconds(transitionTime);
        //load scene
        SceneManager.LoadScene(levelindex);

    }
    public void switchScene(int idx)
    {
         SceneManager.LoadScene(idx);
    }
    public void loadPreviousScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));

    }
}

