using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject uiPanel;
    private Animator anim;
    private bool _isUiPanelActive = false;

    private string strAppear = "Appear";
    // Start is called before the first frame update
    void Start()
    {
        uiPanel.SetActive(true);
        anim = uiPanel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetSettingUiPanel(_isUiPanelActive);
        KeyDownEsc();
    }

    void SetSettingUiPanel(bool isActive)
    {
        // uiPanel.SetActive(active);
        anim.SetBool(strAppear, isActive);
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
