using System;
using TodoApp.Models;
using TodoApp.ViewModels;
using Xamarin.Forms;

namespace TodoApp.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = new ListPageViewModel();
        }
        
    }
}