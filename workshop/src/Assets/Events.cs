using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events  {
    public static System.Action<string> OnSoundFX = delegate { };
    public static System.Action<int> Win = delegate { };
    public static System.Action<int> CharacterGetCoin = delegate { };
    public static System.Action<int> CharacterLoseCoin = delegate { };
    public static System.Action<int> Wintime = delegate { };
    
}
