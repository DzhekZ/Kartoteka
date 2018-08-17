using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Kartoteka.Client.WPFApp.Views;
using Kartoteka.Client.WPFApp.ViewModels;
using ReactiveUI;
using Splat;

namespace Kartoteka.Client.WPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public RoutingState Router { get; private set; }

        public App()
        {
            // Create router for IScreen
            Router = new RoutingState();

            // Register ourselves as the Screen instance
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            // Register the views for the view models
            Locator.CurrentMutable.Register(() => new ChitateliMain(), typeof(IViewFor<ChitateliMainVM>));
            Locator.CurrentMutable.Register(() => new ChitateliList(), typeof(IViewFor<ChitateliListVM>));
            // Navigate
            this.Router.Navigate.Execute(new MainWindowVM());
        }
    }
}
