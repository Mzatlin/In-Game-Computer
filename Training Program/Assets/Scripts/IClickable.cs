﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickable {

    void HandleClick();
    bool IsHovering { get; set; }
}
