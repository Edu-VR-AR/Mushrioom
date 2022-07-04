using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorPlayerController
{
    public static class Params
    {
        public const string Speed = "Speed";
        public const string Attack = "Attack";
    }

    public static class States
    {
        public const string Idle = "MushroomIDLE";
        public const string Run = "MushroomWalk";
        public const string Jump = "MushroomAttack";
    }
}
