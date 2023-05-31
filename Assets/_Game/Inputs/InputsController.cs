using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsController : MonoBehaviour
{
    public static System.Action OnFireFigure_1;
    public static System.Action OnFireFigure_2;
    public static System.Action OnFireFigure_3;
    public static System.Action OnFireFigure_4;


    private InputActionAsset_Player m_playerInputs;


    void Awake()
    {
        m_playerInputs = new InputActionAsset_Player();
        m_playerInputs.ActionMap_Player.Enable();

        m_playerInputs.ActionMap_Player.Figure_1.performed += Figure_1_performed;
        m_playerInputs.ActionMap_Player.Figure_2.performed += Figure_2_performed;
        m_playerInputs.ActionMap_Player.Figure_3.performed += Figure_3_performed;
        m_playerInputs.ActionMap_Player.Figure_4.performed += Figure_4_performed;
    }

    private void OnDestroy()
    {
        m_playerInputs.ActionMap_Player.Figure_1.performed -= Figure_1_performed;
        m_playerInputs.ActionMap_Player.Figure_2.performed -= Figure_2_performed;
        m_playerInputs.ActionMap_Player.Figure_3.performed -= Figure_3_performed;
        m_playerInputs.ActionMap_Player.Figure_4.performed -= Figure_4_performed;
    }

    private void Figure_1_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnFireFigure_1?.Invoke();
    }

    private void Figure_2_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnFireFigure_2?.Invoke();
    }

    private void Figure_3_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnFireFigure_3?.Invoke();
    }

    private void Figure_4_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnFireFigure_4?.Invoke();
    }
}
