using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    private int chachFox = 0;
    [SerializeField] private int maxFox = 3;

    [SerializeField] private Text value;

    [SerializeField] private PlayerController player;
    [SerializeField] private SceneManger scene;
    void Start()
    {
        SetText();
    }

    void Update()
    {
        GetFoxValue();
        SetText();
        if(chachFox >= maxFox)
        {
            scene.GoClear();
        }
    }

    private void GetFoxValue()
    {
        chachFox = player.GetChachFox();
    }

    private void SetText()
    {
        value.text = "‚ ‚Æ" + (maxFox - chachFox) + "•C";
    }
}
