using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject uiPanel;

    private bool _isUiPanelActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetSettingUiPanel(_isUiPanelActive);
        KeyDownEsc();
    }

    void SetSettingUiPanel(bool active)
    {
        uiPanel.SetActive(active);
    }

    public void KeyDownEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isUiPanelActive = !_isUiPanelActive;
        }
    }

    public void CloseUiPanel()
    {
        _isUiPanelActive = false;
    }
    
    public void OpenUiPanel()
    {
        _isUiPanelActive = true;
    }
}
