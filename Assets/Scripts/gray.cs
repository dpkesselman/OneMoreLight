using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gray : MonoBehaviour
{
    public GameObject color;

    void Update()
    {
        HideObject();
    }

    public void ShowObject()
    {
        color.SetActive(true);
    }

    public void HideObject()
    {
        color.SetActive(false);
    }
}
