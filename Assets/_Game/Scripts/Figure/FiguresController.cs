using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresController : MonoBehaviour
{
    public static System.Action OnFireInvalidFigure;
    public static System.Action<Figure> OnFireValidFigure;

    private List<Figure> m_figure_1_List = new List<Figure>();
    private List<Figure> m_figure_2_List = new List<Figure>();
    private List<Figure> m_figure_3_List = new List<Figure>();
    private List<Figure> m_figure_4_List = new List<Figure>();


    private void OnEnable()
    {
        Figure.OnFigureInitialized += OnFigureInitialized;
        Figure.OnFigureDeath+= OnFigureDeath;
        InputsController.OnFireFigure += OnFireFigure;
    }

    private void OnDisable()
    {
        Figure.OnFigureInitialized -= OnFigureInitialized;
        Figure.OnFigureDeath -= OnFigureDeath;
        InputsController.OnFireFigure -= OnFireFigure;
    }

    private void OnFigureDeath(Figure figure)
    {
        switch (figure.FigureType)
        {
            case FigureType.None:
                return;
            case FigureType.Figure_1:
                if (m_figure_1_List.Contains(figure))
                    m_figure_1_List.Remove(figure);
                break;
            case FigureType.Figure_2:
                if (m_figure_2_List.Contains(figure))
                    m_figure_2_List.Remove(figure);
                break;
            case FigureType.Figure_3:
                if (m_figure_3_List.Contains(figure))
                    m_figure_3_List.Remove(figure);
                break;
            case FigureType.Figure_4:
                if (m_figure_4_List.Contains(figure))
                    m_figure_4_List.Remove(figure);
                break;
            default:
                break;
        }
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


    private void OnFireFigure(FigureType type)
    {
        switch (type)
        {
            case FigureType.None:
                return;
            case FigureType.Figure_1:
                TryFireFigure(m_figure_1_List);
                break;
            case FigureType.Figure_2:
                TryFireFigure(m_figure_2_List);
                break;
            case FigureType.Figure_3:
                TryFireFigure(m_figure_3_List);
                break;
            case FigureType.Figure_4:
                TryFireFigure(m_figure_4_List);
                break;
            default:
                break;
        }
    }


    private void TryFireFigure(List<Figure> figureList)
    {
        if (figureList.Count == 0)
        {
            OnFireInvalidFigure?.Invoke();
            return;
        }

        Figure figureToFire = figureList[0];

        figureList.Remove(figureToFire);

        OnFireValidFigure?.Invoke(figureToFire);
    }

}
