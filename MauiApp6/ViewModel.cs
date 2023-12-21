using CommunityToolkit.Mvvm.ComponentModel;
using System.Timers;

namespace MauiApp6
{
    public class MyClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public partial class ViewModel : ObservableObject
    {
        private System.Timers.Timer MyTimer = new System.Timers.Timer(5000);

        [ObservableProperty]
        public List<MyClass> _myList;

        public ViewModel()
        {
            LoadList();

            MyTimer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                LoadList();
            };
            MyTimer.Start();
        }

        public void LoadList()
        {
            List<MyClass> list = [];
            int count = new Random().Next(1, 100);

            for (int i = 0; i < 30; i++)
            {
                list.Add(new MyClass
                {
                    Name = $"Name_{i}_{count}",
                    Description = $"Description_{i}_{count}",
                });
            }

            MyList = list;
        }
    }
}
