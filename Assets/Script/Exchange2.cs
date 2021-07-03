using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exchange2 : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    void OnClick(){
        SceneManager.LoadScene("GameStart");
        Time.timeScale=1;
    }
}
