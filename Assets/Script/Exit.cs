using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    void OnClick(){
        Application.Quit();
    }
}
