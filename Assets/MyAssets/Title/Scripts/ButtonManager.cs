using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Color _defaultcolor;
    [SerializeField] private Color _selectedcolor;
    [SerializeField] private Button _random;
    [SerializeField] private Button _select;
    [SerializeField] private TMP_InputField _roomidinoutfield;
    // Start is called before the first frame update
    void Start()
    {
        _roomidinoutfield.interactable = false;
    }

    public void ClickRanSelButton(bool isRan)
    {
        _roomidinoutfield.interactable = !isRan;
        if (isRan)
        {
            _random.GetComponent<Image>().color = _selectedcolor;
            _select.GetComponent<Image>().color = _defaultcolor;
        }
        else
        {
            _random.GetComponent<Image>().color = _defaultcolor;
            _select.GetComponent<Image>().color = _selectedcolor;
        }
    }
}
