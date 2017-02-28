using CommunityCoreLibrary;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace Zit
{
   public class MainTabWindow_HelloWorld : MainTabWindow
   {
      public override void DoWindowContents(Rect canvas)
      {
         base.DoWindowContents(canvas);

         Rect position = new Rect(0f, 0f, 100f, 100f);
         GUI.BeginGroup(position);

         Text.Font = GameFont.Small;
         Rect sourceButton = new Rect(0f, 0f, 50f, 50f);
         Widgets.ButtonText(sourceButton, ("Zit.helloworld").Translate());

         try
         {
            throw new System.Exception("Test");
         }
         catch (System.Exception e)
         {
         }

         GUI.EndGroup();

      }
   }
}