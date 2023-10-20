using System;
using System.Collections;
using System.Collections.Generic;
using SingleApp;
using Sirenix.OdinInspector;
using UnityEngine;

public class Dancer : Singleton<Dancer>
{
   public Animator anim;
   private static readonly int Blend = Animator.StringToHash("Blend");

   private void Start()
   {
       anim.enabled = false;
   }

   [Button]
   public void PlayAnim(int i)
   {
       anim.enabled = true;
       anim.SetFloat(Blend, 0.2f * i);
   }
}
