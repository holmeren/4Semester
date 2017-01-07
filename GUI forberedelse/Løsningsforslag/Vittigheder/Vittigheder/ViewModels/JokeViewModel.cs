using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmFoundation.Wpf;
using Vittigheder.Annotations;
using Vittigheder.Models;

namespace Vittigheder.ViewModels
{
    public class JokeViewModel : INotifyPropertyChanged
    {
        private JokeContext db = new JokeContext();
        public Tag Tag { get; set; } = new Tag();

        public List<Joke> Jokes
        {
            get { return _jokes; }
            set
            {
                if (Equals(value, _jokes)) return;
                _jokes = value;
                OnPropertyChanged(nameof(Jokes));
            }
        }

        private ICommand _addNewJokeCommand;
        private ICommand _searchCategoryCommand;
        private List<Joke> _jokes = new List<Joke>();

        public ICommand AddNewJokeomCommand => _addNewJokeCommand ?? (_addNewJokeCommand = new RelayCommand(() =>
                                               {
                                                   var dlg = new JokeDlg();
                                                   var joke = new Joke();
                                                   dlg.DataContext = joke;
                                                   if (dlg.ShowDialog() == true)
                                                   {
                                                       joke.Date = DateTime.Now;
                                                       db.Jokes.Add(joke);
                                                       db.SaveChanges();
                                                   }
                                               }));

        public ICommand SearchCategoryCommand => _searchCategoryCommand ?? (_searchCategoryCommand = new RelayCommand(
                                                     () =>
                                                     {
                                                         var catJokes = new List<Joke>();
                                                         var jokes =
                                                             db.Jokes.Include("Tags")
                                                                 .AsNoTracking()
                                                                 .ToList();

                                                         foreach (var item in jokes)
                                                         {
                                                             foreach (var tag in item.Tags)
                                                             {
                                                                 if (tag.TagString.ToLower() == Tag.TagString.ToLower())
                                                                 {
                                                                     catJokes.Add(item);
                                                                 }
                                                             }
                                                         }

                                                         Jokes = catJokes;
                                                     }));

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
