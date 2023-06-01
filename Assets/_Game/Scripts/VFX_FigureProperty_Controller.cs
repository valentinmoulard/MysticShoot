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

    private bool m_isExploding;

    public VisualEffect VFX { get => m_VFX; set => m_VFX = value; }

    private void Start()
    {
        m_isExploding = false;

        if (m_VFX.HasBool(m_isExplodingPropertyName))
            m_VFX.SetBool(m_isExplodingPropertyName, m_isExploding);
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
