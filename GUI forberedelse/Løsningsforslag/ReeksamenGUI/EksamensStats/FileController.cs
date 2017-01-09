using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EksamensStats.Annotations;
using EksamensStats.Model;
using Microsoft.Win32;
using MvvmFoundation.Wpf;

namespace EksamensStats
{
    class FileController : INotifyPropertyChanged
    {
        private StudentContext db = new StudentContext();

        public FileController()
        {
            fileName = "Hello World";
        }

        string fileName;

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        private ICommand _findFileCommand;

        public ICommand FindFileCommand
        {
            get { return _findFileCommand ?? (_findFileCommand = new RelayCommand(FindFile)); }
        }

        private void FindFile()
        {
            Microsoft.Win32.OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".csv";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document 
                FileName = dlg.FileName;
                string[] text = System.IO.File.ReadAllLines(@FileName);

                foreach (var line in text)
                {
                    Student stu = new Student();
                    string[] sep = line.Split(',');
                    stu.StudentNr = sep[0];
                    stu.Karakter = Int32.Parse(sep[1]);
                    db.Students.Add(stu);
                    db.SaveChanges();
                }
            }
        }

        private ICommand _seeStats;

        public ICommand SeeStats
        {
            get { return _seeStats ?? (_seeStats = new RelayCommand(SeeStaticstics)); }
        }

        private void SeeStaticstics()
        {
            foreach (var student in db.Students)
            {

                switch (student.Karakter)
                {
                    case -3:
                        Minus3++;
                        break;
                    case 0:
                        NulNul++;
                        break;
                    case 2:
                        NulTo++;
                        break;
                    case 4:
                        Fire++;
                        break;
                    case 7:
                        Syv++;
                        break;
                    case 10:
                        Ti++;
                        break;
                    case 12:
                        Tolv++;
                        break;
                }
            }
           var dlg = new Window1();
            dlg.DataContext = this;

            dlg.ShowDialog();

        }

        private int minus3;
        private int nulNul;
        private int nulTo;
        private int fire;
        private int syv;
        private int ti;
        private int tolv;
        
        public int Minus3
        {
            get { return minus3; }
            set
            {
                minus3 = value;
                OnPropertyChanged("Minus3");
            }
        }

        public int NulNul
        {
            get { return nulNul; }
            set
            {
                nulNul = value;
                OnPropertyChanged("NulNul");
            }
        }
        public int NulTo
        {
            get { return nulTo; }
            set
            {
                nulTo = value;
                OnPropertyChanged("NulTo");
            }
        }
        public int Fire
        {
            get { return fire; }
            set
            {
                fire = value;
                OnPropertyChanged("Fire");
            }
        }
        public int Syv
        {
            get { return syv; }
            set
            {
                syv = value;
                OnPropertyChanged("Syv");
            }
        }
        public int Ti
        {
            get { return ti; }
            set
            {
                ti = value;
                OnPropertyChanged("Ti");
            }
        }

        public int Tolv
        {
            get { return tolv; }
            set
            {
                tolv = value;
                OnPropertyChanged("Tolv");
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
