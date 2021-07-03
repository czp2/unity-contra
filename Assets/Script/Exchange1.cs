using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exchange1 : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    void OnClick(){
        SceneManager.LoadScene("Game");
        Time.timeScale=1;
    }
}
