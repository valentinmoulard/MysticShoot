using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_figurePrefab = null;

    [SerializeField]
    private Transform m_spawnPosition = null;

    [SerializeField]
    private FigureData_SO m_figureParameters = null;


    private float m_cooldownTimer;
    private bool m_isSpawningInCooldown;
    private bool m_isSpawningEnabled;


    private void OnEnable()
    {
        InputsController.OnStartSpawnFigure += OnStartSpawnFigure;
        InputsController.OnStopSpawnFigure += OnStopSpawnFigure;
    }

    private void OnDisable()
    {
        InputsController.OnStartSpawnFigure -= OnStartSpawnFigure;
        InputsController.OnStopSpawnFigure -= OnStopSpawnFigure;
    }


    private void Update()
    {
        ManageSpawningCooldown();
        ManageSpawning();
    }

    private void ManageSpawning()
    {
        if(m_isSpawningEnabled == true && m_isSpawningInCooldown == false)
        {
            m_isSpawningInCooldown = true;
            m_cooldownTimer = 0f;

            SpawnRandomFigure();
        }
    }

    private void ManageSpawningCooldown()
    {
        if (m_isSpawningInCooldown)
        {
            m_cooldownTimer += Time.deltaTime;

            if (m_cooldownTimer > (1f / m_figureParameters.SpawnSpeed))
                m_isSpawningInCooldown = false;
        }
    }

    private void OnStartSpawnFigure()
    {
        m_isSpawningEnabled = true;
    }

    private void OnStopSpawnFigure()
    {
        m_isSpawningEnabled = false;
    }

    private void SpawnRandomFigure()
    {
        GameObject instantiatedFigure = Instantiate(m_figurePrefab, m_spawnPosition.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        if (m_figureParameters == null)
            return;

        Gizmos.color = Color.cyan;

        float angle = m_figureParameters.SpawnDirectionAngle;
        float halfAngle = angle / 2f;
        Vector3 position_1 = m_spawnPosition.position + Quaternion.Euler(0f, 0f, -halfAngle) * Vector3.up * m_figureParameters.GizmoLineLength;
        Vector3 position_2 = m_spawnPosition.position + Quaternion.Euler(0f, 0f, halfAngle) * Vector3.up * m_figureParameters.GizmoLineLength;

        Gizmos.DrawLine(m_spawnPosition.position, position_1);
        Gizmos.DrawLine(m_spawnPosition.position, position_2);
        Gizmos.DrawLine(position_1, position_2);
    }

}
