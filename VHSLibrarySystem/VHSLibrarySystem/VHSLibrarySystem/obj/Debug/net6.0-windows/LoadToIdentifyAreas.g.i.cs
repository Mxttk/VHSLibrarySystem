﻿#pragma checksum "..\..\..\LoadToIdentifyAreas.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A1CC6D0C801327CF653E43F0EB2E7D0FBB7172F1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using VHSLibrarySystem;


namespace VHSLibrarySystem {
    
    
    /// <summary>
    /// LoadToIdentifyAreas
    /// </summary>
    public partial class LoadToIdentifyAreas : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\LoadToIdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image VHSGIF;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\LoadToIdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock loadingTextReplaceBooks;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\LoadToIdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBar sbar;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\LoadToIdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progressBarReplaceBooks;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\LoadToIdentifyAreas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnToIdentifyAreas;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VHSLibrarySystem;component/loadtoidentifyareas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\LoadToIdentifyAreas.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.VHSGIF = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.loadingTextReplaceBooks = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.sbar = ((System.Windows.Controls.Primitives.StatusBar)(target));
            return;
            case 4:
            this.progressBarReplaceBooks = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 5:
            this.btnToIdentifyAreas = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\LoadToIdentifyAreas.xaml"
            this.btnToIdentifyAreas.Click += new System.Windows.RoutedEventHandler(this.btnToIdentifyAreas_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

