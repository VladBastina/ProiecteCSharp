﻿#pragma checksum "..\..\..\..\Views\CasierMenu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9AD7D33972521913B1055FE5A2F7929DC70B6D72"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SuperMarket_Gestiune.ViewModels;
using SuperMarket_Gestiune.Views;
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


namespace SuperMarket_Gestiune.Views {
    
    
    /// <summary>
    /// CasierMenu
    /// </summary>
    public partial class CasierMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\Views\CasierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductNameSearch;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Views\CasierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BarcodeSearch;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Views\CasierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ExpirationDateSearch;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Views\CasierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ManufacturerSearch;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Views\CasierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CategorySearch;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Views\CasierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ReceiptListView;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Views\CasierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TotalPriceTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SuperMarket-Gestiune;component/views/casiermenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\CasierMenu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProductNameSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BarcodeSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ExpirationDateSearch = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.ManufacturerSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.CategorySearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 54 "..\..\..\..\Views\CasierMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchProduct_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ReceiptListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.TotalPriceTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            
            #line 77 "..\..\..\..\Views\CasierMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ConfirmReceipt_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 78 "..\..\..\..\Views\CasierMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ResetReceipt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

