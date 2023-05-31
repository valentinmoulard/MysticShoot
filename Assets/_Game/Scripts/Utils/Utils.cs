using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomEnum<T>
{
    static T[] m_Values;
    static RandomEnum()
    {
        var values = System.Enum.GetValues(typeof(T));

        m_Values = new T[values.Length];

        for (int i = 0; i < m_Values.Length; i++)
            m_Values[i] = (T)values.GetValue(i);
    }

    public static T Get(bool ignoreFirst)
    {
        int min = 0;

        if (ignoreFirst)
            min = 1;

        return m_Values[UnityEngine.Random.Range(min, m_Values.Length)];
    }
}


