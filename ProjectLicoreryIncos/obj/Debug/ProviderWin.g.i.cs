﻿#pragma checksum "..\..\ProviderWin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8D625DA808DC684D844A29FBE99A1EF4B6DFA6CB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using ProjectLicoreryIncos;
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


namespace ProjectLicoreryIncos {
    
    
    /// <summary>
    /// ProviderWin
    /// </summary>
    public partial class ProviderWin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\ProviderWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImgLogo;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\ProviderWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_address;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\ProviderWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_nit;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\ProviderWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_phone;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\ProviderWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Bussinessname;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\ProviderWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\ProviderWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_search;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\ProviderWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvDatos;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectLicoreryIncos;component/providerwin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProviderWin.xaml"
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
            
            #line 32 "..\..\ProviderWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_close);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ImgLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.txt_address = ((System.Windows.Controls.TextBox)(target));
            
            #line 58 "..\..\ProviderWin.xaml"
            this.txt_address.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_address_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_nit = ((System.Windows.Controls.TextBox)(target));
            
            #line 63 "..\..\ProviderWin.xaml"
            this.txt_nit.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_nit_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txt_phone = ((System.Windows.Controls.TextBox)(target));
            
            #line 72 "..\..\ProviderWin.xaml"
            this.txt_phone.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_phone_TextChanged);
            
            #line default
            #line hidden
            
            #line 72 "..\..\ProviderWin.xaml"
            this.txt_phone.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_phone_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txt_Bussinessname = ((System.Windows.Controls.TextBox)(target));
            
            #line 77 "..\..\ProviderWin.xaml"
            this.txt_Bussinessname.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_Bussinessname_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\ProviderWin.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 102 "..\..\ProviderWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 109 "..\..\ProviderWin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click1);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txt_search = ((System.Windows.Controls.TextBox)(target));
            
            #line 118 "..\..\ProviderWin.xaml"
            this.txt_search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.dgvDatos = ((System.Windows.Controls.DataGrid)(target));
            
            #line 120 "..\..\ProviderWin.xaml"
            this.dgvDatos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgvDatos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

