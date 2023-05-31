using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureSpawner : MonoBehaviour
{
    public static System.Action<GameObject> OnFigureInstantiated;


    [SerializeField]
    private GameObject m_figurePrefab = null;

    [SerializeField]
    private Transform m_spawnPosition = null;

    [SerializeField]
    private KeyCode m_spawnRandomFigureKeycode;


    private void Update()
    {
        if (Input.GetKeyDown(m_spawnRandomFigureKeycode))
            SpawnRandomFigure();
    }


    private void SpawnRandomFigure()
    {
        GameObject instantiatedFigure = Instantiate(m_figurePrefab, m_spawnPosition.position, Quaternion.identity);

        //OnFigureInstantiated?.Invoke(instantiatedFigure);
    }





}
