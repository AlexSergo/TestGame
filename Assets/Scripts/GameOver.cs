using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
        private int                        _hardLevel = 1;
       [SerializeField] private UnityEvent OnLevelChanged;
       [SerializeField] private UnityEvent OnGameFinished;

       private Cell[]                      _cells;


       public IEnumerator FinishLevel()
       {
           ParticleSystem[] stars = GetComponentsInChildren<ParticleSystem>();
           stars[0].Play();
           stars[1].Play();
           yield return new WaitForSeconds(0.5f);
           if (_hardLevel < 3)
           {
                OnLevelChanged?.Invoke();
                _hardLevel++;
           }
           else
           {
               _hardLevel = 1;
               BlockCells();
               OnGameFinished?.Invoke();
           }
       }

       private void BlockCells()
       {
          _cells = FindObjectsOfType<Cell>();
          for (int i = 0; i < _cells.Length; i++)
               _cells[i].GetComponent<BoxCollider2D>().enabled = false;
       }
}
