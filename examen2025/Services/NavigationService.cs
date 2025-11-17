using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using examen2025.ViewModels;
using examen2025.Views;
using FluentAvalonia.UI.Controls;

namespace examen2025.Services;

public partial class NavigationService: ObservableObject
{
    public const string INICIO_VIEW = "inicio";
    
    [ObservableProperty]
    private ContentControl currentView;
    
    [ObservableProperty]
    private NavigationViewItem selectedMenuItem;
    
    [ObservableProperty]
    private ObservableCollection<NavigationViewItem> menuItems=new();

    private NavigationViewItem inicioItem;

    public NavigationService()
    {
        inicioItem = new NavigationViewItem
        {
            Content="Inicio",
            Tag=INICIO_VIEW,
            IconSource = new SymbolIconSource{Symbol = Symbol.Home}
        };
        
        MenuItems.Add(inicioItem);

        NavigateTo(INICIO_VIEW);
    }
    
    partial void OnSelectedMenuItemChanged(NavigationViewItem item)
    {
        NavigateTo(item.Tag.ToString()); 
    }
    
    public void NavigateTo(string tag)
    {
        if (tag.Equals(INICIO_VIEW))
        {
            HomeView homeView = new HomeView();
            homeView.DataContext = new HomeViewModel();
            CurrentView = homeView;
            SelectedMenuItem = inicioItem;
        }
    }
}