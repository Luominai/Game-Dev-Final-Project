using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Transition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(24);
        SceneManager.LoadScene("MenuScene");
    }
}
