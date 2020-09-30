using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    public GameObject camera;
    public int speed;

    // Update is called once per frame
    void Update()
    {
        camera.transform.Translate(Vector3.down * Time.deltaTime * speed); //intro scrolls from bottom to top

        StartCoroutine(waitFor());
    }


    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(59); //will modify once we get all credits implemented
        SceneManager.LoadScene("MainMenu"); //goes to the main menu once credits are done
    }
}
