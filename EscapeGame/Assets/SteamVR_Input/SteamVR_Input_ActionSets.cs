//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public partial class SteamVR_Actions
    {
        
        private static SteamVR_Input_ActionSet_default p__default;
        
        private static SteamVR_Input_ActionSet_platformer p_platformer;
        
        private static SteamVR_Input_ActionSet_buggy p_buggy;
        
        private static SteamVR_Input_ActionSet_mixedreality p_mixedreality;
        
        private static SteamVR_Input_ActionSet_Keyboard p_Keyboard;
        
        private static SteamVR_Input_ActionSet_Teleporting p_Teleporting;
        
        public static SteamVR_Input_ActionSet_default _default
        {
            get
            {
                return SteamVR_Actions.p__default.GetCopy<SteamVR_Input_ActionSet_default>();
            }
        }
        
        public static SteamVR_Input_ActionSet_platformer platformer
        {
            get
            {
                return SteamVR_Actions.p_platformer.GetCopy<SteamVR_Input_ActionSet_platformer>();
            }
        }
        
        public static SteamVR_Input_ActionSet_buggy buggy
        {
            get
            {
                return SteamVR_Actions.p_buggy.GetCopy<SteamVR_Input_ActionSet_buggy>();
            }
        }
        
        public static SteamVR_Input_ActionSet_mixedreality mixedreality
        {
            get
            {
                return SteamVR_Actions.p_mixedreality.GetCopy<SteamVR_Input_ActionSet_mixedreality>();
            }
        }
        
        public static SteamVR_Input_ActionSet_Keyboard Keyboard
        {
            get
            {
                return SteamVR_Actions.p_Keyboard.GetCopy<SteamVR_Input_ActionSet_Keyboard>();
            }
        }
        
        public static SteamVR_Input_ActionSet_Teleporting Teleporting
        {
            get
            {
                return SteamVR_Actions.p_Teleporting.GetCopy<SteamVR_Input_ActionSet_Teleporting>();
            }
        }
        
        private static void StartPreInitActionSets()
        {
            SteamVR_Actions.p__default = ((SteamVR_Input_ActionSet_default)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_default>("/actions/default")));
            SteamVR_Actions.p_platformer = ((SteamVR_Input_ActionSet_platformer)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_platformer>("/actions/platformer")));
            SteamVR_Actions.p_buggy = ((SteamVR_Input_ActionSet_buggy)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_buggy>("/actions/buggy")));
            SteamVR_Actions.p_mixedreality = ((SteamVR_Input_ActionSet_mixedreality)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_mixedreality>("/actions/mixedreality")));
            SteamVR_Actions.p_Keyboard = ((SteamVR_Input_ActionSet_Keyboard)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_Keyboard>("/actions/Keyboard")));
            SteamVR_Actions.p_Teleporting = ((SteamVR_Input_ActionSet_Teleporting)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_Teleporting>("/actions/Teleporting")));
            Valve.VR.SteamVR_Input.actionSets = new Valve.VR.SteamVR_ActionSet[] {
                    SteamVR_Actions._default,
                    SteamVR_Actions.platformer,
                    SteamVR_Actions.buggy,
                    SteamVR_Actions.mixedreality,
                    SteamVR_Actions.Keyboard,
                    SteamVR_Actions.Teleporting};
        }
    }
}
