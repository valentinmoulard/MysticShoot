using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresController : MonoBehaviour
{

    private List<Figure> m_figure_1_List = new List<Figure>();
    private List<Figure> m_figure_2_List = new List<Figure>();
    private List<Figure> m_figure_3_List = new List<Figure>();
    private List<Figure> m_figure_4_List = new List<Figure>();


    private void OnEnable()
    {
        Figure.OnFigureInitialized += OnFigureInitialized;
    }

    private void OnDisable()
    {
        Figure.OnFigureInitialized -= OnFigureInitialized;
    }

    private void OnFigureInitialized(Figure figure, FigureType type)
    {
        switch (type)
        {
            case FigureType.None:
                return;
            case FigureType.Figure_1:
                m_figure_1_List.Add(figure);
                break;
            case FigureType.Figure_2:
                m_figure_2_List.Add(figure);
                break;
            case FigureType.Figure_3:
                m_figure_3_List.Add(figure);
                break;
            case FigureType.Figure_4:
                m_figure_4_List.Add(figure);
                break;
            default:
                break;
        }
    }
}
