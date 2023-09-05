﻿#pragma checksum "..\..\AdminPanel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2831CEA6AB75518B8EDDCD1BA167A7E671AA4756E4F1E5FFDF80C44E1536A93D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Atelier;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Atelier {
    
    
    /// <summary>
    /// AdminPanel
    /// </summary>
    public partial class AdminPanel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgOrders;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGetUsers;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGetMaterials;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnArticles;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Escape;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Accept;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Atelier;component/adminpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminPanel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dgOrders = ((System.Windows.Controls.DataGrid)(target));
            
            #line 29 "..\..\AdminPanel.xaml"
            this.dgOrders.Loaded += new System.Windows.RoutedEventHandler(this.dgOrders_Loaded);
            
            #line default
            #line hidden
            
            #line 30 "..\..\AdminPanel.xaml"
            this.dgOrders.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgOrders_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnGetUsers = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\AdminPanel.xaml"
            this.btnGetUsers.Click += new System.Windows.RoutedEventHandler(this.btnGetUsers_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnGetMaterials = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\AdminPanel.xaml"
            this.btnGetMaterials.Click += new System.Windows.RoutedEventHandler(this.btnGetMaterials_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnArticles = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\AdminPanel.xaml"
            this.btnArticles.Click += new System.Windows.RoutedEventHandler(this.btnArticles_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Escape = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\AdminPanel.xaml"
            this.Escape.Click += new System.Windows.RoutedEventHandler(this.Escape_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Accept = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\AdminPanel.xaml"
            this.Accept.Click += new System.Windows.RoutedEventHandler(this.Accept_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

