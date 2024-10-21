using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarCena : MonoBehaviour
{
    public void CarregarCeninha(string scene) {
        SceneManager.LoadScene(scene);
    }
}
