using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Threading;

public class LevelGenerate : MonoBehaviour
{
    [SerializeField] private Text _taskText; 
    private int           _cellCount;
    private const string  PATH_TO_CELL = "Prefabs/Cell";
    private string[]      _pathsToLetters = new string [] {"Images/LC_letters_1", "Images/LC_letters_2", "Images/LC_letters_3",
                                                      "Images/SD_NC_Cookies_1", "Images/SD_NC_Cookies_2", "Images/SD_NC_Cookies_3"};
    private List<List<Sprite>> _allKindOfSymbols;
    private List<Symbol> _symbols;
    private GameObject    _cell;
    private const float   CELL_SIZE = 2;  
    private System.Random random = new System.Random();
    private List<string> _usedSymbols;


    private void Start()
    {
        StartGame();
    }

    public void RestartGame()
    {
        StartCoroutine(WaitingForUpdateFrameAndStartGame());
    }

    private IEnumerator WaitingForUpdateFrameAndStartGame()
    {
        yield return new WaitForEndOfFrame();
        StartGame();
    }

    private void StartGame()
    {
        InitLettersAndNumbers();

        _cellCount = 3;
        _symbols = new List<Symbol>();
        _cell = Resources.Load<GameObject>(PATH_TO_CELL);
        _usedSymbols = new List<string>();
        _taskText.text = "";

        Generate();
    }

    public void StartNextLevel()
    {
        InitLettersAndNumbers();
        ClearGameMap();
        if (_cellCount == 9) return;

        _cellCount += 3;
        _symbols.Clear();

         Generate();
    }

    private void Generate()
    {
        CellsGenerate();
        _taskText.text = "Find " + GenerateWinSymbol();
    }

    private void ClearGameMap()
    {
        var cells = FindObjectsOfType<Cell>();
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i].gameObject.SetActive(false);
            Destroy(cells[i].gameObject);
        }
    }

    private void InitLettersAndNumbers()
    {
        _allKindOfSymbols = new List<List<Sprite>>();
        _allKindOfSymbols.Add(new List<Sprite>());    // letters
        _allKindOfSymbols.Add(new List<Sprite>());   // numbers

        for (int i = 0; i < _pathsToLetters.Length; i++)
        {
           var sprites = Resources.LoadAll<Sprite>(_pathsToLetters[i]);
           for (int spriteNumber = 0; spriteNumber < sprites.Length; spriteNumber++)
           {
                if (i < _pathsToLetters.Length / 2)
                    _allKindOfSymbols[0].Add(sprites[spriteNumber]);
                else
                    _allKindOfSymbols[1].Add(sprites[spriteNumber]);
           }
        }
    }

    private void CellsGenerate()
    {
        GenerateWithKindOfSymbols(_allKindOfSymbols[random.Next(0, _allKindOfSymbols.Count)]);
    }

    private int GenerateWithKindOfSymbols(List<Sprite> kindOfSymbols)
    {
        int j = 0;
        for (float i = 0; i < _cellCount * CELL_SIZE; i += CELL_SIZE)
        {
            var cell = Instantiate(_cell, new Vector3(j % 3 * CELL_SIZE, -j / 3 * CELL_SIZE, 0), Quaternion.identity);
            j++;

            GameObject symbol = GetSymbol(kindOfSymbols);
            symbol.transform.parent = cell.transform;
            symbol.transform.position = cell.transform.position;
            symbol.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
        }
        return j;
    }

    private GameObject GetSymbol(List<Sprite> kindOfSymbols)
    {
        GameObject symbol = new GameObject();

        int randomSymbolIndex = random.Next(0, kindOfSymbols.Count);
        symbol.AddComponent<SpriteRenderer>().sprite = kindOfSymbols[randomSymbolIndex];
        kindOfSymbols.RemoveAt(randomSymbolIndex);

        var symbolComponent = symbol.AddComponent<Symbol>();
        _symbols.Add(symbolComponent);

        return symbol;
    }

    private string GenerateWinSymbol()
    {
        _symbols = _symbols.Where(x => !_usedSymbols.Contains(x.Name)).ToList();

        int winIndex = random.Next(0, _symbols.Count);
        _usedSymbols.Add(_symbols[winIndex].Name);
        
        var name = _symbols[winIndex].SetCurrect();
        _symbols.Clear();

        return name;
    }
}
