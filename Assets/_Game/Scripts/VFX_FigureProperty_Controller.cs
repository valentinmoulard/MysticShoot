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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_VFX == null)
                return;

            m_isExploding = !m_isExploding;

            if (m_VFX.HasBool(m_isExplodingPropertyName))
                m_VFX.SetBool(m_isExplodingPropertyName, m_isExploding);
        }
    }
}
