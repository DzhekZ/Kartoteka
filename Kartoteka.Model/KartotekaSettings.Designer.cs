﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kartoteka.Model {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.7.0.0")]
    internal sealed partial class KartotekaSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static KartotekaSettings defaultInstance = ((KartotekaSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new KartotekaSettings())));
        
        public static KartotekaSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1900-01-01")]
        public global::System.DateTime MinDate {
            get {
                return ((global::System.DateTime)(this["MinDate"]));
            }
            set {
                this["MinDate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2100-01-01")]
        public global::System.DateTime MaxDate {
            get {
                return ((global::System.DateTime)(this["MaxDate"]));
            }
            set {
                this["MaxDate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("14")]
        public int IssuePeriod {
            get {
                return ((int)(this["IssuePeriod"]));
            }
            set {
                this["IssuePeriod"] = value;
            }
        }
    }
}