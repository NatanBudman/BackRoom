using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static IConditions conditions;
   
  
    // Update is called once per frame
    void Update()
    {
        conditions.Win();
        conditions.Lose();

    }


}
