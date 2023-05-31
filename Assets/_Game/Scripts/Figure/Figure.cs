using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FigureType
{
    None,
    Figure_1,
    Figure_2,
    Figure_3,
    Figure_4
}


public class Figure : MonoBehaviour
{
    public static System.Action<Figure, FigureType> OnFigureInitialized;


    [SerializeField]
    private Rigidbody m_body = null;

    [SerializeField]
    private FigureType m_startFigureType = FigureType.None;

    [SerializeField]
    private FigureData_SO m_figureParameters = null;

    [SerializeField]
    private Transform m_VFXParent = null;

    [SerializeField]
    private VFX_FigureProperty_Controller m_vfxPropertyController = null;


    private FigureType m_figureType;


    private void Start()
    {
        Initialize();
    }


    private void Initialize()
    {
        if (m_startFigureType == FigureType.None)
            m_figureType = RandomEnum<FigureType>.Get(true);
        else
            m_figureType = m_startFigureType;

        SpawnCorrespondingVFX(m_figureType);

        EjectFigure();

        OnFigureInitialized(this, m_figureType);
    }

    private void EjectFigure()
    {
        float heightOffset = 1;

        Vector3 randomPointPositionInCircle = Random.insideUnitCircle;
        randomPointPositionInCircle.z = randomPointPositionInCircle.y;
        randomPointPositionInCircle.y = heightOffset;

        Vector3 direction = randomPointPositionInCircle.normalized;

        m_body.AddForce(direction * m_figureParameters.StartUpImpulseStrength, ForceMode.Impulse);
    }

    private void SpawnCorrespondingVFX(FigureType type)
    {
        GameObject vfxToSpawn = null;

        switch (type)
        {
            case FigureType.None:
                return;
            case FigureType.Figure_1:
                vfxToSpawn = m_figureParameters.m_figure_1_VFX_Prefab;
                break;
            case FigureType.Figure_2:
                vfxToSpawn = m_figureParameters.m_figure_2_VFX_Prefab;
                break;
            case FigureType.Figure_3:
                vfxToSpawn = m_figureParameters.m_figure_3_VFX_Prefab;
                break;
            case FigureType.Figure_4:
                vfxToSpawn = m_figureParameters.m_figure_4_VFX_Prefab;
                break;
            default:
                break;
        }

        if (vfxToSpawn == null)
            return;

        //GameObject instantiatedVFX = Instantiate(vfxToSpawn, m_VFXParent.position, Quaternion.identity, m_VFXParent);
        GameObject instantiatedVFX = Instantiate(vfxToSpawn, m_VFXParent);

        m_vfxPropertyController.VFX = instantiatedVFX.GetComponent<UnityEngine.VFX.VisualEffect>();
    }

}
