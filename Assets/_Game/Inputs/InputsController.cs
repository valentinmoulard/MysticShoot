using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsController : MonoBehaviour
{
    public static System.Action<FigureType> OnFireFigure;
    public static System.Action OnStartSpawnFigure;
    public static System.Action OnStopSpawnFigure;


    private InputActionAsset_Player m_playerInputs;


    void Awake()
    {
        m_playerInputs = new InputActionAsset_Player();
        m_playerInputs.ActionMap_Player.Enable();

        m_playerInputs.ActionMap_Player.Figure_1.performed += Figure_1_performed;
        m_playerInputs.ActionMap_Player.Figure_2.performed += Figure_2_performed;
        m_playerInputs.ActionMap_Player.Figure_3.performed += Figure_3_performed;
        m_playerInputs.ActionMap_Player.Figure_4.performed += Figure_4_performed;
        m_playerInputs.ActionMap_Player.Spawn_Figure.performed += Spawn_Figure_performed;
        m_playerInputs.ActionMap_Player.Spawn_Figure.canceled += Spawn_Figure_canceled;
    }

    private void OnDestroy()
    {
        m_playerInputs.ActionMap_Player.Figure_1.performed -= Figure_1_performed;
        m_playerInputs.ActionMap_Player.Figure_2.performed -= Figure_2_performed;
        m_playerInputs.ActionMap_Player.Figure_3.performed -= Figure_3_performed;
        m_playerInputs.ActionMap_Player.Figure_4.performed -= Figure_4_performed;
        m_playerInputs.ActionMap_Player.Spawn_Figure.performed -= Spawn_Figure_performed;
        m_playerInputs.ActionMap_Player.Spawn_Figure.canceled -= Spawn_Figure_canceled;
    }

    private void Figure_1_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnFireFigure?.Invoke(FigureType.Figure_1);
    }

    private void Figure_2_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnFireFigure?.Invoke(FigureType.Figure_2);
    }

    private void Figure_3_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnFireFigure?.Invoke(FigureType.Figure_3);
    }

    private void Figure_4_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnFireFigure?.Invoke(FigureType.Figure_4);
    }

    private void Spawn_Figure_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnStartSpawnFigure?.Invoke();
    }

    private void Spawn_Figure_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnStopSpawnFigure?.Invoke();
    }
}
