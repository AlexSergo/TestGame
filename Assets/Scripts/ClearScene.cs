using UnityEngine;

public class ClearScene : MonoBehaviour
{
    public void Clear()
    {
        var cells = FindObjectsOfType<Cell>();
        for (int i = 0; i < cells.Length; i++)
            Destroy(cells[i].gameObject);
    }
}
