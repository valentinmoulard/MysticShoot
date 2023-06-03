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
    public static System.Action<Figure> OnFigureDeath;

    [SerializeField]
    private GameObject m_rootObject = null;

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
    private bool m_isDead;

    public FigureType FigureType { get => m_figureType; }


    private void OnEnable()
    {
        FiguresController.OnFireValidFigure += OnFireValidFigure;
    }

    private void OnDisable()
    {
        FiguresController.OnFireValidFigure -= OnFireValidFigure;
    }


    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        CheckDeathCondition();
        UpdateParentVelocity();
    }

    private void UpdateParentVelocity()
    {
        m_vfxPropertyController.SetParentVelocity(m_body.velocity);
    }

    private void CheckDeathCondition()
    {
        if (m_isDead)
            return;

        if (m_body.position.y < m_figureParameters.m_yPositionDeathCondition)
        {
            Kill();
        }
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

    private void OnFireValidFigure(Figure figure)
    {
        if(figure == this)
        {
            FireFigure();
        }
    }

    private void Kill()
    {
        m_isDead = true;

        m_body.isKinematic = true;
        m_vfxPropertyController.Kill();
        OnFigureDeath?.Invoke(this);

        Destroy(m_rootObject, m_figureParameters.DelayBeforeDestructionAfterFire);
    }

    private void FireFigure()
    {
        m_vfxPropertyController.Explode();
        
        m_body.isKinematic = true;

        Destroy(m_rootObject, m_figureParameters.DelayBeforeDestructionAfterFire);
    }

    private void EjectFigure()
    {
        float randomSpawnAngle = Random.Range(-m_figureParameters.SpawnDirectionAngle / 2f, m_figureParameters.SpawnDirectionAngle / 2f);

        Vector3 spawnDirection = Quaternion.Euler(0f, 0f, randomSpawnAngle) * Vector3.up;
        
        m_body.AddForce(spawnDirection * m_figureParameters.StartUpImpulseStrength, ForceMode.Impulse);
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

        GameObject instantiatedVFX = Instantiate(vfxToSpawn, m_VFXParent);

        m_vfxPropertyController.VFX = instantiatedVFX.GetComponent<UnityEngine.VFX.VisualEffect>();
    }

}