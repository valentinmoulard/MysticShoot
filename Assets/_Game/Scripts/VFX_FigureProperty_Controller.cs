using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFX_FigureProperty_Controller : MonoBehaviour
{
    [SerializeField]
    private VisualEffect m_VFX = null;

    [SerializeField]
    private string m_isExplodingPropertyName = "IsExploding";

    [SerializeField]
    private string m_isDeadPropertyName = "IsDead";

    [SerializeField]
    private string m_parentVelocityPropertyName = "ParentVelocity";


    private bool m_isExploding;
    private bool m_isDead;


    public VisualEffect VFX { get => m_VFX; set => m_VFX = value; }


    private void Start()
    {
        m_isExploding = false;
        m_isDead = false;

        if (m_VFX.HasBool(m_isExplodingPropertyName))
            m_VFX.SetBool(m_isExplodingPropertyName, m_isExploding);

        if (m_VFX.HasBool(m_isDeadPropertyName))
            m_VFX.SetBool(m_isDeadPropertyName, m_isDead);
    }

    public void SetParentVelocity(Vector3 parentVelocity)
    {
        if (m_VFX.HasVector3(m_parentVelocityPropertyName))
            m_VFX.SetVector3(m_parentVelocityPropertyName, parentVelocity);
    }

    public void Kill()
    {
        if (m_VFX == null)
            return;

        m_isDead = true;

        if (m_VFX.HasBool(m_isDeadPropertyName))
            m_VFX.SetBool(m_isDeadPropertyName, m_isDead);
    }

    public void Explode()
    {
        if (m_VFX == null)
            return;

        m_isExploding = true;

        if (m_VFX.HasBool(m_isExplodingPropertyName))
            m_VFX.SetBool(m_isExplodingPropertyName, m_isExploding);
    }

}
