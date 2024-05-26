using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private List<Peaks> allPeaks;
    [SerializeField] private Peaks currentPeak;

    public delegate void AllPeaksDone();
    public static event AllPeaksDone PeaksDone;
    private void OnEnable()
    {
        Peaks.SelectedPeak += GetPeak;
    }
    private void OnDisable()
    {
        Peaks.SelectedPeak -= GetPeak;
    }
    public void GetPeak(Peaks peak)
    {
        if(currentPeak==null)
        {
            currentPeak = peak;
            currentPeak.SetSelectedColor();
            allPeaks.Remove(currentPeak);

            if(allPeaks.Count ==0)
            {
                PeaksDone();
            }
        }
        else
        {
            if(currentPeak.connectedPeaks.Contains(peak))
            {
                //удаляем связи между вершинами
                int A = currentPeak.connectedPeaks.IndexOf(peak);//костыль. Нужен для определения какую линию удалять.
                currentPeak.connectedPeaks.Remove(peak);
                currentPeak.connectionLines.RemoveAt(A);// номер линии соответствует номеру вершины, с которой он коннектится (внутри соответствующих списков каждой вершины).

                A = peak.connectedPeaks.IndexOf(currentPeak);
                peak.connectedPeaks.Remove(currentPeak);
                peak.connectionLines[A].GetComponent<SpriteRenderer>().color = Color.red;
                peak.connectionLines.RemoveAt(A);

                currentPeak=peak;
                currentPeak.SetSelectedColor();
                allPeaks.Remove(currentPeak);

                if (allPeaks.Count == 0)
                {
                    PeaksDone();
                }
            }
        }

    }
}
