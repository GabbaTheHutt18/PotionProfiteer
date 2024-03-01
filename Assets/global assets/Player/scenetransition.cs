using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenetransition : MonoBehaviour
{
    [SerializeField] private int SceneIndexValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneIndexValue);
    }
}
