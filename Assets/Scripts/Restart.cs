using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string NextLevel;

    void OnMouseDown()
    {
        transform.position += Vector3.down * 0.1f;

        SceneManager.LoadScene(NextLevel);
    }
}
