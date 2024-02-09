using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public interface IObserver 
{
    public void OnNotify(PlayerEnums playerEnums);

    
}
