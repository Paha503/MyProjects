﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "511C1A9EAA8DE4FF819697CB1C8DE1A8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:2.0.50727.6421
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace WPFHost {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox textBoxIP;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Window1.xaml"
        internal System.Windows.Controls.TextBox textBoxPort;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button buttonStop;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button buttonStart;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label labelStatus;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label labelTitle;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFHost;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.textBoxIP = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBoxPort = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.buttonStop = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\Window1.xaml"
            this.buttonStop.Click += new System.Windows.RoutedEventHandler(this.buttonStop_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonStart = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\Window1.xaml"
            this.buttonStart.Click += new System.Windows.RoutedEventHandler(this.buttonStart_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.labelStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.labelTitle = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

