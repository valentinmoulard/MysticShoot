using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FigureParameters", order = 1)]
public class FigureData_SO : ScriptableObject
{
    [Header("References")]
    public GameObject m_figure_1_VFX_Prefab = null;
    public GameObject m_figure_2_VFX_Prefab = null;
    public GameObject m_figure_3_VFX_Prefab = null;
    public GameObject m_figure_4_VFX_Prefab = null;


    [Header("Stats")]
    public float StartUpImpulseStrength = 5f;
    public float SpawnDirectionAngle = 30f;
    public float DelayBeforeDestructionAfterFire = 2f;
    public float SpawnSpeed = 1f;

    [Header("Gizmos")]
    public float GizmoLineLength = 5f;


}
