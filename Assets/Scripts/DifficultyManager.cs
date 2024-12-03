using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyManager
{
    public static float fCurrentDifficulty = 0.5f;

    public static void ChangeDifficulty(float changeNumb)
    {
        fCurrentDifficulty += changeNumb;

        if (fCurrentDifficulty < 0) 
        { 
            fCurrentDifficulty = 0;
        }
        else if (fCurrentDifficulty > 1)
        {
            fCurrentDifficulty = 1;
        }
    }

    public static void ResetDifficulty()
    {
        fCurrentDifficulty = .5f;
    }

    public static int CalculateDifficulty(int numberOfOptions)
    {
        float distanceBetweenOptions = 1 / numberOfOptions;

        for (int i = 0; i < numberOfOptions; i++) 
        {
            float optionRange = distanceBetweenOptions*(i+1);
            if (1 - fCurrentDifficulty <= optionRange )
            {
                return i;
            }
        }

        return 0;
    }
}
