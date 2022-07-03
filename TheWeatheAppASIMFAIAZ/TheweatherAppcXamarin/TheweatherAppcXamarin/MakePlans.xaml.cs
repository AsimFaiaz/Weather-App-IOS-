using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TheweatherAppcXamarin
{
    public partial class MakePlans : ContentPage
    {
        private readonly string fileName;

        public MakePlans()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.FileName))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                var writer = new StreamWriter(File.OpenWrite(filename));
                writer.WriteLine(note.Planner);
                writer.Close();
            }
            else
            {
                var writer = new StreamWriter(File.OpenWrite(fileName));
                writer.WriteLine(note.Planner);
                writer.Close();

            }
            
        }
    }
}
