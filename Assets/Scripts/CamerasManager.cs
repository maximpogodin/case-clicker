using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CamerasManager : MonoBehaviour
{
    public Camera MainCamera;
    public Camera ChestCamera;
    private Text _btnText;
    private bool _isMainCamera;
    public TransitionManager TransitionManager;

    private void Awake()
    {
        _btnText = GetComponentInChildren<Text>();
        _isMainCamera = true;
        GetComponent<Button>().onClick.AddListener(ShowCamera);

        MainCamera.enabled = true;
        ChestCamera.enabled = false;
    }

    public void ShowCamera()
    {
        _isMainCamera = !_isMainCamera;
        TransitionManager.RunTransition(!_isMainCamera);

        _btnText.text = _isMainCamera ? "Go to chest" : "Go to stone";    
    }

    public void ReplaceCamera()
    {
        MainCamera.enabled = _isMainCamera;
        ChestCamera.enabled = !_isMainCamera;
    }
}