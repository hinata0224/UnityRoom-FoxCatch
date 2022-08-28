using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class StartUIController : MonoBehaviour
{
    [SerializeField] private GameObject detail;
    [SerializeField] private GameObject operation;

    private Subject<string> uiivents = new Subject<string>();
    void Start()
    {
        uiivents.Subscribe(msg => UIIventsProcess(msg))
            .AddTo(this);
        uiivents.OnNext("end");
    }

    private void UIIventsProcess(string ivent)
    {
        switch (ivent)
        {
            case "detail":
                detail.SetActive(true);
                operation.SetActive(false);
                break;
            case "operation":
                detail.SetActive(false);
                operation.SetActive(true);
                break;
            case "end":
                detail.SetActive(false);
                operation.SetActive(false);
                break;
                default:
                break;
        }
    }

    public void OpenDetail()
    {
        uiivents.OnNext("detail");
    }

    public void OpenOperation()
    {
        uiivents.OnNext("operation");
    }

    public void CloceWindow()
    {
        uiivents.OnNext("end");
    }
}
