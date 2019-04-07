using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Selectable[] options;

    public void PanelManagerM(int pos)
    {
        Input.ResetInputAxes();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(pos == i);
            if (pos == i)
            {
                options[i].Select();
            }
        }
    }

    void Start()
    {
        PanelManagerM(0);
    }


}
