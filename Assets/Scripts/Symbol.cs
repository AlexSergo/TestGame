using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Symbol : MonoBehaviour
{
   public bool IsCurrect {get; private set;} = false;
   public string Name {get; private set;}

   private void Awake()
   {
       var spriteName = GetComponent<SpriteRenderer>().sprite.name;
       Name = Translater.Translate(spriteName);
   }

    public string SetCurrect()
    {
        List<Symbol> symbols = (GameObject.FindObjectsOfType<Symbol>()).Where(x => x.IsCurrect == true).ToList();
        if (symbols.Count == 0)
        {
            IsCurrect = true;
            return Name;
        }
        return symbols[0].Name;
    }
}
