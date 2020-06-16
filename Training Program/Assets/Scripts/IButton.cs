using UnityEngine;
using System;
public interface IButton
{
    event Action OnClicked;
}