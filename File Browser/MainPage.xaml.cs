using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace File_Browser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        FolderPicker fp = new FolderPicker();
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            fp.SuggestedStartLocation = PickerLocationId.Desktop;
            fp.ViewMode = PickerViewMode.Thumbnail;
            fp.FileTypeFilter.Add("*");
         //   fp.FileTypeFilter.Add(".jpeg");
           // fp.FileTypeFilter.Add(".png");
            StorageFolder sf = await fp.PickSingleFolderAsync();
            if (sf != null)
            {
                IReadOnlyList<IStorageItem> read = await sf.GetItemsAsync();
                g.ItemsSource = read;
                g.DisplayMemberPath = "name";
            }
        }
    }
}
