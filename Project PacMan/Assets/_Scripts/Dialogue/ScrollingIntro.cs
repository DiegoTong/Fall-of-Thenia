using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollingIntro : MonoBehaviour
{
    public GameObject camera;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        camera.transform.Translate(Vector3.down * Time.deltaTime * speed); //intro scrolls from bottom to top

        StartCoroutine(waitFor());


        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //grabs the next scene
        }
    }


    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(75);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //grabs the next scene
    }



}
